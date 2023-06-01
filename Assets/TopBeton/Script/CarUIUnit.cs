using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarUIUnit : MonoBehaviour
{
    [SerializeField] private Text _name;

    public void SetTitle(string name)
    {
        _name.text = name;
    }
}
