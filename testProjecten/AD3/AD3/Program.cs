using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;

namespace AD3
{
    class Program
    {
        bool flag = false;

        public static void logOn()
        {
            try
            {
                string UN = "malke.boulanger";
                string WW = "Puc55!";
                bool flag = false;

                using (PrincipalContext principalContext = new PrincipalContext(ContextType.Domain))
                {
                    flag = principalContext.ValidateCredentials(UN, WW);
                    if(flag == true)
                    {
                        Console.WriteLine("Ingelogd");
                    }
                    else
                    {
                        Console.WriteLine("Niet ingelogd");
                    }
                }
            }
            catch (PrincipalServerDownException)
            {
               
            }
        }

        public static void Main(string[] args)
        {
            logOn();
        }
    }
}
