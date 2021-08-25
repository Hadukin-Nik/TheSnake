using System;
using System.Collections.Generic;
using Code.Interfaces;
using Code.Towns;
using UnityEngine;

namespace Code.Controller
{
    public class SnakeContactsController: MonoBehaviour
    {
        [SerializeField] private Dictionary<string, float> _materials;

        [SerializeField] private float _attack;
        [SerializeField] private float _health;

        private Controllers _controllers;
        
        private SnakeAttackController _snakeAttackController;
        private List<IDamageByTrainArmor> _listOfContact;
        public event Action<bool> _movePermission;

        public void Initialise(Controllers controllers, float attackForce, float health, float speedOfAttack)
        {
            _controllers = controllers;
            _listOfContact = new List<IDamageByTrainArmor>();

            _attack = attackForce;
            _health = health;
            
            _snakeAttackController = new SnakeAttackController(_listOfContact, MoveSwitcher, _attack, 1 / speedOfAttack );

            _controllers.Add(_snakeAttackController);
            _materials = new Dictionary<string, float>();
        }
        
        public void OnCollisionEnter2D(Collision2D other)
        {
            Debug.Log("We have a contact!");
            if (other.gameObject.TryGetComponent(out CurrentTown town))
            {
                Debug.Log("Victim finded!");
                
                _listOfContact.Add(town); 
            }

            if (other.gameObject.TryGetComponent(out ResourceHeapAfterDeath materials))
            {
                Debug.Log("Resources finded! " + materials.resources.Count);
                foreach (var a in materials.resources)
                {
                    _materials.Add(a.Key, a.Value);
                }
                Debug.Log("Resources added!");
                Destroy(other.gameObject);
                
                
            }
        }

        private void MoveSwitcher(bool permission)
        {
            _movePermission?.Invoke(permission);
        }
    }
}