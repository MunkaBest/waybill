using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Share : MonoBehaviour
{
    public void CreateSharing(string path)
    {
        StartCoroutine(Create(path));
    }
    private IEnumerator Create(string path)
    {
        yield return new WaitForEndOfFrame();
        new NativeShare().AddFile(path)
        .SetCallback((result, shareTarget) => Debug.Log("Share result: " + result + ", selected app: " + shareTarget))
        .Share();
    }
}
