using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class NotificationManager : MonoBehaviour
{
    public static NotificationManager Instance;

    [SerializeField] NotificationUI notificationUIScript;
    [SerializeField] QuestNotification[] notifications;

    int currentNotification;
    int currentNotificationQuestCount;
    public int CurrentNotification { get { return currentNotification; } set { currentNotification = value; } }

    //bool isStart = true;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Invoke(nameof(ShowNotification), 2f);
    }

    //private void Update()
    //{
    //    if (isStart && currentNotificationQuestCount != 0)
    //        CancelInvoke(nameof(ShowNotification));
    //}

    void ShowNotification()
    {
        ShowCurrentNotification(currentNotificationQuestCount);
    }

    public void ShowCurrentNotification(int count = 0)
    { 
        if(CurrentNotification < notifications.Length)
        {
            Debug.Log($"Showing {currentNotification} Notification | Count : {count}");
            currentNotificationQuestCount = count;
            var notification = notifications[CurrentNotification];
            notificationUIScript.ShowNotification(notification.notificationHeader, notification.notificationDescription, notification.itemCount - count);
        }
        else
        {
            notificationUIScript.HideNotification(completed: true);
        }
    }

    public void CompleteQuest(int currentCount = 0)
    {
        //isStart = false;
        currentNotificationQuestCount = currentCount;
        CurrentNotification++;
        notificationUIScript.ShowQuestCompletedNotification();
        Invoke(nameof(ShowNotification), 2f);

    }
}
