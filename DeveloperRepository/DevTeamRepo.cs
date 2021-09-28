using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamRepo

{
    public class TeamContentRepo
    {
        public List<TeamContent> _listOfTeams = new List<TeamContent>();

        //Create
        public void AddTeamToList(TeamContent content)
        {
            _listOfTeams.Add(content);
        }

        //Read
        public List<TeamContent> GetTeamList()
        {
            return _listOfTeams;
        }

        //Update
        public bool UpdateExistingTeam(int origionalTeamNumber, TeamContent newContent)
        {
            TeamContent oldContent = GetTeamByTeamNumber(origionalTeamNumber);

            if (oldContent != null)
            {
                oldContent.TeamName = newContent.TeamName;
                oldContent.TeamNumber = newContent.TeamNumber;
                return true;
            }
            else
            {
                return false;
            }
        }

        //Delete
        public bool RemoveTeamFromList(int teamNumber)
        {
            TeamContent content = GetTeamByTeamNumber(teamNumber);

            if (content == null)
            {
                return false;
            }

            int intialCount = _listOfTeams.Count;
            _listOfTeams.Remove(content);

            if (intialCount > _listOfTeams.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        //Hamburger Helper
        public TeamContent GetTeamByTeamNumber(int teamNumber)
        {
            foreach (TeamContent content in _listOfTeams)
            {
                if (content.TeamNumber == teamNumber)
                {
                    return content;
                }
            }

            return null; 
        }
    }
}