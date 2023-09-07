using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProgressCollect : MonoBehaviour
{
    public Image img;
    public List<ItemDisplay> items;
    // public Transform parentsPos;
    [SerializeField]private GameController ins;
    // private void OnEnable()
    // {
    //     StartCoroutine(Collecting());
    // }

    private void Start()
    {
        img.color = Color.clear;
    }

    public void Show()
    {
        img.color = Color.black;
        StartCoroutine(Collecting());
    }

    public void Hide()
    {
        img.color = Color.clear;
    }

    IEnumerator Collecting()
    {
        // GameController ins = GameController.instance;
        while (img.fillAmount >0)
        {
           yield return  img.fillAmount -= 0.05f;
        }
        
        Debug.Log(ins);
        var num = ins.tarGetObj.itemsGenerate.Count;
        DisPlayItemCollected(num);
        DOVirtual.DelayedCall(3f, () =>
        {
            
            img.fillAmount = 1;
            // Debug.Log(GameController.instance.tarGetObj.itemsGenerate);
            
            
            // gameObject.SetActive(false);
            Hide();
        });
        img.fillAmount = 0;
        ins.tarGetObj.gameObject.SetActive(false);
        ins.tarGetObj = null;

        
    }

    void DisPlayItemCollected(int num)
    {
        // GameController ins = GameController.instance;
        
        
         DisplayEachItem(items[0], ins.tarGetObj.itemsGenerate[0]);
        if (num >= 2)
        {
            DisplayEachItem(items[1], ins.tarGetObj.itemsGenerate[1]);
            if (num == 3)
            {
                DisplayEachItem(items[2], ins.tarGetObj.itemsGenerate[2]);
            }
        }
    }

    void DisplayEachItem(ItemDisplay itemObj, Item item)
    {
        
            itemObj.transform.GetChild(0).GetComponent<Text>().text = item.numGenerate.ToString();
            itemObj.transform.GetChild(1).GetComponent<Image>().sprite = item.icon;
            itemObj.item = item;
            itemObj.gameObject.SetActive(true);
        
        
    }
    
    
    IEnumerator FadeOut(GameObject MyRenderer, float duration, Define.TypeFade type)
    {
        float counter = 0;
        Color spriteColor;
        //Get current color
        if(type == Define.TypeFade.Text)
        { spriteColor = MyRenderer.GetComponent<Text>().color;}
        else 
        {
            spriteColor = MyRenderer.GetComponent<Image>().color;
        }
    
        while (counter < duration)
        {
            counter += Time.deltaTime;
            //Fade from 1 to 0
            float alpha = Mathf.Lerp(1, 0, counter / duration);
            // Debug.Log(alpha);
    
            //Change alpha only
            if(type == Define.TypeFade.Text)
                MyRenderer.GetComponent<Text>().color = new Color(spriteColor.r, spriteColor.g, spriteColor.b, alpha);
            else
                MyRenderer.GetComponent<Image>().color = new Color(spriteColor.r, spriteColor.g, spriteColor.b, alpha);
    
            MyRenderer.GetComponent<RectTransform>().anchoredPosition += Vector2.up *0.5f;
            //Wait for a frame
            yield return null;
        }
    }

    void FadeOutItem(GameObject item)
    {
        StartCoroutine(FadeOut(item.transform.GetChild(0).gameObject, 3, Define.TypeFade.Text));
        StartCoroutine(FadeOut(item.transform.GetChild(1).gameObject, 3, Define.TypeFade.Image));
    }
}
