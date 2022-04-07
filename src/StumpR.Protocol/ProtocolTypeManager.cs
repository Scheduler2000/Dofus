using System.Linq.Expressions;
using System.Reflection;

namespace StumpR.Protocol;

public static class ProtocolTypeManager
{
    private static readonly Dictionary<short, Type> Types = new(335);
    private static readonly Dictionary<short, Func<object>> TypesConstructors = new(335);

    /// <summary>
    ///     Initializes this instance.
    /// </summary>
    public static void Initialize()
    {
        var asm = Assembly.GetAssembly(typeof(Message));

        if (asm == null)
            return;
        
        foreach (Type type in asm.GetTypes().Where(x => x.IsClass && x.Namespace == "StumpR.Protocol.Types"))
        {
            FieldInfo field = type.GetField("Id");

            if (field == null) continue;

            var id = (short) field.GetValue(type)!;

            Types.Add(id, type);

            ConstructorInfo ctor = type.GetConstructor(Type.EmptyTypes);

            if (ctor == null)
                throw new Exception($"'{type}' doesn't implemented a parameterless constructor");

            List<ParameterExpression> parameters = ctor.GetParameters()
                .Select(param => Expression.Parameter(param.ParameterType))
                .ToList();

            Expression<Func<object>> lamba =
                Expression.Lambda<Func<object>>(Expression.New(ctor, parameters), parameters);

            TypesConstructors.Add(id, lamba.Compile());
        }
    }

    /// <summary>
    ///     Gets instance of the type defined by id.
    /// </summary>
    /// <typeparam name="T">Type.</typeparam>
    /// <param name="id">id.</param>
    /// <returns></returns>
    public static T GetInstance<T>(short id) where T : class
    {
        if (!Types.ContainsKey(id)) throw new Exception($"Type <id:{id}> doesn't exist");

        return TypesConstructors[id]() as T;
    }
    
}