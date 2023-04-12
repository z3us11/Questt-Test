using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum QuestType
{
    NORMAL,
    COUNT
}

[CreateAssetMenu(fileName = "Quest")]
public class QuestNotification : ScriptableObject
{
    public int serialNumber;
    public string notificationHeader;
    [TextArea]
    public string notificationDescription;

    //for the collection quests/notification
    public bool isCountQuest;
    public int itemCount;
}
