using Code.Datas;
using Code.Interfaces;
using Code.Towns;
using UnityEngine;

namespace Code.Controller
{
    internal sealed class GameInitialization
    {
        public GameInitialization(Controllers controllers, MainData mainData)
        {
            Debug.Log("Started");
            Camera camera = Camera.main;
            var inputInitialization = new InputInitialization();
            var mainHeadSnakeFactory = new MainHeadSnakeFactory(mainData.Snake);
            // Debug.Log(mainHeadSnakeFactory == null);
            Debug.Log(mainData.Snake.StartPosition);
            var playerInitialization = new PlayerInitialization(mainHeadSnakeFactory, mainData.Snake.StartPosition);
            ITownsMainInformation townsMainInformationInitization = new MainDataTownsInitialization(mainData.Towns);
            controllers.Add(new InputController(inputInitialization.GetInput()));
            controllers.Add(new MoveController(inputInitialization.GetInput(), 
                playerInitialization.GetPlayer(), mainData.Snake));
            controllers.Add(new TownsController(townsMainInformationInitization.GetListOfTownsOnLevel(),
                mainData.SizeOfLevel, mainData.SizeOfCell, mainData.SpeedOfTownsAppearing));
        }
        
    }
}