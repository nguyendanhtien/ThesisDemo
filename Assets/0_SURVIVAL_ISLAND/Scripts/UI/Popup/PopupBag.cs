using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PopupBag : Popup
{
    public GameObject prefItem;
    public GameObject prefEquipItem;
    public Transform parentsItem;
    // public List<Sprite> iconsItem;
    public DataItem itemIcons;

    public List<BagItem> listItems;
    public List<BagItem> listEquipted;
    public BotControl botControl;
    private void OnEnable()
    {
        DisplayItem();
        botControl.UpdateBotPart(listEquipted);
    }

    void DisplayItem()
    {
        for (int i = 0; i < itemIcons.listItemIcon.Count; i++)
        {
            if (PrefData.GetNumItem(i) > 0)
            {
                listItems[i].gameObject.SetActive(true);
                listItems[i].UpdateItem(itemIcons.listItemIcon[i], PrefData.GetNumItem(i));
                
                // GameObject o = Instantiate(prefItem, parentsItem);
                // BagItem bagItem = o.GetComponent<BagItem>();
                // bagItem.icon.sprite = itemIcons.listItemIcon[i];
                // bagItem.num.text = PrefData.GetNumItem(i).ToString();
                // bagItem.type = (Define.TypeItem)i;
                // bagItem.btn = o.GetComponent<Button>();
                // bagItem.btn.onClick.AddListener(bagItem.AddToListEquip);
                
                // o.transform.GetChild(0).GetComponent<Image>().sprite = itemIcons.listItemIcon[i];
                // o.transform.GetChild(1).GetComponent<Text>().text = PrefData.GetNumItem(i).ToString();
            }
            else
            {
                listItems[i].gameObject.SetActive(false);
 
            }
            
        }
        // for (int i = 0; i < itemIcons.listEquiptableItemIcons.Count; i++)
        // {
        //     if (PrefData.GetNumItem(i) > 0)
        //     {
        //         GameObject o = Instantiate(prefEquipItem, parentsItem);
        //         EquiptableItem qItem = o.GetComponent<EquiptableItem>();
        //         qItem.icon.sprite = itemIcons.listEquiptableItemIcons[i];
        //         qItem.num.text = PrefData.GetNumItem(i).ToString();
        //     }
        // }
    }


    public void AddToListEquip()
    {
        Debug.Log("add to list");
    }
    private void OnDisable()
    {
        // DestroyItem();
    }

    void DestroyItem()
    {
        foreach (Transform t in parentsItem.transform)
        {
            Destroy(t.gameObject);
        }
    }
}
