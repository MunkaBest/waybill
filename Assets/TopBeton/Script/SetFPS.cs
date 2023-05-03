using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetFPS : MonoBehaviour
{
    [SerializeField] private int _fpsCount;
    void Start()
    {
        Application.targetFrameRate = _fpsCount;
    }
}
