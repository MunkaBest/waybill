using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class PdfManager : MonoBehaviour
{
    [SerializeField] private Text _carNumber;
    [SerializeField] private Text _date;
    [SerializeField] private PDF _pdf;
    [SerializeField] private Share _share;

    public void SendData()
    {
        string name = string.Format("{0}({1})", _carNumber.text, _date.text) + ".pdf";
        string path = Path.Combine(Application.persistentDataPath, name);
        _pdf.Create(path);
        _share.CreateSharing(path);
    }
}
