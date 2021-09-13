using Code.Datas;
using Code.Interfaces;
using Code.Towns;
using UnityEngine;

namespace Code.Controller
{
    internal sealed class GameInitialization
    {
        public GameInitialization(Controllers controllers, MainData mainData, SaveController saveController)
        {
            Camera camera = Camera.main;
            var inputInitialization = new InputInitialization();
            
            Transform snake;
            
            var tryFindSnake = Object.FindObjectOfType<SnakeContactsController>();
            
            if (tryFindSnake != null)
            {
                snake = tryFindSnake.transform;
            }
            else
            {
                var mainHeadSnakeFactory = new MainHeadSnakeFactory(mainData.Snake, controllers);
                var playerInitialization = new PlayerInitialization(mainHeadSnakeFactory, mainData.Snake.StartPosition);

                snake = playerInitialization.GetPlayer();
            }
            ITownsMainInformation townsMainInformationInitization = new MainDataTownsInitialization(mainData.Towns);
            
            controllers.Add(new InputController(inputInitialization.GetInput()));
            controllers.Add(new MoveController(inputInitialization.GetInputForMovementOnly(), 
                snake, mainData.Snake));
            new SnakeConstructorCotroller(mainData.Buttons, mainData.Sections);
            var map = new GameMapInitialization(mainData.SizeOfLevel, mainData.SizeOfCell);
            controllers.Add(new TownsController(controllers, townsMainInformationInitization.GetListOfTownsOnLevel(), map.createMapOfTypeT(false),
                mainData.SizeOfCell, mainData.SpeedOfTownsAppearing, mainData.MaxCountOfTownsOnLevel));
            controllers.Add(saveController);
            saveController.ButtonInitialization(inputInitialization.GetInputForSavesOnly());
            controllers.Initialization();
        }
        
    }
}