using System.Collections.Generic;
using Code.Datas;
using Code.GameLogicClasses.InputLogic;
using Code.Player.Factories;
using Code.Player.Interface;
using UnityEngine;

namespace Code.Controller
{
    public class SnakeConstructorCotroller
    {
        public SnakeConstructorCotroller(ButtonsData buttonsData, SectionsData sectionsData)
        {
            Dictionary<string, IBuildNewCellCommand> commandsByNameButton = new Dictionary<string, IBuildNewCellCommand>();
            foreach (var section in sectionsData.Sections)
            {
                if (section.SectionTypeData is SectionContainerData)
                {
                    SectionContainerData sectionData = section.SectionTypeData as SectionContainerData;
                    commandsByNameButton.Add(section.Name, new ContainerFactory(sectionData));
                }
            }
            foreach (var button in buttonsData.ButtonsInformation)
            {
                var buttonFactory = new PCBuildCommand();
                buttonFactory.Initialization(button, commandsByNameButton[button.ButtonName]);
            }
        }
    }
}