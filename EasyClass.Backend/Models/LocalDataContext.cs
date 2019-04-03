namespace EasyClass.Backend.Models
{
    using EasyClass.Common.Models;
    using EasyClass.Domain.Models;
    using System.Data.Entity;

    public class LocalDataContext : DataContext
    {
        public DbSet <Rubric> rubrics { get; set; }
    }
}