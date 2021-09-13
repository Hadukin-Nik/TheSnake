using System.ComponentModel;
using Code.Controller;
using Code.Datas;
using Code.Player.Interface;
using Code.UnityExtentions;
using UnityEngine;

namespace Code.Player.Factories
{
    public class ContainerFactory: IBuildNewCellCommand, IBuildNewCell
    {
        public float _addableStorage;
        private readonly SnakeContactsController _snakeContactsController;
        private readonly SectionContainerData _sectionContainerData;
        
        public ContainerFactory(SectionContainerData sectionContainerData)
        {
            _snakeContactsController = Object.FindObjectOfType<SnakeContactsController>();
            _sectionContainerData = sectionContainerData;
        }
        
        public void createNewCell()
        {
            _snakeContactsController.ConstructProject(this);
        }

        public IFollower CreateNewCell(Vector2 myPosition)
        {
            GameObject cell = new GameObject(_sectionContainerData.name).AddSprite(_sectionContainerData.Sprite)
                .AddRigidbody2D(0.0f).AddCircleCollider2D(_sectionContainerData.Radius);
            Cell myLittleMonoBehaviour = cell.GetOrAddComponent<Cell>();
            myLittleMonoBehaviour.Initialize();
            cell.transform.position = myPosition;
            return myLittleMonoBehaviour;
        }
    }
}