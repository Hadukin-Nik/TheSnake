using System;
using System.Collections.Generic;
using Code.Datas;
using Code.Interfaces;
using Code.UnityExtentions;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Code.Towns
{
    public class CurrentTown : MonoBehaviour, IDamageByTrainArmor,IExecute
    {
        [SerializeField] private float _health = 0f;

        private IResourceHeapCreate _resourceHeap;

        private Action<CurrentTown> _somethigDestroyedTown;

        private Dictionary<string, float> _resourcesAfterDeath;
        
        private float _timeToDeath;
        public void InitializeTown(IResourceHeapCreate resourceHeap, Action<CurrentTown> somethigDestroyedTown, TownTypeData townTypeData, Vector2 myPlace, float timeToDeath, float health)
        {
            _resourceHeap = resourceHeap;
            _somethigDestroyedTown = somethigDestroyedTown;
            
            gameObject.transform.position = myPlace;

            _resourcesAfterDeath = new Dictionary<string, float>();

            foreach (var resource in townTypeData.PropertiesOfTown)
            {
                _resourcesAfterDeath.Add(resource.NameOfBonus, Random.Range(resource.RandomBorders.left, resource.RandomBorders.right));
            }
            Debug.Log("Resources: " + _resourcesAfterDeath.Count);
            _health = health;
            _timeToDeath = timeToDeath;
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
                _somethigDestroyedTown?.Invoke(this);

                _resourceHeap.CreateResouceHeap(_resourcesAfterDeath, gameObject.transform.position);
                Destroy(gameObject);
            }
        }
    }


}