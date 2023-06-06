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
        { "date", "" },
        { "driver", "" },
        { "speedMor", "" },
        { "speedEv", "" },
        { "fuel", "" },
        { "shift", ""},

        { "dir1", "" },
        { "prod1", "" },
        { "am1", "" },

        { "dir2", "" },
        { "prod2", "" },
        { "am2", "" },

        { "dir3", "" },
        { "prod3", "" },
        { "am3", "" },

        { "dir4", "" },
        { "prod4", "" },
        { "am4", "" },

        { "dir5", "" },
        { "prod5", "" },
        { "am5", "" },

        { "dir6", "" },
        { "prod6", "" },
        { "am6", "" },

        { "dir7", "" },
        { "prod7", "" },
        { "am7", "" },

        { "dir8", "" },
        { "prod8", "" },
        { "am8", "" },
        };
        docRef.SetAsync(city, SetOptions.MergeAll);
    }

    private void OnDestroy()
    {
        _firebaseFirestore.TerminateAsync();
        _firebaseFirestore.ClearPersistenceAsync();
    }
}
