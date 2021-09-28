using DeveloperRepository;
using DevTeamRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoDataBase
{
    public class KomodoDataBase : KomodoDataBaseBase
    {

        public List<TeamContentRepo> _listOfTeams = new List<TeamContentRepo>();
        public List<DeveloperContentRepo> developers = new List<DeveloperContentRepo>();
    }
}
