using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Code.Savers
{
    [Serializable]
    public sealed class SavedData
    {
        public string Name;

        public Vector2Serializable PlayerPosition;

        public TownsOnLoadSerializable TownsOnScene;

        public override string ToString()
        {
            return $"Name {Name}, Snake position: {PlayerPosition}, TownsPositions: {TownsOnScene}";
        }
    }

    [Serializable]
    public struct Vector2Serializable
    {
        public float X;
        public float Y;

        private Vector2Serializable(float valueX, float valueY)
        {
            X = valueX;
            Y = valueY;
        }

        public static implicit operator Vector2(Vector2Serializable value)
        {
            return new Vector2(value.X, value.Y);
        }

        public static implicit operator Vector2Serializable(Vector2 value)
        {
            return new Vector2Serializable(value.x, value.y);
        }

        public override string ToString()
        {
            return $"(X = {X}, Y = {Y})";
        }
    }

    [Serializable]
    public struct TownOnLoadSerializable
    {
        public string TownType;
        public Vector2Serializable TownPlace;

        private TownOnLoadSerializable(string valueType, Vector2Serializable placeValue)
        {
            TownType = valueType;
            TownPlace = placeValue;
        }

        public static implicit operator TownOnLoadData(TownOnLoadSerializable value)
        {
            return new TownOnLoadData(value.TownType, value.TownPlace);
        }
        
        public static implicit operator TownOnLoadSerializable(TownOnLoadData value)
        {
               
            return new TownOnLoadSerializable(value.TownType, (Vector2Serializable)value.PlaceOfTown);
        }
        
        public override string ToString() => $"TownType: {TownType}, TownPlace: {TownPlace.ToString()}\n";
    }

    [Serializable]
    public struct TownsOnLoadSerializable
    {
        public List<TownOnLoadData> TownsOnScene;
        
        private TownsOnLoadSerializable(List<TownOnLoadData> townsOnScene)
        {
            TownsOnScene = new List<TownOnLoadData>(townsOnScene.Count);

            foreach (var town in townsOnScene)
            {
                TownsOnScene.Add(town);
            }
        }

        public static implicit operator List<TownOnLoadData>(TownsOnLoadSerializable townsOnLoadSerializable)
        {
            var result = new List<TownOnLoadData>(townsOnLoadSerializable.TownsOnScene.Count);

            foreach (var townSerialized in townsOnLoadSerializable.TownsOnScene)
            {
                result.Add(townSerialized);
            }

            return result;
        }

        public static implicit operator TownsOnLoadSerializable(List<TownOnLoadData> townsOnLoadDatas)
        {
            return new TownsOnLoadSerializable(townsOnLoadDatas);
        }

        public override string ToString()
        {
            string result = "";
            var stringBuilder = new StringBuilder();
            foreach (var serializedTown in TownsOnScene)
            {
                stringBuilder.Append(serializedTown.ToString());
            }

            result = stringBuilder.ToString();
            return $"List of towns: {result}";
        }
    }
}
