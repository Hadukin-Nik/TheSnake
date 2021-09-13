using UnityEngine;

namespace Code.Savers
{
    public sealed class TownOnLoadData
    {
        public string TownType;
        public Vector2 PlaceOfTown;

        public TownOnLoadData(string townType, Vector2 placeOfTown)
        {
            TownType = townType;
            PlaceOfTown = placeOfTown;
        }
    }
}