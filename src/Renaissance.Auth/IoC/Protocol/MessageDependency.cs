using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Linq.Expressions;

using Renaissance.Abstract;
using Renaissance.Protocol;

namespace Renaissance.Auth.IoC.Protocol
{
    public class MessageDependency
    {

        private ImmutableDictionary<int, Func<IDofusMessage>>.Builder m_messages;


        public MessageDependency()
        { this.m_messages = ImmutableDictionary.CreateBuilder<int, Func<IDofusMessage>>(); }

        public MessageDependency Congifure()
        {
            int messageId;
            Func<IDofusMessage> function;
            IEnumerable<Type> types = typeof(IDofusMessage).Assembly
                                                           .GetTypes()
                                                           .Where(x => (typeof(IDofusMessage).IsAssignableFrom(x) &&
                                                           x.Name != "IDofusMessage" &&
                                                           x.Namespace.Contains("connection")) ||
                                                           x.Namespace.Contains("handshake") ||
                                                           x.Namespace.Contains("messages.common.basic") ||
                                                           x.Namespace.Contains("queues"));

            foreach (var type in types)
            {
                messageId = (int)type.GetField("NetworkId").GetValue(type);
                function = Expression.Lambda<Func<IDofusMessage>>(Expression.New(type)).Compile();
                m_messages.Add(new KeyValuePair<int, Func<IDofusMessage>>(messageId, function));
            }

            Logger.Instance.Log(LogLevel.Debug, "AUTHENTICATION PROTOCOL", $"{ types.Count()} entities loaded.");

            return this;
        }

        public ImmutableDictionary<int, Func<IDofusMessage>> Build()
        { return m_messages.ToImmutable(); }
    }
}
