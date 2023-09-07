using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : ScriptableObject
{
    public int curLevel;
    public int totalExp;
    public int curHp, maxHp;
    public int curWarmPercent, curWaterPercent, curSatietyPercent;


    public PlayerStat(int curLevel, int totalExp, int curHp, int maxHp, int curWarmPercent, int curWaterPercent, int curSatietyPercent)
    {
        this.curLevel = curLevel;
        this.totalExp = totalExp;
        this.curHp = curHp;
        this.maxHp = maxHp;
        this.curWarmPercent = curWarmPercent;
        this.curWaterPercent = curWaterPercent;
        this.curSatietyPercent = curSatietyPercent;
    }
}
