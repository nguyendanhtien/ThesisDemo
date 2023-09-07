using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelControl : MonoBehaviour
{
    public Text lvlTxt;
    public GameObject bar;
    public int curLevel;
    public DataExp data;

    public void UpdateLevel()
    {
        List<int> listExpNum = data.numExpLv;
        float numExp = PrefData.numExp;
        for (int i = 0; i < listExpNum.Count; i++)
        {
            
            if ( numExp < listExpNum[i])
            {
                curLevel = i;
                break;
            }
        }


        lvlTxt.text = "Level " + curLevel;
        bar.GetComponent<RectTransform>().localScale = Vector3.right* (numExp - listExpNum[curLevel - 1]) / (float)(listExpNum[curLevel] - listExpNum[curLevel - 1])
                                                        + Vector3.up + Vector3.forward;
        
    }

    private void OnEnable()
    {
        UpdateLevel();
    }
}
