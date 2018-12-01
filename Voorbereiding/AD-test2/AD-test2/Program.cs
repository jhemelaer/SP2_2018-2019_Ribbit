//Bronnen: https://www.youtube.com/watch?v=9iRs71ovZ_U&t=64s,
//https://myjeeva.com/querying-active-directory-using-csharp.html#blog
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.DirectoryServices;

namespace AD_test2
{
    class Program
    {
        // Nodig voor het uitvoeren van de query's
        public DirectorySearcher dirSearch = null;
        static void Main(string[] args)
        {
            //   //Creating a directory entry object by passing LDAP address
            //       string ldapadres = "LDAP://10.3.50.7";
            //     string gebruikersnaam = "admin1";
            //   string wachtwoord = "Rej47!";
            //       string searchBaseStudenten = "ou= gebruikers, ou = studenten";
            //     string searchBaseDocenten = "ou= gebruikers, ou = personeel";
            //   DirectoryEntry de = new DirectoryEntry(ldapadres, gebruikersnaam, wachtwoord);
            // DirectorySearcher ds = new DirectorySearcher(de);
            // ds.SearchScope = SearchScope.Subtree;
        }

       public void queryAD()
        {
            string Gebruikersnaam = "malke.boulanger";
            string Wachtwoord = "Puc55!";
            string domein = "ehbstudent.local";

            SearchResult rs = null;

            rs = searchUser(GetDirectorySearcher(Gebruikersnaam, Wachtwoord, domein), txtSearchUser.Text.Trim());
        }

        private DirectorySearcher GetDirectory(string gebruikersnaam, string wachtwoord, string domein)
        {
            if(dirSearch == null)
            {
                try
                {
                    // De klasse DirectorySearcher zal de query's uitvoeren.
                    //Het object zal gereturned worden om nadien gebruikt te worden in de searchBy-methode.
                    dirSearch = new DirectorySearcher(new DirectoryEntry("LDAP://" + domein + gebruikersnaam + wachtwoord));
                }
                catch(DirectoryServicesCOMException e)
                {
                    Console.WriteLine("Er is iets verkeerd gelopen bij het maken van de verbinding: " + e.Message.ToString()); //Vervangen door Debug.Log
                }
                return dirSearch;
            }
            else
            {
                return dirSearch;
            }
        }

        private SearchResult searchUser(DirectorySearcher ds, string Gebruikersnaam)
        {
            ds.Filter = "(&((&(objectCategory=gebruikers)(objectClass=studenten)))(samaccountname=" + Gebruikersnaam + "))";

            ds.SearchScope = SearchScope.Subtree;
            ds.ServerTimeLimit = TimeSpan.FromSeconds(90);

            SearchResult userObject = ds.FindOne();

            if(userObject != null)
            {
                return userObject;
            }
            else
            {
                return null;
            }
        }
    }
}
