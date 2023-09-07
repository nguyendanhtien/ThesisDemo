using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class StatControl : MonoBehaviour
{
    public Image fill;
    public Define.TypeStat type;
    public float deltaTime;
    // Start is called before the first frame update
    private void Awake()
    {
        switch (type)
        {
            case  Define.TypeStat.HealthPoint:
                PrefData.StatHealthPoint = 100;
                fill.fillAmount = PrefData.StatHealthPoint / 100f;
                break;
            case Define.TypeStat.Satiety:
                PrefData.StatSatiety = 100;
                fill.fillAmount = PrefData.StatSatiety / 100f;
                break;
            case Define.TypeStat.Water:
                PrefData.StatWater = 100;
                fill.fillAmount = PrefData.StatWater / 100f;
                break;
            case Define.TypeStat.Warm:
                PrefData.StatWarm = 100;
                fill.fillAmount = PrefData.StatWarm / 100f;
                break;
            default:
                break;
        }
        UpdateFill();
    }

    private void OnEnable()
    {
        UpdateFill();
    }

    IEnumerator Start()
    {
        if(type != Define.TypeStat.HealthPoint)
        {
                while (true)
            {
                UpdateStat();
                yield return new WaitForSeconds(deltaTime);
            }
        }
    }

    public void UpdateFill()
    {
        switch (type)
        {
            case  Define.TypeStat.HealthPoint:
                fill.fillAmount = PrefData.StatHealthPoint / 100f;
                break;
            case Define.TypeStat.Satiety:
                fill.fillAmount = PrefData.StatSatiety / 100f;
                break;
            case Define.TypeStat.Water:
                fill.fillAmount = PrefData.StatWater / 100f;
                break;
            case Define.TypeStat.Warm:
                fill.fillAmount = PrefData.StatWarm / 100f;
                break;
            default:
                break;
        }

        if(fill.fillAmount <= 0)
        {
            //Game over
            PopupController.instance.popupGameOver.Show(type);
        }
        if (fill.fillAmount <= 0.1f)
        {
            // warning
            PopupController.instance.popupWarning.Show(type);
        }
        else
        {
            PopupController.instance.popupWarning.Hide();
        }
    }

    public void UpdateStat()
    {
        
            switch (type)
            {
                case  Define.TypeStat.HealthPoint:
                    PrefData.StatHealthPoint += 1;
                    break;
                case Define.TypeStat.Satiety:
                    PrefData.StatSatiety -= 1;
                    break;
                case Define.TypeStat.Water:
                    PrefData.StatWater -= 1;
                    break;
                case Define.TypeStat.Warm:
                    PrefData.StatWarm -= 1;
                    break;
                default:
                    break;
            }
        
        UpdateFill();
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
