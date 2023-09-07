using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    public Light light;
    public float timeInterval;

    private IEnumerator Start()
    {
        bool isDes = true;
        while (true)
        {
            StartCoroutine(ChangeLight(timeInterval, isDes));
            isDes = !isDes;
            yield return new WaitForSeconds(timeInterval);
        }
    }

    IEnumerator ChangeLight(float duration, bool isDecrease)
    {
        float counter = 0;
        Color spriteColor;
        //Get current color
        
        spriteColor = light.GetComponent<Light>().color;
        
        while (counter < duration)
        {
            counter += Time.deltaTime;
            float colorElement;
            //Fade from 1 to 0
            if(isDecrease)
                colorElement = Mathf.Lerp(1f, 0, counter / duration);
            else
                colorElement = Mathf.Lerp(0, 1f, counter / duration);
            
    
            //Change alpha only
            light.GetComponent<Light>().color = new Color(spriteColor.r, colorElement, colorElement, spriteColor.a);
            
            //Wait for a frame
            yield return null;
        }
    }
}
