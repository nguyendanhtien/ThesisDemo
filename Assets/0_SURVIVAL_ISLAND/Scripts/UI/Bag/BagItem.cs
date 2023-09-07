using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagItem : Item
{
    public Image iconImg;
    public Text num;
    public Button btn;
    public bool isEquipted = false;
    public Define.TypeFunction typeFunc;
    private void Awake()
    {
        // btn.onClick.AddListener(AddToListEquip);
    }

    public void AddToListEquip()
    {
        
        Debug.Log("add to list");
        PopupBag bag = PopupController.instance.popupBag;
        if (bag.listEquipted.Count < 5 && !isEquipted)
        {
            isEquipted = true;
            bag.listEquipted.Add(this);
            bag.botControl.UpdateBotPart(bag.listEquipted);
        }
    }

    public void UpdateItem(Sprite icon, int num)
    {
        this.iconImg.sprite = icon;
        this.num.text = num.ToString();
    }

    public BagItem(Define.TypeItem type, int numOwned, int numGenerate, Sprite icon) : base(type, numOwned, numGenerate, icon)
    {
    }
    
    public BagItem(Define.TypeItem type, int numGenerate, Sprite icon) : base(type, numGenerate, icon)
    {
    }
    
}
