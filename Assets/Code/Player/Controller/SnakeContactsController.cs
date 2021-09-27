using System;
using System.Collections.Generic;
using Code.Interfaces;
using Code.Player.Interface;
using Code.Towns;
using UnityEngine;

namespace Code.Controller
{
    public class SnakeContactsController: MonoBehaviour, IInitialization
    {
        [SerializeField] private Dictionary<string, float> _materials;

        [SerializeField] private float _attack;
        [SerializeField] private float _health;
        
        private Controllers _controllers;
        
        public event Action<bool> _movePermission;

        
        private SnakeAttackController _snakeAttackController;
        private SnakeConstructorCotroller _snakeConstructorCotroller;
        private List<IDamageByTrainArmor> _listOfContact;


        private IFollower _myFollower;
        private bool _iHaveFollower;

        private Vector3 _placeToBuildSection;
        
        
        private float _speedOfAttack;
        public void Initialize(Controllers controllers, float attackForce, float health, float speedOfAttack)
        {
            _controllers = controllers;
            _listOfContact = new List<IDamageByTrainArmor>();

            _attack = attackForce;
            _health = health;

            _speedOfAttack = speedOfAttack;
            _iHaveFollower = false;

            Initialization();
            _placeToBuildSection = transform.position;
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

        public void AddNewMoveCommandToFollower(Vector2 move)
        {
            if (_iHaveFollower)
            {
                _myFollower.NewMoveCommand(move);
            }
        }

        public void ChangePlaceToBuildSection(Vector2 newPosition)
        {
            
        } 
        public void Initialization()
        {
            _snakeAttackController = new SnakeAttackController(_listOfContact, MoveSwitcher, _attack, 1 / _speedOfAttack );
            _controllers.Add(_snakeAttackController);
            _materials = new Dictionary<string, float>();
        }

        public void ConstructProject(IBuildNewCell buildOrder)
        {
            if (_iHaveFollower)
            {
                _myFollower.ConstructCommand(buildOrder);
            }
            else
            {
                _iHaveFollower = true;
                if (_placeToBuildSection != transform.position)
                    _myFollower = buildOrder.CreateNewCell(_placeToBuildSection);
            }
        }
    }
}