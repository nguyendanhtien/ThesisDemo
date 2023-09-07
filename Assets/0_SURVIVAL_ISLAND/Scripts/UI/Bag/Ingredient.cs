using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ingredient : MonoBehaviour
{
    public Define.TypeItem type;
    public int numItem;

    public Image icon;
    public Text txt;
    public DataItem itemIcons;
    public bool canGenerate;
    public Ingredient(Define.TypeItem type, int numItem)
    {
        this.type = type;
        this.numItem = numItem;
    }

    public void Display(int type, int numItem)
    {
        icon.sprite = itemIcons.listItemIcon[type];
        txt.text = PrefData.GetNumItem(type) + "/" + numItem;
        gameObject.SetActive(true);
        canGenerate = PrefData.GetNumItem(type) >= numItem ;
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
