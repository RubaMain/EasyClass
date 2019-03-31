namespace EasyClass.Domain.Models
{
    using System.Data.Entity;

    public class DataContext : DbContext
    {
        public DataContext() : base("DefaultConnection")
        {

        }

        public System.Data.Entity.DbSet<EasyClass.Common.Models.Rubric> Rubrics { get; set; }
    }
}
