using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Firestore;
using Firebase.Extensions;

public class Login : MonoBehaviour
{
    [SerializeField] private string _text;
    [SerializeField] private InputField _inputField;
    [SerializeField] private LevelManager _levelManager;
    private FirebaseFirestore _firebaseFirestore;
    private string _password;
    private Scene _scene;

    public void Initialize(IFirestoreHolder firestoreHolder, Scene scene)
    {
        _scene = scene;
        _password = PlayerPrefs.GetString("code", "0");
        _firebaseFirestore = firestoreHolder.GetFirestore();
        CheckPassword();
    }

    public void CheckPassword()
    {
        if (InternetConnection.Check() != false)
        {
            DocumentReference documentReference = _firebaseFirestore.Collection("waybills").Document("password");
            documentReference.GetSnapshotAsync().ContinueWithOnMainThread(task =>
            {
                DocumentSnapshot snapshot = task.Result;
                if (snapshot.Exists)
                {
                    Debug.Log(string.Format("Document data for {0} document:", snapshot.Id));
                    Dictionary<string, object> dictionary = snapshot.ToDictionary();
                    string password = dictionary["code"].ToString();
                    if (_scene == Scene.Base)
                    {
                        if (_password.Equals(password))
                        {
                            _levelManager.Load("AdminScene");
                        }
                    }
                }
                else
                {
                    Debug.Log(string.Format("Document {0} does not exist!", snapshot.Id));
                }
            });
        }
    }

    public void Save()
    {
        _password = _inputField.text;
    }

    private void OnDisable()
    {
        _inputField.text = "";
    }
}
