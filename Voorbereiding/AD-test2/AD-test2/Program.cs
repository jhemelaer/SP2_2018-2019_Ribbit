﻿//Bronnen: https://www.youtube.com/watch?v=9iRs71ovZ_U&t=64s,
//https://myjeeva.com/querying-active-directory-using-csharp.html#blog
// https://stackoverflow.com/questions/1091115/active-directory-display-all-properties-in-a-table
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

        string GN;
        string WWUser;

        public void queryAD()
        {
            string Gebruikersnaam = "admin1";
            string Wachtwoord = "Rej47!";
            string domein = "10.3.50.7";
            string gb = "malke.boulanger"; // gebruikersnaam van te vinden user
            string ww = "Puc55!"; // wachtwoord van te vinden user

            SearchResult rs = null;

            rs = searchUser(GetDirectorySearcher(Gebruikersnaam, Wachtwoord, domein), gb);

            if (rs != null)
            {
                Console.WriteLine("Er werd een gebruiker met deze gegevens gevonden");
            }
        }

        private DirectorySearcher GetDirectorySearcher(string gebruikersnaam, string wachtwoord, string domein)
        {
            DirectoryEntry de = new DirectoryEntry("LDAP://" + domein, gebruikersnaam, wachtwoord);

            de.RefreshCache();
            if (dirSearch == null)
            {
                try
                {
                    // De klasse DirectorySearcher zal de query's uitvoeren.
                    //Het object zal gereturned worden om nadien gebruikt te worden in de searchBy-methode.
                    dirSearch = new DirectorySearcher(de);
                }
                catch (DirectoryServicesCOMException e)
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
            ds.Filter = "(&((&(objectCategory=CN=Person,CN=Schema,CN=Configuration,DC=ehbstudent,DC=local)(objectClass=user)))(samaccountname=" + Gebruikersnaam + "))";

            ds.SearchScope = SearchScope.Subtree;
            ds.ServerTimeLimit = TimeSpan.FromSeconds(90);
            SearchResult userObject = ds.FindOne();

            if (userObject != null)
            {
                Console.WriteLine("Er werd een user gevonden!");
                GN = userObject.GetDirectoryEntry().Name;
                // WWUser = userObject.GetDirectoryEntry();
                return userObject;
            }
            else
            {
                return null;
            }
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            program.queryAD();
        }

       
    }
}