using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Heart : MonoBehaviour
{
    public void OnMouseDown()
    {
        gameObject.SetActive(false);
        GameManager.Instance.HeartCollected();
    }

}
