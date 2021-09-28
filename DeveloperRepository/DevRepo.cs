using DevTeamsProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperRepository
{
    public class DeveloperContentRepo
    {
        public List<DeveloperContent> _listOfDevelopers = new List<DeveloperContent>();

        //Create
        public void AddDeveloperToList(DeveloperContent content)
        {
            _listOfDevelopers.Add(content);
        }

        //Read
        public List<DeveloperContent> GetPeopleList()
        {
            return _listOfDevelopers;
        }

        //Update
        public bool UpdateExistingPeople(int originalIdNumber, DeveloperContent newContent)
        {
            // Find the dev
            DeveloperContent oldContent = GetPeopleByIdNumber(originalIdNumber);
            // Update the content
            if (oldContent != null)
            {
                // EMPTY THING


                return true;
            }
            else
            {
                return false;
            }
        }

        //Delete
        public bool RemoveContentFromList(int idNumber)
        {
            DeveloperContent content = GetPeopleByIdNumber(idNumber);

            if (content == null)
            {
                return false;
            }

            int intialCount = _listOfDevelopers.Count;
            _listOfDevelopers.Remove(content);

            if (intialCount > _listOfDevelopers.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Hamburger Helpers
        public DeveloperContent GetPeopleById(string id)
        {
            foreach (DeveloperContent content in _listOfDevelopers)
            {
                if (content.ID.ToLower() == id.ToLower())
                {
                    return content;
                }
            }

            return null;
        }

        public DeveloperContent GetPeopleByIdNumber(int idNumber)
        {
            foreach (DeveloperContent content in _listOfDevelopers)
            {
                if (content.IDNumber == idNumber)
                {
                    return content;
                }
            }

            return null;
        }
    }
}



