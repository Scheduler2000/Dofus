using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection;

using Renaissance.Abstract.Network.Interface;
using Renaissance.Protocol;

namespace Renaissance.Abstract.Frame.Brain
{
    public class FrameBuilder<TClient> where TClient : IDofusClient
    {
        private readonly ImmutableDictionary<int, Action<TClient, IDofusMessage>>.Builder m_frames;

        public FrameBuilder()
        { this.m_frames = ImmutableDictionary.CreateBuilder<int, Action<TClient, IDofusMessage>>(); }


        public FrameBuilder<TClient> RegisterFrame<TFrame>(TFrame frame) where TFrame : IFrame
        {
            Action<TClient, IDofusMessage> del;
            MessageHandlerAttribute attribute;
            IEnumerable<MethodInfo> methods = frame.GetType()
                                                    .GetMethods()
                                                    .Where(x => (x.GetCustomAttribute(typeof(MessageHandlerAttribute))
                                                    as MessageHandlerAttribute) != null);
            foreach (MethodInfo method in methods)
            {
                attribute = (MessageHandlerAttribute)method.GetCustomAttribute(typeof(MessageHandlerAttribute));

                del = Delegate.CreateDelegate(typeof(Action<TClient, IDofusMessage>), null, method)
                      as Action<TClient, IDofusMessage>;

                m_frames.Add(attribute.MessageId, del);

            }

            Logger.Instance.Log(LogLevel.Debug, $"FRAME-BUILDER",
                $"{ methods.Count()} methods handled from {typeof(TFrame).Name}.");

            return this;
        }

        public ImmutableDictionary<int, Action<TClient, IDofusMessage>> Build()
        { return m_frames.ToImmutable(); }
    }
}
