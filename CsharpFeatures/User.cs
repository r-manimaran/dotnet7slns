using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpFeatures
{
    public class User
    {
        //public User(string username,int age) {
        //    Name= username;
        //    Age = age;
        //}

        // using Expression Body Constructor
        public User(string username, int age)=>
            (Name,Age)=(username,age);
        public string Name { get; }
        public int Age { get; }
    }
}
