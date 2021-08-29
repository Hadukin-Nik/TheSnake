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
            var mainHeadSnakeFactory = new MainHeadSnakeFactory(mainData.Snake, controllers);
            var playerInitialization = new PlayerInitialization(mainHeadSnakeFactory, mainData.Snake.StartPosition);

            var player = playerInitialization.GetPlayer();
            
            ITownsMainInformation townsMainInformationInitization = new MainDataTownsInitialization(mainData.Towns);
            
            controllers.Add(new InputController(inputInitialization.GetInput()));
            controllers.Add(new MoveController(inputInitialization.GetInputForMovementOnly(), 
                player, mainData.Snake));
            
            var map = new GameMapInitialization(mainData.SizeOfLevel, mainData.SizeOfCell);
            controllers.Add(new TownsController(controllers, townsMainInformationInitization.GetListOfTownsOnLevel(), map.createMapOfTypeT(false),
                mainData.SizeOfCell, mainData.SpeedOfTownsAppearing, mainData.MaxCountOfTownsOnLevel));

            controllers.Add(new SaveController(inputInitialization.GetInputForSavesOnly(),
                player.GetComponent<SnakeContactsController>()));
        }
        
    }
}