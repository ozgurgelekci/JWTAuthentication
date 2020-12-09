using JWTAuthentication.Entities.Abstract;

namespace JWTAuthentication.Entities.Concrete
{
    public class Product : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
