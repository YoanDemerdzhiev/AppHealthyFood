using AppHealthyFood.Controllers;
using AppHealthyFood.Data.Models;

var foodController = new FoodController();
var userController = new UserController();
var mealController = new MealPlanController();

bool exit = false;

while (!exit)
{
    Console.WriteLine("1. Add user");
    Console.WriteLine("2. Show users");
    Console.WriteLine("3. Add food");
    Console.WriteLine("4. Show food");
    Console.WriteLine("5. Update food");
    Console.WriteLine("6. Delete food");
    Console.WriteLine("0. Exit");

    int choice = int.Parse(Console.ReadLine());

    switch (choice)
    {
        case 1:
            User user = new User();

            Console.Write("Name: ");
            user.FirstName = Console.ReadLine();

            Console.Write("Last Name: ");
            user.LastName = Console.ReadLine();

            Console.Write("Age: ");
            user.Age = int.Parse(Console.ReadLine());

            Console.Write("Weight: ");
            user.Weight = int.Parse(Console.ReadLine()); 
            
            Console.Write("Height: ");
            user.Height = int.Parse(Console.ReadLine());

            userController.Add(user);
            break;

        case 2:
            foreach (var u in userController.GetAll())
                Console.WriteLine($"{u.Id} {u.FirstName} {u.LastName}");
            break;

        case 3:
            Food food = new Food();

            Console.Write("Name: ");
            food.Name = Console.ReadLine();

            Console.Write("Calories: ");
            food.Calories = double.Parse(Console.ReadLine());

            Console.Write("Protein: ");
            food.Protein = double.Parse(Console.ReadLine()); 

            Console.Write("Carbs: ");
            food.Carbohydrates = double.Parse(Console.ReadLine()); 
            
            Console.Write("Fats: ");
            food.Fat = double.Parse(Console.ReadLine());

            foodController.AddFood(food);
            break;

        case 4:
            foreach (var f in foodController.GetAll())
                Console.WriteLine($"{f.Id} {f.Name} {f.Calories}");
            break;

         case 5:
            Console.Write("Food ID to update: ");
            int updateId = int.Parse(Console.ReadLine());
            Console.Write("New calories: ");
            double newCalories = double.Parse(Console.ReadLine());
            foodController.UpdateFood(updateId, newCalories);
            break;

        case 6:
            Console.Write("Food ID to delete: ");
            int deleteId = int.Parse(Console.ReadLine());
            foodController.DeleteFood(deleteId);
            break;

        case 0:
            exit = true;
            break;
    }
}
