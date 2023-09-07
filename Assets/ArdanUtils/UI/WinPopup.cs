using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public partial class WinPopUp : MonoBehaviour
{
    public Transform main;
    public Button closeBtn;

    private void Awake()
    {
        closeBtn.onClick.AddListener(Hide);
    }

    public virtual void Show(object data)
    {
        main.localScale = Vector3.one * 0.2f;
        main.DOScale(1, 0.2f);
        gameObject.SetActive(true);
        //  SoundControl.instance.PlayShot(SoundControl.instance.click);
    }

    public virtual void Hide()
    {
        gameObject.SetActive(false);
     //   SoundControl.instance.PlayShot(SoundControl.instance.click);
    }
}
