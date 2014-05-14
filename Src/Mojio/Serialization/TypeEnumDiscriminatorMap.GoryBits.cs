using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Mojio.Serialization
{
    public abstract partial class TypeEnumDiscriminatorMap
    {        
        public string Property { get; set; }

        public static Dictionary<Type, TypeEnumDiscriminatorMap> Maps { get; private set; }

        static TypeEnumDiscriminatorMap<D> Map<B, D>(Expression<Func<B, D>> property)
            where D : struct
        {
            Type baseType = typeof(B);
            TypeEnumDiscriminatorMap<D> map;

            var propertyName = (property.Body as MemberExpression).Member.Name;
            if (!Maps.ContainsKey(baseType))
            {
                map = new TypeEnumDiscriminatorMap<D>();
                Maps.Add(baseType, map);
                map.Property = propertyName;
            }
            else
            {
                map = Maps[baseType] as TypeEnumDiscriminatorMap<D>;
                if (map.Property != propertyName)
                    throw new ArgumentException("Attempt to change map property from " + map.Property + " to " + propertyName);
            }

            return map;
        }
        
        static public TypeEnumDiscriminatorMap GetMap(Type type)
        {
            if (Maps.ContainsKey(type))
                return Maps[type];
            return null;
        }
        public abstract Type Find(string discriminator);
        public abstract object Create(string discriminator = null);
    }

    class TypeEnumDiscriminatorMap<D> : TypeEnumDiscriminatorMap
        where D : struct
    {
        public Dictionary<D, Type> SubTypes { get; set; }

        public TypeEnumDiscriminatorMap<D> Contains<S>(D disc)
        {
            var type = typeof(S);
            if (SubTypes == null)
                SubTypes = new Dictionary<D, Type>();
            SubTypes.Add(disc, type);
            return this;
        }

        public override Type Find(string discriminator)
        {
            D disc = default(D);
            if (!string.IsNullOrEmpty(discriminator))
            {
                if (!Enum.TryParse<D>(discriminator, out disc))
                    return null;

                if (!SubTypes.ContainsKey(disc))
                    return null;
            }

            return SubTypes[disc];
        }

        public override object Create(string discriminator = null)
        {
            var type = Find(discriminator);
            if (type != null)
                return Activator.CreateInstance(type);
            return null;
        }
    }

}
