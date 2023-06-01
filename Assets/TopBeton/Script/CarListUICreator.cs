using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CarListUICreator : MonoBehaviour
{
    [SerializeField] private GameObject _waybillPanel;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Transform _transform;
    private ICarsHolder _carsHolder;

    public void CreateUIList(ICarsHolder carsHolder)
    {
        _carsHolder = carsHolder;
        _carsHolder.OnReceived += CreateUIList;
    }

    private void CreateUIList(Dictionary<string, object> cars)
    {
        CurrentWaybill currentWaybill = _waybillPanel.GetComponent<CurrentWaybill>();
        foreach (KeyValuePair<string, object> car in cars)
        {
            string carValue = car.Value.ToString();
            GameObject prefab = Instantiate(_prefab, new Vector3(0, 0, 0), Quaternion.identity);

            CarUIUnit carUIUnit = prefab.GetComponent<CarUIUnit>();
            carUIUnit.SetTitle(carValue);

            Button button = prefab.GetComponent<Button>();
            button.onClick.AddListener(() => currentWaybill.SetCar(carValue));
            button.onClick.AddListener(() => _waybillPanel.SetActive(true));

            prefab.transform.SetParent(_transform, false);
        }
    }

    private void OnDisable()
    {
        if (_carsHolder != null)
        {
            _carsHolder.OnReceived -= CreateUIList;
        };
    }
}
