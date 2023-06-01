using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Extensions;
using Firebase.Firestore;

public class SaveDataPanel : MonoBehaviour
{
    [SerializeField] private Text _title;
    [SerializeField] private string _car;
    [SerializeField] private string _type;
    [SerializeField] private InputField _inputField;
    [SerializeField] private ErrorMessage _errorMessage;
    private FirebaseFirestore _firebaseFirestore;

    public void Initialize(IFirestoreHolder firestoreHolder)
    {
        SetFirestore(firestoreHolder.GetFirestore());
    }
    private void SetFirestore(FirebaseFirestore firebaseFirestore)
    {
        _firebaseFirestore = firebaseFirestore;
    }

    public void SetTitle(string title)
    {
        _title.text = title;
    }

    public void SetCar(Text car)
    {
        _car = car.text;
    }

    public void SetType(string type)
    {
        _type = type;
    }

    public void SetText(Text text)
    {
        _inputField.text = text.text;
    }


    public void SaveData()
    {
        if (InternetConnection.Check() != false)
        {
            DocumentReference documentReference = _firebaseFirestore.Collection("waybills").Document(_car);
            Dictionary<string, object> data = new Dictionary<string, object> {
            { _type, _inputField.text },
        };
            documentReference.SetAsync(data, SetOptions.MergeAll);
            gameObject.SetActive(false);
        }
        else
        {
            _errorMessage.Open();
        }
    }

    private void OnDisable()
    {
        _inputField.text = "";
    }
}
