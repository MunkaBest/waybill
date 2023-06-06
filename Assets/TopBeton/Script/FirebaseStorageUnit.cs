using Firebase.Storage;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;

public class FirebaseStorageUnit : MonoBehaviour
{
    public void Initialize()
    {
        //FirebaseStorage storage = FirebaseStorage.GetInstance("gs://waybill2-3dde6.appspot.com/");
    }
    public void SendToStorage(string path, string folderName, string fileName)
    {
        FirebaseStorage storage = FirebaseStorage.DefaultInstance;
        StorageReference storageRef = storage.GetReferenceFromUrl("gs://waybill2-3dde6.appspot.com");

        StorageReference riversRef = storageRef.Child(folderName + fileName + ".pdf");
        riversRef.PutFileAsync(path)
                    .ContinueWith((task) =>
                    {
                        if (task.IsFaulted || task.IsCanceled)
                        {
                            Debug.Log(task.Exception.ToString());
                        }
                        else
                        {
                            StorageMetadata metadata = task.Result;
                            string md5Hash = metadata.Md5Hash;
                            Debug.Log("Finished uploading...");
                            Debug.Log("md5 hash = " + md5Hash);
                        }
                    });

    }
}
