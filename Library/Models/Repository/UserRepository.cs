using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.Models.Repository
{
    public class UserRepository : Repository<User>
    {

        DBEntities context = new DBEntities();
        public User GetUserByUsername(string username)
        {

            return this.GetALLData().Where(x => x.Username == username).FirstOrDefault();

        }
        public List<User> GetAllAdmin(string usertype)
        {

            return this.GetALLData().Where(x => x.UserType == usertype).ToList();

        }

    }
}