using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI
{
    public static class Helper
    {
        public static string GetConnectionString(string name)
        {
            return "server=(localdb)\\MSSQLLocalDB;database=NonFungibleDB;Integrated Security=true";
        }
    }
}
