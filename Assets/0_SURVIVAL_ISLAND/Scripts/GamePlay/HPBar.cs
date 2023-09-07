using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    public Image bar;


    public void DisplayBar(int remainHp, int maxHp)
    {
        bar.fillAmount = remainHp /(float) maxHp;
        gameObject.SetActive(true);
    }

    public void HideBar()
    {
        gameObject.SetActive(false);
    }
}
