using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mojio
{
    [Flags]
    public enum Permissions
    {
        None = 0,
        Read = 1 << 0,
        Write = 1 << 1,
        Share = 1 << 2,
        Owner = ~None,
    }

    public class AccessRule : GuidEntity
    {
        /// <summary>
        /// Type of entity. This is only really needed for double checking?
        /// </summary>
        public Guid Group { get; set; }

        public IEnumerable<string> Permissions { get; set; }

        public IEnumerable<Permission> GetPermissions() 
        {
            return from p in Permissions
                   select Permission.FromString(p);
        }

        public void SetPermissions(IEnumerable<Permission> permissions)
        {
            Permissions = from p in permissions
                          select p.ToString();
        }

        public override EntityType Type
        {
            get { return global::Mojio.EntityType.Access; }
        }
    }

    public class Permission
    {
        [Flags]
        public enum Action
        {
            None = 0,
            Read = 1 << 0,
            Write = 1 << 1,
            Share = 1 << 2,
            All = Read | Write | Share,
            Owner = ~None
        }

        public Permission()
        {
        }

        public Permission(string action, string entity, string property = null) :
            this((Action) Enum.Parse(typeof(Action), action, true), entity, property)
        {
        }

        public Permission(Action action, Type entity, string property = null) :
            this(action, entity.Name, property)
        {

        }

        public Permission(Action action, string entity, string property = null)
            : this()
        {
            Actions = action;
            Resource = entity;
            Property = property;
        }

        public Action Actions { get; set; }

        public string Resource { get; set; }

        public string Property { get; set; }

        public override string ToString()
        {
            if (String.IsNullOrWhiteSpace(Property))
            {
                return String.Format("{0}:{1}", Actions, Resource);
            }
            else
            {
                return String.Format("{0}:{1}:{2}", Actions, Resource, Property);
            }
        }

        public static Permission FromString(string permission)
        {
            var parts = permission.Split(':');
            Action action;
            if (!Enum.TryParse<Action>(parts.First(), true, out action))
            {
                // Log error instead?  Throw exception?  Or set default?
                //throw new ArgumentException("Invalid action type.");
                //action = Action.Read;
                return null;
            }

            var entity = parts.Skip(1).FirstOrDefault();
            if (entity == null)
                return null;

            var property = parts.Skip(2).FirstOrDefault();

            return new Permission(action, entity, property);
        }
    }

    public class UserAccess
    {
        public Guid UserId { get; set; }

        public Permissions Permissions { get; set; }
    }
}
