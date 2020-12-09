﻿using JWTAuthentication.Entities.Abstract;

namespace JWTAuthentication.Entities.Concrete
{
    public class AppUserRole : IEntity
    {
        public int Id { get; set; }

        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public int AppRoleId { get; set; }
        public AppRole AppRole { get; set; }
    }
}
