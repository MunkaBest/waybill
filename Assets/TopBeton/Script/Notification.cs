using System.Collections;
using System.Collections.Generic;
using Unity.Notifications.Android;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Messaging;
using Firebase;
using System.Net;
using System.IO;

public class Notification : MonoBehaviour
{
    [SerializeField] private Text _car;
    [SerializeField] private string _text;
    private string _topicName = "waybillNotification";

    private void Start()
    {
        Subscribe();
        CreateNotificationChannel();
        FirebaseMessaging.TokenReceived += OnTokenReceived;
        FirebaseMessaging.MessageReceived += OnMessageReceived;
    }
    private void OnTokenReceived(object sender, TokenReceivedEventArgs token)
    {
        Debug.Log("Received Registration Token: " + token.Token);
    }

    private void OnMessageReceived(object sender, MessageReceivedEventArgs e)
    {
        SendNotification(e.Message.Notification.Body, e.Message.Notification.Title);
    }

    private string SendNotificationFromFirebaseCloud(string title, string text)
    {
        string result = "-1";
        string webAddress = "https://fcm.googleapis.com/fcm/send";
        HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(webAddress);
        httpWebRequest.ContentType = "application/json";
        httpWebRequest.Headers.Add("Authorization: key=AAAAvD2Cxdg:APA91bHnHEUCWI1nXthV40bfYoA-XdlBYibUwfaJ9qmInKdkpRIKpYteOTjBkCWxEQM0xMniHrGIsBhqSA7BlchzRhxiqpSDabKBkG6KF1ZOhYOlLw3bjic71gvp7C9oa0rLDki0UsMA");
        httpWebRequest.Method = "POST";

        using (StreamWriter streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
        {

            string json = "{\"to\": \"/topics/waybillNotification\",\"notification\": {\"body\":\"" + text + "\",\"title\":\"" + title + "\",}}";
            streamWriter.WriteAsync(json);
            streamWriter.FlushAsync();
        }
        HttpWebResponse httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
        using (StreamReader streamReader = new StreamReader(httpResponse.GetResponseStream()))
        {
            result = streamReader.ReadToEnd();
        }
        return result;
    }

    private void Subscribe()
    {
        FirebaseMessaging.SubscribeAsync(string.Format("/topics/{0}", _topicName));
    }

    public void SendOpenShiftNotification()
    {
        _text = string.Format("Машина {0} – Смена открыта", _car.text);
        SendNotificationFromFirebaseCloud("Внимание", _text);
    }

    public void SendDirectionChangedNotification()
    {
        _text = string.Format("Машина {0} – Маршрут изменен", _car.text);
        SendNotificationFromFirebaseCloud("Внимание", _text);
    }

    private void CreateNotificationChannel()
    {
        AndroidNotificationChannel channel = new AndroidNotificationChannel()
        {
            Name = "Announcement",
            Id = "TopBeton",
            Description = "Получение уведомлений об изменении маршрутов или открытия смен",
            Importance = Importance.High,
        };
        AndroidNotificationCenter.RegisterNotificationChannel(channel);
    }

    private void SendNotification(string text, string title)
    {
        AndroidNotification notification = new AndroidNotification()
        {
            Title = title,
            Text = text,
            FireTime = System.DateTime.Now,
        };

        AndroidNotificationCenter.SendNotification(notification, "TopBeton");
    }
}