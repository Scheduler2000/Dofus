using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;

namespace Renaissance.Data.D2O.Structure
{
    public class GameDataCreator

    {
        private Func<GameDataField, GameDataTypeEnum, int, object> m_readFieldDelegate;

        internal Dictionary<Type, Func<object[], object>> ObjetCreators { get; }


        public GameDataCreator(Func<GameDataField, GameDataTypeEnum, int, object> readDelegate)
        {
            this.ObjetCreators = new Dictionary<Type, Func<object[], object>>();
            this.m_readFieldDelegate = readDelegate;
        }

        public object BuildObject(GameDataClassDefintion classDefinition)
        {
            if (!ObjetCreators.ContainsKey(classDefinition.ClassType))
                ObjetCreators.Add(classDefinition.ClassType,
                    CreateObjectBuilder(classDefinition.ClassType, classDefinition.Fields.Select(
                       entry => entry.Value.FieldInfo).ToArray()));

            var values = new List<object>();

            foreach (var field in classDefinition.Fields.Values)
            {
                object fieldValue = m_readFieldDelegate(field, field.TypeId, 0);

                if (field.FieldType.IsInstanceOfType(fieldValue))
                    values.Add(fieldValue);

                else if (fieldValue is IConvertible && field.FieldType.GetInterface("IConvertible") != null)
                    try
                    {
                        if (fieldValue is int && (int)fieldValue < 0 && field.FieldType == typeof(uint))
                            values.Add(unchecked((uint)(int)fieldValue));
                        else
                            values.Add(Convert.ChangeType(fieldValue, field.FieldType));
                    }
                    catch
                    {
                        throw new Exception(
                            $"Field '{classDefinition.Name}.{field.Name}' with value {fieldValue} is not of type '{fieldValue.GetType()}'");
                    }
                else
                    throw new Exception(
                        $"Field '{classDefinition.Name}.{field.Name}' with value {fieldValue} is not of type '{fieldValue.GetType()}'");
            }

            return ObjetCreators[classDefinition.ClassType](values.ToArray());
        }


        public Func<object[], object> CreateObjectBuilder(Type classType, params FieldInfo[] fields)
        {
            var method = new DynamicMethod(Guid.NewGuid().ToString("N"), typeof(object),
                new[] { typeof(object[]) }.ToArray());

            var ilGenerator = method.GetILGenerator();

            ilGenerator.DeclareLocal(classType);
            ilGenerator.DeclareLocal(classType);

            ilGenerator.Emit(OpCodes.Newobj, classType.GetConstructor(Type.EmptyTypes));
            ilGenerator.Emit(OpCodes.Stloc_0);
            for (var i = 0; i < fields.Length; i++)
            {
                ilGenerator.Emit(OpCodes.Ldloc_0);
                ilGenerator.Emit(OpCodes.Ldarg_0);
                ilGenerator.Emit(OpCodes.Ldc_I4, i);
                ilGenerator.Emit(OpCodes.Ldelem_Ref);

                ilGenerator.Emit(fields[i].FieldType.IsClass ? OpCodes.Castclass : OpCodes.Unbox_Any,
                    fields[i].FieldType);

                ilGenerator.Emit(OpCodes.Stfld, fields[i]);
            }

            ilGenerator.Emit(OpCodes.Ldloc_0);
            ilGenerator.Emit(OpCodes.Stloc_1);
            ilGenerator.Emit(OpCodes.Ldloc_1);
            ilGenerator.Emit(OpCodes.Ret);

            return
                (Func<object[], object>)
                method.CreateDelegate(Expression.GetFuncType(new[] { typeof(object[]), typeof(object) }.ToArray()));
        }
    }
}
