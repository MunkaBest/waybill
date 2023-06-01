using Firebase.Extensions;
using Firebase.Firestore;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarListFromFirebase : MonoBehaviour, ICarsHolder
{
    public event Action<Dictionary<string, object>> OnReceived;
    public void GetList(IFirestoreHolder firestoreHolder)
    {
        SetDocument(firestoreHolder.GetFirestore());
    }

    private void SetDocument(FirebaseFirestore firebaseFirestore)
    {
        DocumentReference documentReference = firebaseFirestore.Collection("waybills").Document("cars");
        documentReference.GetSnapshotAsync().ContinueWithOnMainThread(task =>
        {
            DocumentSnapshot snapshot = task.Result;
            if (snapshot.Exists)
            {
                Debug.Log(string.Format("Document data for {0} document:", snapshot.Id));
                Dictionary<string, object> cars = snapshot.ToDictionary();
                OnReceived?.Invoke(cars);
            }
            else
            {
                Debug.Log(string.Format("Document {0} does not exist!", snapshot.Id));
            }
        });
    }

    private void OnDisable()
    {
      
    }

}
