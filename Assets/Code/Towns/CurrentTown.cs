using System;
using System.Collections.Generic;
using Code.Controller;
using Code.Datas;
using Code.Interfaces;
using Code.UnityExtentions;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Code.Towns
{
    public class CurrentTown : MonoBehaviour, IDamageByTrainArmor, IExecute, ISaveable, ICleanup
    {
        [SerializeField] private float _health = 0f;

        private GameObject _gameObject;
        
        private Controllers _controller;
        private IResourceHeapCreate _resourceHeap;

        private Action<CurrentTown> _somethigDestroyedTown;
        
        private Dictionary<string, float> _resourcesAfterDeath;
        
        private float _timeToDeath;
        private string _getYourType;

        public void InitializeTown( Controllers controller, IResourceHeapCreate resourceHeap, TownTypeData townTypeData, Vector2 myPlace, string nameOfMyType, float timeToDeath, float health)
        {
            _controller = controller;
            _controller.Add(this);
            
            _resourceHeap = resourceHeap;

            gameObject.transform.position = myPlace;

            _resourcesAfterDeath = new Dictionary<string, float>();

            foreach (var resource in townTypeData.PropertiesOfTown)
            {
                _resourcesAfterDeath.Add(resource.NameOfBonus, Random.Range(resource.RandomBorders.left, resource.RandomBorders.right));
            }
            Debug.Log("Resources: " + _resourcesAfterDeath.Count);
            _health = health;
            _timeToDeath = timeToDeath;

            _getYourType = nameOfMyType;
            _gameObject = gameObject;
        }
        
        public bool Damage(float damage)
        {
            Debug.Log("Damage! " + damage);
            Debug.Log("My health now! " + _health);
            _health -= damage;
            if (_health <= 0)
            {
                return true;
            }

            return false;
        }


        public void Execute(float deltaTime)
        {
            if (_health <= 0f)
            {
                _timeToDeath -= deltaTime;
            }
            
            if (_timeToDeath <= 0f)
            {
                _resourceHeap.CreateResouceHeap(_resourcesAfterDeath, gameObject.transform.position);
                Cleanup();
            }
        }

        public Vector3 MyPosition => transform.position;
        string ISaveable.GetYourType => _getYourType;
        public void Cleanup()
        {
            _controller.Delete(this);
            Destroy(gameObject);
        }
    }


}