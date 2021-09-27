using System;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Experimental
{
    public class Button : MonoBehaviour
    {
        [SerializeField] private Canvas canvas;
        [SerializeField] private Sprite someBgSprite;
        [SerializeField] private Vector3 scale;
        [SerializeField] private Vector3 position;

        private Button1 a;
        public void Start()
        {
            // a = new Button1(canvas, someBgSprite, scale, position);
        }

        
        
    }
    public class Button1
    {
        public Button1(Canvas canvas, Sprite someBgSprite, Vector3 scale, Vector3 position)
        {
            DefaultControls.Resources uiResources = new DefaultControls.Resources();
            //Set the Button Background Image someBgSprite;
            uiResources.standard = someBgSprite;
            GameObject uiButton = DefaultControls.CreateButton(uiResources);
            Debug.Log(canvas.transform);

            var b = uiButton.GetComponent<RectTransform>();
            b.sizeDelta = scale;
            b.anchoredPosition = position;
            uiButton.transform.SetParent(canvas.transform, false);
            
        }
    }
}