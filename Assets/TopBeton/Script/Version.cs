using Firebase.Extensions;
using Firebase.Firestore;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Version : MonoBehaviour
{
    [SerializeField] private GameObject _newUpdatePanel;
    private FirebaseFirestore _firebaseFirestore;
    private readonly string _version = "01";
    public void Initialize(IFirestoreHolder firestoreHolder)
    {
        _firebaseFirestore = firestoreHolder.GetFirestore();
    }

    public void Check()
    {
        if (InternetConnection.Check() != false)
        {
            DocumentReference documentReference = _firebaseFirestore.Collection("waybills").Document("verison");
            documentReference.GetSnapshotAsync().ContinueWithOnMainThread(task =>
            {
                DocumentSnapshot snapshot = task.Result;
                if (snapshot.Exists)
                {
                    Dictionary<string, object> dictionary = snapshot.ToDictionary();
                    string version = dictionary["current"].ToString();
                    Debug.Log(_version);
                    Debug.Log(version);

                    if (!_version.Equals(version))
                    {
                        _newUpdatePanel.SetActive(true);
                    }
                }
                else
                {
                    Debug.Log(string.Format("Document {0} does not exist!", snapshot.Id));
                }
            });
        }
    }
}
