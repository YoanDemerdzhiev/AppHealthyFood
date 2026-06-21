using AppHealthyFood.Data;
using AppHealthyFood.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppHealthyFood.Controllers
{
    internal class FoodController
    {
        private MyContext db = new MyContext();

        public void AddFood(Food food)
        {
            db.Foods.Add(food);
            db.SaveChanges();
        }

        public List<Food> GetAll()
        {
            return db.Foods.ToList();
        }

        public void UpdateFood(int id, int calories)
        {
            var food = db.Foods.Find(id);
            if (food != null)
            {
                food.Calories = calories;
                db.SaveChanges();
            }
        }
        public void DeleteFood(int id)
        {
            var food = db.Foods.Find(id);
            if (food != null)
            {
                db.Foods.Remove(food);
                db.SaveChanges();
            }
        }
    }
}
