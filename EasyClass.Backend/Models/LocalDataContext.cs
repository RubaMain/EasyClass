namespace EasyClass.Backend.Models
{
    using EasyClass.Domain.Models;

    public class LocalDataContext : DataContext
    {
        public System.Data.Entity.DbSet<EasyClass.Common.Models.Rubric> Rubrics { get; set; }
    }
}