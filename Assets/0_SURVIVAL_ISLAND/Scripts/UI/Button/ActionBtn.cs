using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionBtn : MonoBehaviour
{
    public Button button;
    public bool isActive;

    private void Awake()
    {
        button.onClick.AddListener(OnClick);
    }

    public void OnClick()
    {
        button.GetComponent<RectTransform>().localScale = Vector3.one * 1.5f;
    }
}
