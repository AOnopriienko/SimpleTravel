using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleTravel_API
{
    public class Contact
    {
        public string name;
        public string secondName;
        public Sex sex;
        public int age;
        public long numberId;
    }

    public enum Sex {
        Male, 
        Female
    }
}