using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppHealthyFood.Data.Models
{
    public class User
    {
        [Required]
        public int Id { get; set; }

        [Required, StringLength(20)]
        public string FirstName { get; set; }

        [Required, StringLength(20)]
        public string LastName { get; set; }

        [Required, Range(18, 99)]
        public int Age { get; set; }

        [Required, Range(30, 150)]
        public double Weight { get; set; }

        [Required, Range(120, 230)]
        public double Height { get; set; }

        public List<MealPlan> MealPlans { get; set; } = new List<MealPlan>();
    }
}
