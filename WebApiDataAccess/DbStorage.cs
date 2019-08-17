using System;
using System.Collections.Generic;
using System.Text;
using WebApiDomain;

namespace WebApiDataAccess
{
    public static class DbStorage
    {
        public static List<User> Users()
        {
            return new List<User>
            {
                new User(){Id=1,FirstName = "Jovan",LastName="Panovski",Age=32},
                new User(){Id=2,FirstName = "Verica",LastName="Stojanovska",Age=23},
                new User(){Id=3,FirstName = "Lidija",LastName="Grkovska",Age=34},
                new User(){Id=4,FirstName = "Milan",LastName="Pavlov",Age=27}

            };
        }
    }
}
