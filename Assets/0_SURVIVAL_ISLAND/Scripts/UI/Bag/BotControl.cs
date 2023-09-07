using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotControl : MonoBehaviour
{

    public List<BotItem> listItemBot;

    public List<BagItem> listEquipted;
    private void OnEnable()
    {
        PopupBag pBag = PopupController.instance.popupBag;
        UpdateBotPart(pBag.listEquipted);
    }

    public void UpdateBotPart(List<BagItem> listItem)
    {
        Debug.Log("update bot part");
        for (int i = 0; i < listItem.Count; i++)
        {
            listItemBot[i].UpdateBotItem(listItem[i].icon, PrefData.GetNumItem((int)listItem[i].type), listItem[i].type, listItem[i].typeFunc);
        }
        for (int i = listItem.Count; i < 5; i++)
        {
            listItemBot[i].ResetBotItem();
        }
    }
}
