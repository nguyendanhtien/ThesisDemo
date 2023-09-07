using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupController : MonoBehaviour
{
    public PopupStorage popupStorage;
    public PopupBag popupBag;
    public PopupProduce popupProduce;
    public PopupPause popupPause;
    public PopupSettings popupSettings;
    public PopupGameOver popupGameOver;
    public PopupWarning popupWarning;

    public static PopupController instance;

    private void Awake()
    {
        instance = this;
    }
}
