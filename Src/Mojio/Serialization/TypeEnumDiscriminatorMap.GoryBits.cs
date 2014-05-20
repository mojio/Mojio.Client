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

    public class TypeEnumDiscriminatorMap<D> : TypeEnumDiscriminatorMap
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
            }

            return Find(disc);
        }

        public override object Create(string discriminator = null)
        {
            var type = Find(discriminator);
            if (type != null)
                return Activator.CreateInstance(type);
            return null;
        }

        public D Find(Type type)
        {
            var query = from d in SubTypes
                        where d.Value.Equals(type)
                        select d.Key;

            return query.FirstOrDefault();
        }

        public Type Find(D discriminator)
        {
            if (!SubTypes.ContainsKey(discriminator))
                return null;

            return SubTypes[discriminator];
        }
    }

}
