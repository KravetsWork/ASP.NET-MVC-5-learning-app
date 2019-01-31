namespace PeopleOnMap.Models
{
    using System.Data.Entity;

    public class ModelDB : DbContext
    {
        public ModelDB()
            : base("name=ModelDB")
        {
        }

         public virtual DbSet<Person> People { get; set; }
    }
}