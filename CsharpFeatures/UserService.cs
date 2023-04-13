using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpFeatures
{
    public class UserService
    {
        private readonly IConfiguration _configuration;

        public UserService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        /// <summary>
        /// Return Emumerable Empty instead of null
        /// </summary>
        /// <returns></returns>
        public IEnumerable<User> GetUsers()
        {
            List<User> users = new List<User>();
            if (NoUserFoundInDB())
            {
                return Enumerable.Empty<User>();
            }

            return users;
        }

        private bool NoUserFoundInDB()
        {
            return false;
        }
    }
}
