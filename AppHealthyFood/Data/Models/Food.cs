using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppHealthyFood.Data.Models
{
    public class Food
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public double Calories { get; set; }

        [Required]
        public double Protein { get; set; }

        [Required]
        public double Carbohydrates { get; set; }

        [Required]
        public double Fat { get; set; }

        public List<MealPlan> MealPlans { get; set; } = new List<MealPlan>();
    }
}
