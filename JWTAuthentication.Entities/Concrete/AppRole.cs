using System.Collections.Generic;
using JWTAuthentication.Entities.Abstract;

namespace JWTAuthentication.Entities.Concrete
{
    public class AppRole : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<AppUserRole> AppUserRoles{ get; set; }
    }
}
