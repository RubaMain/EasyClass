namespace EasyClass.Common.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Rubric
    {
        [Key]
        public int RubricId { get; set; }

        [Required]
        public string RubricTitle { get; set; }

        [Required]
        public string RubricDescription { get; set; }

        [Required]
        public DateTime RubricDate { get; set; }

        public override string ToString()
        {
            return this.RubricTitle;
        }
    }
}
