using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamRepo
{
    //Some more Pocos
    public class TeamContent
    {
        public string TeamName { get; set; }
        public int TeamNumber { get; set; }
        public int[] TeamMembers { get; set; }



        //Empty boy 
        public TeamContent() { }

        //Populated contrustor 
        public TeamContent(int teamNumber, string teamName, int[] teamMembers)
        {
            TeamNumber = teamNumber;
            TeamName = teamName;
            TeamMembers = teamMembers;
        }

    }
}

