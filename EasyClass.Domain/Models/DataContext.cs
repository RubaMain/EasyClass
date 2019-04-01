using EasyClass.Common.Models;
using System.Data.Entity;

namespace EasyClass.Domain.Models
{
  
    public class DataContext : DbContext
    {
        public DataContext() : base("DefaultConnection")
        {

        }

        public DbSet<Rubric> Rubrics { get; set; }
    }
}
