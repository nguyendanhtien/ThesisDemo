using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PopupWarning : MonoBehaviour
{
    public  Image BG;
    public TMP_Text message;
    private bool isRunning;
    public void Show(Define.TypeStat type)
    {
        gameObject.SetActive(true);
        ChangeMessage(type);

        StartCoroutine(Blink());

    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    IEnumerator Blink()
    {
        bool isDes = true;
        isRunning = true;
        while (isRunning)
        {
            StartCoroutine(ChangeAlpha(1, isDes));
            isDes = !isDes;
            yield return new WaitForSeconds(1);
        }
    }

    IEnumerator ChangeAlpha(float duration, bool isDecrease)
    {
        float counter = 0;
        Color spriteColor;
        //Get current color
        
        spriteColor = BG.GetComponent<Image>().color;
        
        while (counter < duration)
        {
            counter += Time.deltaTime;
            float alpha;
            //Fade from 1 to 0
            if(isDecrease)
                alpha = Mathf.Lerp(70/255f, 0, counter / duration);
            else
                alpha = Mathf.Lerp(0, 70/255f, counter / duration);
            
    
            //Change alpha only
            // if(type == Define.TypeFade.Text)
                BG.GetComponent<Image>().color = new Color(spriteColor.r, spriteColor.g, spriteColor.b, alpha);
            // else
            //     BG.GetComponent<Image>().color = new Color(spriteColor.r, spriteColor.g, spriteColor.b, alpha);
    
            // MyRenderer.GetComponent<RectTransform>().anchoredPosition += Vector2.up *0.5f;
            //Wait for a frame
            yield return null;
        }
    }

    void ChangeMessage(Define.TypeStat type)
    {
        switch (type)
        {
            case Define.TypeStat.HealthPoint:
                message.text = "Your HP is too low";
                break;
            case Define.TypeStat.Satiety:
                message.text = "You are too hungry. Need to eat something";
                break;
            case Define.TypeStat.Water:
                message.text = "You are thirsty. Need to drink water";
                break;
            case Define.TypeStat.Warm:
                message.text = "You are freezing. Light will help you get warmer.";
                break;
            default:
                break;
        }
    }
}
