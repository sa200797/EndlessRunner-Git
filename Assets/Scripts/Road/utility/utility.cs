using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace utilitys
{
    public static class utility
    {
        public static void Move<T>(this List<T> list, int oldIndex, int newIndex)
        {
            var item = list[oldIndex];

            list.RemoveAt(oldIndex);

            if (newIndex > oldIndex) newIndex--;
            // the actual index could have shifted due to the removal

            list.Insert(newIndex, item);
        }       
    }
}
