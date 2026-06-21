using AppHealthyFood.Data;
using AppHealthyFood.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppHealthyFood.Controllers
{
    internal class UserController
    {
        private MyContext db = new MyContext();

        public void Add(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
        }

        public List<User> GetAll()
        {
            return db.Users.ToList();
        }

        public void Update(int id, string name)
        {
            var user = db.Users.Find(id);
            if (user != null)
            {
                user.FirstName = name;
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var user = db.Users.Find(id);
            if (user != null)
            {
                db.Users.Remove(user);
                db.SaveChanges();
            }
        }
    }
}
