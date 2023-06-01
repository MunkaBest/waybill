using Firebase.Extensions;
using Firebase.Firestore;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirebaseUnit : MonoBehaviour, IFirestoreHolder
{
    private FirebaseFirestore _firebaseFirestore;
    public event Action<FirebaseFirestore> OnLoaded;
    public void Initialize()
    {
        _firebaseFirestore = FirebaseFirestore.DefaultInstance;
        _firebaseFirestore.Settings.PersistenceEnabled = false;
        Debug.Log(string.Format("FirebaseFirestore has instanced!"));
        OnLoaded?.Invoke(_firebaseFirestore);
        /*
        Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            var dependencyStatus = task.Result;
            if (dependencyStatus == Firebase.DependencyStatus.Available)
            {
                _firebaseFirestore = FirebaseFirestore.DefaultInstance;
                _firebaseFirestore.Settings.PersistenceEnabled = false;
                Debug.Log(string.Format("FirebaseFirestore has instanced!"));
                OnLoaded?.Invoke(_firebaseFirestore);
            }
        });
        */
    }

    public FirebaseFirestore GetFirestore()
    {
        return _firebaseFirestore;
    }

    public void AddDocument(string name)
    {
        DocumentReference docRef = _firebaseFirestore.Collection("waybills").Document(name);
        Dictionary<string, object> city = new Dictionary<string, object>
        {
        { "date", "01.01.2023" },
        { "driver", "—ергеев —ергей —ергеевич" },
        { "speedMor", "0" },
        { "speedEv", "0" },
        { "fuel", "0" },
        { "shift", "open"},

        { "dir1", "база" },
        { "prod1", "песок" },
        { "am1", "0" },

        { "dir2", "база" },
        { "prod2", "песок" },
        { "am2", "0" },

        { "dir3", "база" },
        { "prod3", "песок" },
        { "am3", "0" },

        { "dir4", "база" },
        { "prod4", "песок" },
        { "am4", "0" },

        { "dir5", "база" },
        { "prod5", "песок" },
        { "am5", "0" },

        { "dir6", "база" },
        { "prod6", "песок" },
        { "am6", "0" },

        { "dir7", "база" },
        { "prod7", "песок" },
        { "am7", "0" },

        { "dir8", "база" },
        { "prod8", "песок" },
        { "am8", "0" },
        };
        docRef.SetAsync(city, SetOptions.MergeAll);
    }

    private void OnDestroy()
    {
        _firebaseFirestore.TerminateAsync();
        _firebaseFirestore.ClearPersistenceAsync();
    }
}
