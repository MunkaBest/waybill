using Firebase.Database;
using Firebase.Extensions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CetListCreator : MonoBehaviour
{
    void Start()
    {
        FirebaseDatabase.DefaultInstance
       .GetReference("CarList")
       .GetValueAsync().ContinueWithOnMainThread(task =>
       {
           if (task.IsFaulted)
           {
               Debug.Log(task);
           }
           else if (task.IsCompleted)
           {
               DataSnapshot snapshot = task.Result;
               Debug.Log(snapshot.GetRawJsonValue());
           }
       });
    }

}
