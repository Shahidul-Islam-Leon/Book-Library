using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.Models.Repository
{
    public class UserRepository : Repository<User>
    {
        public User GetUserByUsername(string username)
        {

            return this.GetALLData().Where(x => x.Username == username).FirstOrDefault();

        }
        public User GetUserByUsernameAndPassword(string username,string password)
        {

            return this.GetALLData().Where(x => x.Username == username && x.Password==password).FirstOrDefault();

        }

    }
}