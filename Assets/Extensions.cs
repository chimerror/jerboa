using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public static class Extensions
{
    public static void Shuffle<T>(this IList<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = GameManager.Instance.Random.Next(n + 1);
            T temp = list[k];
            list[k] = list[n];
            list[n] = temp;
        }
    }
}
