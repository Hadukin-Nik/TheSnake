using Code.Datas;
using Code.Interfaces;
using UnityEngine;

namespace Code.Controller
{
    internal sealed class GameInitialization
    {
        public GameInitialization(Controllers controllers, MainData mainData)
        {
            Camera camera = Camera.main;
            var inputInitialization = new InputInitialization();
            var mainHeadSnakeFactory = new MainHeadSnakeFactory(mainData.Snake);
            var playerInitialization = new PlayerInitialization(mainHeadSnakeFactory, mainData.Snake.StartPosition);
            ITownsMainInformation townsMainInformationInitization = new MainDataTownsInitialization(mainData.Towns);
            
        }
        
    }
}