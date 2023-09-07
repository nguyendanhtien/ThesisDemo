using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupGameOver : MonoBehaviour
{
    public Button continueBtn;
    public Define.TypeStat statDie;
    public List<StatControl> stats;

    public void ClickContinueBtn()
    {
        switch (statDie)
        {
            case  Define.TypeStat.HealthPoint:
                PrefData.StatHealthPoint += 30;
                stats[0].UpdateFill();
                break;
            case Define.TypeStat.Satiety:
                PrefData.StatSatiety += 30;
                stats[1].UpdateFill();
                break;
            case Define.TypeStat.Water:
                PrefData.StatWater += 30;
                stats[2].UpdateFill();
                break;
            case Define.TypeStat.Warm:
                PrefData.StatWarm += 30;
                stats[3].UpdateFill();
                break;
            default:
                break;
        }
        PopupController.instance.popupWarning.Hide();
        gameObject.SetActive(false);
    }

    public void Show(Define.TypeStat type)
    {
        gameObject.SetActive(true);
        statDie = type;
    }
}
