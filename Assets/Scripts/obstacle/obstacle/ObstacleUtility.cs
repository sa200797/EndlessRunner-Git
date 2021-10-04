using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ObstacleUtility 
{
    public static void SetAllCollidersStatus(bool active)
    {
       
    }
    public static bool HasComponent<T>(this GameObject flag) where T : Component
    {
        return flag.GetComponent<T>() != null;
    }

   


}
