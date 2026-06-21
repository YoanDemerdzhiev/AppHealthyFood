using AppHealthyFood.Data;
using AppHealthyFood.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppHealthyFood.Controllers
{
    internal class MealPlanController
    {
        private MyContext db = new MyContext();

        public void Add(MealPlan meal)
        {
            db.MealPlans.Add(meal);
            db.SaveChanges();
        }

        public List<MealPlan> GetAll()
        {
            return db.MealPlans.ToList();
        }

        public void Delete(int id)
        {
            var meal = db.MealPlans.Find(id);
            if (meal != null)
            {
                db.MealPlans.Remove(meal);
                db.SaveChanges();
            }
        }
    }
}
