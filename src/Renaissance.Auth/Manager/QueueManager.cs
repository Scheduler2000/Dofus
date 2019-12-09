using System.Collections.Generic;
using Renaissance.Auth.Networking;
using Renaissance.Auth.Patch;
using Renaissance.Protocol.messages.handshake;
using Renaissance.Protocol.messages.queues;
using Renaissance.Protocol.messages.security;

namespace Renaissance.Auth.Manager
{
    public class QueueManager
    {
        public Queue<AuthClient> Queue { get; }

        public QueueManager()
        { this.Queue = new Queue<AuthClient>(); }

        public void Process() /* theoretically thread safe executed by (Async Pool)*/
        {
            short position;

            while (Queue.TryDequeue(out var authClient))
            {
                position = default;

                foreach (var client in Queue)
                {
                    position++;
                    client.Connection.Send(new LoginQueueStatusMessage()
                                     .InitLoginQueueStatusMessage(position, (short)Queue.Count));
                }

                authClient.Connection.Send(new ProtocolRequired().InitProtocolRequired(1945, 1945));
                authClient.Connection.Send(new RawDataMessage().InitRawDataMessage(PatchDataAccess.PatchBuffer));
            }

        }

    }
}
