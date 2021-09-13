using System;
using System.Collections.Generic;
using Code.Interfaces;
using UnityEngine;

namespace Code.Controller
{
    public class SnakeAttackController: IExecute
    {
        private List<IDamageByTrainArmor> _listOfContact;
        
        private float _attackForce;
        private float _attackSpeed;

        private float _timeToNextAttack;
        private Action<bool> _moveSwitcher;

        private bool _movePermission = true;
        public SnakeAttackController(List<IDamageByTrainArmor> listOfContact, Action<bool> moveSwitch, float attackForce, float attackSpeed)
        {
            _listOfContact = listOfContact;

            _moveSwitcher = moveSwitch;
            
            _attackForce = attackForce;
            _attackSpeed = attackSpeed;
            _timeToNextAttack = 0f;
        }
        public void Execute(float deltaTime)
        {
            _timeToNextAttack -= deltaTime;
            if (_movePermission && _listOfContact.Count != 0)
            {
                Debug.Log("Frize! ");
                Debug.Log("Spd: " + _attackSpeed);
                Debug.Log("_timeToNextAttack: " + _timeToNextAttack);
                _movePermission = false;
                _moveSwitcher.Invoke(false);
            } 
            if (_listOfContact.Count == 0 && !_movePermission)
            {
                Debug.Log("Warm! ");
                _movePermission = true;
                _moveSwitcher.Invoke(true);
            }
            if (_timeToNextAttack <= 0f && _listOfContact.Count != 0)
            {
                
                _timeToNextAttack = _attackSpeed;
                foreach (var victim in _listOfContact)
                {
                    if (victim.Damage(_attackForce))
                    {
                        _listOfContact.Remove(victim);
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
                
            } 
        }
    }
}