using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPoint : MonoBehaviour
{
    [SerializeField] private Scene _scene;
    [SerializeField] private FirebaseUnit _firebaseUnit;
    [SerializeField] private CarListFromFirebase _carListFromFirebase;
    [SerializeField] private CarListUICreator _carListUICreator;
    [SerializeField] private CurrentWaybill _currentWaybill;
    [SerializeField] private SaveDataPanel _saveDataPanel;
    [SerializeField] private Login _login;
    [SerializeField] private GameObject ErrorPanel;
    private void Start()
    {
        if (InternetConnection.Check() != false)
        {
            Debug.Log(_scene);
            _firebaseUnit.Initialize();
            _login.Initialize(_firebaseUnit, _scene);
            _currentWaybill.Initialize(_firebaseUnit, _scene);
            _saveDataPanel.Initialize(_firebaseUnit);
            _carListFromFirebase.GetList(_firebaseUnit);
            _carListUICreator.CreateUIList(_carListFromFirebase);
            
        }
        else
        {
            ErrorPanel.SetActive(true);
        }
    }
}
public enum Scene
{
    Admin,
    Base,
}
