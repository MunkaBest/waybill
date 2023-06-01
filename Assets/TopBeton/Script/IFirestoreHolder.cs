using Firebase.Firestore;
using System;

public interface IFirestoreHolder
{
    public FirebaseFirestore GetFirestore();
}