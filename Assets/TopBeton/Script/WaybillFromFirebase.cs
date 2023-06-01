using Firebase.Extensions;
using Firebase.Firestore;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaybillFromFirebase : MonoBehaviour
{
    public void GetList(DocumentReference documentReference)
    {
        documentReference.GetSnapshotAsync().ContinueWithOnMainThread(task =>
        {
            DocumentSnapshot snapshot = task.Result;
            if (snapshot.Exists)
            {
                Dictionary<string, object> cars = snapshot.ToDictionary();
                foreach (KeyValuePair<string, object> car in cars)
                {
                    Debug.Log(String.Format("{0}: {1}", car.Key, car.Value));
                }
            }
            else
            {
                Debug.Log(string.Format("Document {0} does not exist!", snapshot.Id));
            }
        });
    }
}