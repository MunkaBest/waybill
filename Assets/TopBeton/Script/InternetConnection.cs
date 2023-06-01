using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InternetConnection : MonoBehaviour
{
    public static bool Check()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
