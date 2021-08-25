using System.Collections.Generic;
using UnityEngine;

namespace Code.UnityExtentions
{
    public static class ListExtensions
    {
        public static void InitialiseListByZero(this List<int> list) 
        {
            for (int i = 0; i < list.Capacity; i++)
            {
                list.Add(0);
            }
        }
        public static void InitialiseListByZero(this List<float> list) 
        {
            for (int i = 0; i < list.Capacity; i++)
            {
                list.Add(0f);
            }
        }
        public static void InitialiseListByFalse(this List<bool> list) 
        {
            for (int i = 0; i < list.Capacity; i++)
            {
                list.Add(false);

            }
        }
        public static void InitialiseListByTrue(this List<bool> list) 
        {
            for (int i = 0; i < list.Capacity; i++)
            {
                list.Add(true);

            }
        }
    }


}