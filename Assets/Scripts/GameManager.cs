using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    int currentQuest = 1;

    //First Quest -> Press W to jump
    int currentWPressCount = 0;

    //Second Quest -> Jump 5 times
    int jumpNumber = 5;

    //Third Quest => Collect 7 berries

    private void Update()
    {
        if (currentQuest == 1)
            FirstQuest();
        else if (currentQuest == 2)
            SecondQuest();
    }

    private void FirstQuest()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("Pressing W or 'jump'");
            currentWPressCount++;
            NotificationManager.Instance.CompleteQuest(currentWPressCount);
            currentQuest++;
        }
    }

    private void SecondQuest()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("Pressing W or 'jump'");
            currentWPressCount++;
            NotificationManager.Instance.ShowCurrentNotification(currentWPressCount);
            if (currentWPressCount == jumpNumber)
            {
                Debug.Log($"Pressing W or 'jump' for {jumpNumber} time");
                NotificationManager.Instance.CompleteQuest();
                currentQuest++;
            }
        }
    }
}
