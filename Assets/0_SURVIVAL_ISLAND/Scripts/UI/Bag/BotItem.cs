using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotItem : MonoBehaviour
{
    public Define.TypeItem type;
    public Define.TypeFunction typeFunction;
    public Image iconImg;
    public Text num;
    public Button btn;
    public int id;
    public Image weaponbtnIcon;
    public Text funcTxt;
    public GameObject popup;

    public StatControl satiety, water;

    public void UpdateBotItem(Sprite icon, int num, Define.TypeItem type, Define.TypeFunction typeFunc)
    {
        this.iconImg.sprite = icon;
        this.iconImg.color = Color.white;
        this.num.text = num.ToString();
        this.type = type;
        this.typeFunction = typeFunc;
    }

    public void ResetBotItem()
    {
        this.iconImg.sprite = null;
        this.iconImg.color = Color.black;
        this.num.text = "";
        this.typeFunction = Define.TypeFunction.None;
    }
    public void ClickBtnBotItem()
    {
        PopupBag pBag = PopupController.instance.popupBag;
        pBag.listEquipted.RemoveAt(id);
        pBag.botControl.UpdateBotPart(pBag.listEquipted);
        GameObject o = pBag.parentsItem.GetChild((int)type).gameObject;
        o.GetComponent<BagItem>().isEquipted = false;
    }

    public void ClickPopup()
    {
        if (typeFunction == Define.TypeFunction.Equip)
        {
            var player =  Player.instance;
            // change weapon icon
            weaponbtnIcon.sprite = iconImg.sprite;
            weaponbtnIcon.gameObject.SetActive(true);
            // weaponbtnIcon.color = Color.white;
        
            //hide popup
            popup.SetActive(false);
        
            // enable weapon if exist
            if (type == Define.TypeItem.StoneKnife)
            {
                player.ChooseWeapon(0);
            }
            else if (type == Define.TypeItem.Bucket)
            {
                player.ChooseWeapon(2);
            }
        }
        else if(typeFunction == Define.TypeFunction.Consume)
        {
            if (type == Define.TypeItem.WaterBucket)
            {
                PrefData.StatWater += 20;
                water.UpdateFill();
            }
            else
            {
                PrefData.StatSatiety += 20;
                satiety.UpdateFill();
            }
            var numItemLeft = PrefData.GetNumItem((int)type) -1 ;
            PrefData.SetNumItem(((int)type), numItemLeft );
            this.num.text = numItemLeft.ToString();
            
            popup.SetActive(false);
        }
        else if (typeFunction == Define.TypeFunction.Place)
        {
            var numItemLeft = PrefData.GetNumItem((int)type) -1 ;
                //hide popup
            popup.SetActive(false);
            if (numItemLeft == 0)
            {
                ClickBtnBotItem();
            }
            PrefData.SetNumItem(((int)type), numItemLeft );
            this.num.text = numItemLeft.ToString();
            Player.instance.PlaceObject();
        }

        
    }

    public void DisPlayPopup()
    {
        
        if (typeFunction != Define.TypeFunction.None)
        {
            popup.SetActive(true);

            if (typeFunction == Define.TypeFunction.Equip)
            {
                funcTxt.text = "EQUIP";
                
            }
            
            else if (typeFunction == Define.TypeFunction.Consume)
            {
                funcTxt.text = "CONSUME";
                
            }
            else if (typeFunction == Define.TypeFunction.Place)
            {
                funcTxt.text = "PLACE";
                
            }
        }
        
    }
}
