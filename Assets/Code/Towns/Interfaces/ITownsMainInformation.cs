using System.Collections.Generic;
using Code.Controller;

namespace Code.Interfaces
{
    public interface ITownsMainInformation
    {
        public List<MainDataTownsInitialization.TownsContainers> GetListOfTownsOnLevel();
    }
}