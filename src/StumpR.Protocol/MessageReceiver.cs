using System.Linq.Expressions;
using System.Reflection;
using StumpR.Binary;
using StumpR.Binary.BigEndian;

namespace StumpR.Protocol;

public class MessageReceiver
{
    private static readonly Dictionary<int, Func<Message>> MessagesConstructors = new(1108);

    /// <summary>
    ///     Initializes this instance.
    /// </summary>
    public static void Initialize()
    {
        var asm = Assembly.GetAssembly(typeof(Message));

        if (asm == null) return;

        foreach (Type type in asm.GetTypes().Where(x => x.IsClass && x.IsSubclassOf(typeof(Message))))
        {
            FieldInfo field = type.GetField("Id");

            if (field == null) continue;

            var id = (int) (uint) field.GetValue(type)!;

            ConstructorInfo ctor = type.GetConstructor(Type.EmptyTypes);

            if (ctor == null) throw new Exception($"'{type}' doesn't implemented a parameterless constructor");

            var parameters = ctor.GetParameters()
                .Select(param => Expression.Parameter(param.ParameterType))
                .ToList();

            var lamba =
                Expression.Lambda<Func<Message>>(Expression.New(ctor, parameters), parameters);

            MessagesConstructors.Add(id, lamba.Compile());
        }
    }

    public static bool EnsureMessageId(int id)
    {
        return MessagesConstructors.ContainsKey(id);
    }

    /// <summary>
    ///     Gets instance of the message defined by its id
    /// </summary>
    /// <param name="id">Message Id</param>
    /// <param name="payload">Data of the message</param>
    /// <returns>Unpacked message</returns>
    public static Message ComputeMessage(int id, byte[] payload)
    {
        if (!MessagesConstructors.TryGetValue(id, out var messageCtor)) throw new Exception($"Message <id:{id}> doesn't exist");

        IDataReader reader = new BigEndianReader(payload);

        Message message = messageCtor();

        if (payload.Length != 0) message!.Unpack(reader);

        return message;
    }

    /// <summary>
    ///     Gets instance of the message defined by its id
    /// </summary>
    /// <param name="id">Message Id</param>
    /// <param name="payload">Data of the message</param>
    /// <returns>Unpacked message</returns>
    public static bool TryComputeMessage(int id, byte[] payload, out Message message)
    {
        message = default;

        try { message = ComputeMessage(id, payload); }
        catch (Exception ex) { return false; }

        return true;
    }
}