using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErrorMessage : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine(CloseTimer(2f));
    }
    private void OnDisable()
    {

    }

    public void Open()
    {
        gameObject.SetActive(true);
    }

    private IEnumerator CloseTimer(float time)
    {
        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);
    }
}
