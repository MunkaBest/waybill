using System.Collections;
using System.Collections.Generic;
using Unity.Notifications.Android;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Messaging;

public class NotificationScript : MonoBehaviour
{
    [SerializeField] private Text _car;
    private void Awake()
    {
        AndroidNotificationChannel channel = new AndroidNotificationChannel()
        {
            Id = "waybill",
            Name = "default channel",
            Importance = Importance.High
        };
        AndroidNotificationCenter.RegisterNotificationChannel(channel);
    }

    public void Subscribe()
    {
        FirebaseMessaging.SubscribeAsync("/topics/waybillTopic");
    }

    public void SendOpenShiftMessage(Text car)
    {
        AndroidNotification notification = new AndroidNotification()
        {
            Title = string.Format("Машина {0}", car.text),
            Text = "Смена открыта",
            FireTime = System.DateTime.Now.AddSeconds(2),
        };
        AndroidNotificationCenter.SendNotification(notification, "waybill");
    }

    private void OnDisable()
    {
    }
}
