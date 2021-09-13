using Code.Datas;
using Code.Player.Interface;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Controller
{
    public class PCBuildCommand
    {
        private Canvas _canvas;
        
        public void Initialization(ButtonData buttonData, IBuildNewCellCommand buildNewCellCommand)
        {
            _canvas = Object.FindObjectOfType<Canvas>();
            DefaultControls.Resources uiResources = new DefaultControls.Resources();
            
            uiResources.standard = buttonData.Sprite;
            GameObject uiButton = DefaultControls.CreateButton(uiResources);
            
            uiButton.GetComponent<Button>().onClick.AddListener(buildNewCellCommand.createNewCell);
            uiButton.GetComponentInChildren<Text>().text = buttonData.ButtonName;
            
            RectTransform b = uiButton.GetComponent<RectTransform>();
            b.sizeDelta = buttonData.Size;
            b.anchoredPosition = buttonData.Position;
            uiButton.transform.SetParent(_canvas.transform, false);
        }
    }
    
}