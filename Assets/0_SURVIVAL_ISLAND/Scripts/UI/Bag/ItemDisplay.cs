using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class ItemDisplay : MonoBehaviour
{
    public GameObject txt;
    public Image img;
    public Item item;
    public Vector2 startPosTxt, startPostImg;
    private void OnEnable()
    {
        startPosTxt = txt.GetComponent<RectTransform>().anchoredPosition;
        startPostImg = img.gameObject.GetComponent<RectTransform>().anchoredPosition;
        
        StartCoroutine(FadeOut(txt,2, Define.TypeFade.Text));
        StartCoroutine(FadeOut(img.gameObject,2, Define.TypeFade.Image));
        PrefData.SetNumItem((int)item.type,item.numGenerate + PrefData.GetNumItem((int)item.type) );
        PrefData.numExp += 2;
        GamePlayUI.instance.levelPart.UpdateLevel();
        
        DOVirtual.DelayedCall(2f, () =>
        {
            txt.GetComponent<RectTransform>().anchoredPosition = startPosTxt;
            img.gameObject.GetComponent<RectTransform>().anchoredPosition = startPostImg;
            
            gameObject.SetActive(false);
        });
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
}
