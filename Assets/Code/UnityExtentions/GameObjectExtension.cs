﻿using UnityEngine;

namespace Code.UnityExtentions
{
    public static class GameObjectExtension
    {
        // TrulyThieved
        public static GameObject SetName(this GameObject gameObject, string name)
        {
            gameObject.name = name;
            return gameObject;
        }

        public static GameObject AddRigidbody2D(this GameObject gameObject, float mass)
        {
            var component = gameObject.GetOrAddComponent<Rigidbody2D>();
            component.isKinematic = false;
            component.gravityScale = 0f;
            return gameObject;
        }

        public static GameObject AddBoxCollider2D(this GameObject gameObject)
        {
            gameObject.GetOrAddComponent<BoxCollider2D>();
            return gameObject;
        }

        public static GameObject AddCircleCollider2D(this GameObject gameObject, float radius)
        {
            gameObject.GetOrAddComponent<CircleCollider2D>();
            gameObject.GetComponent<CircleCollider2D>().radius = radius;
            return gameObject;
        }
        


        public static GameObject AddSprite(this GameObject gameObject, Sprite sprite)
        {
            var component = gameObject.GetOrAddComponent<SpriteRenderer>();
            component.sprite = sprite;
            return gameObject;
        }
        public static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component
        {
            var result = gameObject.GetComponent<T>();
            if (!result)
            {
                result = gameObject.AddComponent<T>();
            }

            return result;
        }
    }
}