using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NotificationUI : MonoBehaviour
{
    [SerializeField] Transform notificationPanel;
    [SerializeField] TMP_Text headerTxt;
    [SerializeField] TMP_Text descriptionTxt;
    [SerializeField] GameObject countPanel;
    TMP_Text countTxt;
    [SerializeField] Button showBtn;
    [SerializeField] GameObject questCompletedPanel;

    string currentHeaderTxt;
    string currentDescriptionTxt;
    int currentCount;

    private void Start()
    {
        countTxt = countPanel.transform.GetChild(0).GetComponent<TMP_Text>();
        showBtn.onClick.RemoveAllListeners();
        //showBtn.onClick.AddListener(()=>ShowNotification(currentHeaderTxt, currentDescriptionTxt));
    }

    public void ShowNotification(string _headetText, string _descriptionText, int count = 0)
    {
        notificationPanel.gameObject.SetActive(true);

        currentHeaderTxt= _headetText;
        currentDescriptionTxt= _descriptionText;
        currentCount = count;

        headerTxt.text = _headetText;
        descriptionTxt.text = _descriptionText;

        QuestType questType = (count == 0) ? QuestType.NORMAL : QuestType.COUNT;
        if (questType == QuestType.COUNT)
        {
            countPanel.SetActive(true);
            countTxt.text = count.ToString();
        }
        else if(questType == QuestType.NORMAL)
        {
            countPanel.SetActive(false);
        }

        showBtn.onClick.RemoveAllListeners();
        showBtn.onClick.AddListener(()=>HideNotification());
    }

    public void HideNotification()
    {
        notificationPanel.gameObject.SetActive(false);

        showBtn.onClick.AddListener(()=>ShowNotification(currentHeaderTxt, currentDescriptionTxt, currentCount));
    }

    public void ShowQuestCompletedNotification()
    {
        questCompletedPanel.SetActive(true);
        Invoke(nameof(HideQuestCompletedNotification), 1f);
    }

    void HideQuestCompletedNotification()
    {
        questCompletedPanel.SetActive(false);
    }
}
