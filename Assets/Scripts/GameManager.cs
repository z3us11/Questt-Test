using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    int currentQuest = 1;

    //First Quest -> Press W to jump
    int currentWPressCount = 0;

    //Second Quest -> Jump 5 times
    int jumpNumber = 5;

    //Third Quest => Collect 7 berries
    [SerializeField] GameObject heartsHolder;
    int heartsCollected = 0;
    int totalHearts = 7;


    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (currentQuest == 1)
            FirstQuest();
        else if (currentQuest == 2)
            SecondQuest();
        else if (currentQuest == 3)
            ThirdQuest();
    }

    private void FirstQuest()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("Pressing W or 'jump'");
            currentWPressCount++;
            NotificationManager.Instance.CompleteQuest(currentWPressCount);
            HintManager.Instance.HintCompleted();
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
                NotificationManager.Instance.CompleteQuest(heartsCollected);
                currentQuest++;
            }
        }
    }

    private void ThirdQuest()
    {
        if (!heartsHolder.activeSelf)
        {
            heartsHolder.SetActive(true);
            HintManager.Instance.ShowCurrentHint();
        }
    }

    public void HeartCollected()
    {
        Debug.Log($"Hearts Collected");
        heartsCollected++;
        NotificationManager.Instance.ShowCurrentNotification(heartsCollected);

        if(heartsCollected == 3)
            HintManager.Instance.HintCompleted();

        if (heartsCollected == totalHearts)
        {
            Debug.Log($"{heartsCollected} hearts collected!");
            NotificationManager.Instance.CompleteQuest();
            currentQuest++;
        }
    }
}
