using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    //Access Level 
    public enum AccessLevel
    {
        User = 1,           // just the basics
        Manager = 2,        // View/create/update up to team
        Admin = 3,          // all access  
        SuperAdmin = 4      // all access
    }

    // Poco's
    public class DeveloperContent
    {
        
        public int IDNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string ID { get; set; }
        public string Password { get; set; }
        public bool PluralsightAccess { get; set; }
        //empty boy 
        public DeveloperContent() { }

        // Populated constructor
        public DeveloperContent(int idNumber, string firstName, string lastName, string fullName, string id, string password, bool pluralsightAccess)
        {
            IDNumber = idNumber;
            FirstName = firstName;
            LastName = lastName;
            FullName = fullName;
            ID = id;
            Password = password;
            PluralsightAccess = pluralsightAccess;

        }
    }
}
