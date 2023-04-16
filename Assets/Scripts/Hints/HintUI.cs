using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class HintUI : MonoBehaviour
{
    [SerializeField] Transform hintPanel;

    [SerializeField] TMP_Text hintHeaderTxt;
    [SerializeField] TMP_Text hintDescriptionHint;

    public void ShowHint(string headerTxt, string descriptionTxt)
    {
        hintPanel.gameObject.SetActive(true);
        hintPanel.localScale = Vector2.zero;
        hintPanel.DOScale(Vector2.one, 0.25f);

        hintHeaderTxt.text = headerTxt;
        hintDescriptionHint.text = descriptionTxt;
    }

    public void HideHint()
    {
        hintPanel.DOScale(Vector2.zero, 0.25f).OnComplete(()=>
        {
            hintPanel.gameObject.SetActive(false);
        });
    }
}
