using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayUI : MonoBehaviour
{
    public Button storageBtn,bagBtn, produceBtn ;
    public Image centerImg;
    public LevelControl levelPart;

    [SerializeField] private Button pauseBtn;

    public static GamePlayUI instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        storageBtn.onClick.AddListener(OnClickStorageBtn);
        bagBtn.onClick.AddListener(OnClickBagBtn);
        produceBtn.onClick.AddListener(OnClickProduceBtn);
    }

    public void OnClickStorageBtn()
    {
        PopupController.instance.popupStorage.Show(null);
        PopupController.instance.popupBag.Show(null);
    }
    public void OnClickBagBtn()
    {
        PopupController.instance.popupBag.Show(null);
        PopupController.instance.popupProduce.Hide();
    }
    public void OnClickProduceBtn()
    {
        PopupController.instance.popupProduce.Show(null);
        PopupController.instance.popupBag.Hide();
    }

    public void OnClickPauseBtn()
    {
        PopupController.instance.popupPause.Show(null);
    }

    
}
