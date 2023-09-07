using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectBtn : MonoBehaviour
{
    public ProgressCollect progressCollect;
    private void Start()
    {
        
    }


    public void OnClickCollect()
    {
        progressCollect.Show();
        GameController.instance.tarGetObj.timeReviveRemain = GameController.instance.tarGetObj.timeReviveConst;
    }
    private void OnEnable()
    {
        
    }

    

    IEnumerator FadeOut(GameObject MyRenderer, float duration)
    {
        float counter = 0;
        Color spriteColor = MyRenderer.GetComponent<Image>().color;
        

        while (counter < duration)
        {
            counter += Time.deltaTime;
            //Fade from 1 to 0
            float alpha = Mathf.Lerp(1, 0, counter / duration);
            // Debug.Log(alpha);

            //Change alpha only
            
                MyRenderer.GetComponent<Image>().color = new Color(spriteColor.r, spriteColor.g, spriteColor.b, alpha);

            MyRenderer.GetComponent<RectTransform>().anchoredPosition += Vector2.up *0.1f;
            //Wait for a frame
            yield return null;
        }
    }
    
    // IEnumerator FadeOut(GameObject MyRenderer, float duration, TypeFade type)
    // {
    //     float counter = 0;
    //     Color spriteColor;
    //     //Get current color
    //     if(type == TypeFade.Text)
    //     { spriteColor = MyRenderer.GetComponent<TMP_Text>().color;}
    //     else 
    //     {
    //         spriteColor = MyRenderer.GetComponent<Image>().color;
    //     }
    //
    //     while (counter < duration)
    //     {
    //         counter += Time.deltaTime;
    //         //Fade from 1 to 0
    //         float alpha = Mathf.Lerp(1, 0, counter / duration);
    //         // Debug.Log(alpha);
    //
    //         //Change alpha only
    //         if(type == TypeFade.Text)
    //             MyRenderer.GetComponent<TMP_Text>().color = new Color(spriteColor.r, spriteColor.g, spriteColor.b, alpha);
    //         else
    //             MyRenderer.GetComponent<Image>().color = new Color(spriteColor.r, spriteColor.g, spriteColor.b, alpha);
    //
    //         MyRenderer.GetComponent<RectTransform>().anchoredPosition += Vector2.up *0.1f;
    //         //Wait for a frame
    //         yield return null;
    //     }
    // }
}
