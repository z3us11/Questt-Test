using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintManager : MonoBehaviour
{
    public static HintManager Instance;

    [SerializeField] HintUI hintUIScript;
    [SerializeField] Hint[] hints;

    int currentHint = 0;
    public int CurrentHint { get { return currentHint; } set { currentHint = value; } }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        ShowCurrentHint();
    }

    public void ShowCurrentHint()
    {
        if (CurrentHint < hints.Length)
        {
            Debug.Log($"Showing {CurrentHint} Hint");
            var hint = hints[CurrentHint];
            hintUIScript.ShowHint(hint.hintName, hint.hintDescription);
        }
    }

    public void HintCompleted()
    {
        CurrentHint++;
        hintUIScript.HideHint();
    }
}
