using System;
using Code.Interfaces;
using UnityEngine;

namespace Code.Towns
{
    public class CurrentTown : MonoBehaviour, IDamage
    {
        [SerializeField] private float health = 0f;
        public void InitializeTown(Vector2 myPlace)
        {
            gameObject.transform.position = myPlace;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            Debug.Log("Hey! You touched me!");
        }

        public void Damage(float damage)
        {
            health -= damage;
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }


}