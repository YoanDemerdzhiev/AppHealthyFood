using AppHealthyFood.Data;
using AppHealthyFood.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace AppHealthyFood.Tests
{
    public class Tests
    {
        private MyContext CreateContext()
        {
            var options = new DbContextOptionsBuilder<MyContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            return new MyContext(options);
        }

        [Test]
        public void Test_CreateFood()
        {
            using var context = CreateContext();
            var food = new Food
            {
                Name = "Apple",
                Calories = 95,
                Protein = 0.5,
                Carbohydrates = 25,
                Fat = 0.3
            };

            context.Foods.Add(food);
            context.SaveChanges();

            Assert.That(context.Foods.Count(), Is.EqualTo(1));
            Assert.That(context.Foods.First().Name, Is.EqualTo("Apple"));
        }

        [Test]
        public void Test_ReadFoods()
        {
            using var context = CreateContext();
            context.Foods.AddRange(
                new Food { Name = "Banana", Calories = 105, Protein = 1.3, Carbohydrates = 27, Fat = 0.4 },
                new Food { Name = "Orange", Calories = 62, Protein = 1.2, Carbohydrates = 15, Fat = 0.2 }
            );
            context.SaveChanges();

            var foods = context.Foods.ToList();

            Assert.That(foods.Count, Is.EqualTo(2));
        }

        [Test]
        public void Test_UpdateFood()
        {
            using var context = CreateContext();
            var food = new Food
            {
                Name = "Pizza",
                Calories = 285,
                Protein = 12,
                Carbohydrates = 36,
                Fat = 10
            };
            context.Foods.Add(food);
            context.SaveChanges();

            var saved = context.Foods.First();
            saved.Calories = 300;
            context.SaveChanges();

            var updated = context.Foods.First();
            Assert.That(updated.Calories, Is.EqualTo(300));
        }

        [Test]
        public void Test_DeleteFood()
        {
            using var context = CreateContext();
            var food = new Food
            {
                Name = "Burger",
                Calories = 550,
                Protein = 25,
                Carbohydrates = 40,
                Fat = 30
            };
            context.Foods.Add(food);
            context.SaveChanges();

            context.Foods.Remove(context.Foods.First());
            context.SaveChanges();

            Assert.That(context.Foods.Count(), Is.EqualTo(0));
        }
    }
}
