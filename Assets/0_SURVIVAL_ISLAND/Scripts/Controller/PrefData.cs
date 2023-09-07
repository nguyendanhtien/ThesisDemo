using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefData : MonoBehaviour
{
    // public static int numItem
    // {
    //     get { return PlayerPrefs.GetInt("KeyNumItem", 0); }
    //     set { PlayerPrefs.SetInt("KeyindexPlayerBot", value); }
    // }

    public static void SetNumItem(int id, int num)
    {
        PlayerPrefs.SetInt("KeyItemNum"+ id, num);
    }
    public static int GetNumItem(int id)
    {
        return PlayerPrefs.GetInt("KeyItemNum" + id, 0);
    }
    
    public static void SetNumEquipItem(int id, int num)
    {
        PlayerPrefs.SetInt("KeyEquipItemNum"+ id, num);
    }

    public static int GetNumEquipItem(int id)
    {
        return PlayerPrefs.GetInt("KeyEquipItemNum" + id, 0);
    }
    
    public static int numclickedbtn
    {
        get { return PlayerPrefs.GetInt("KeyNumClickedBtn"); }
        set { PlayerPrefs.SetInt("KeyNumClickedBtn", value);}
    }

    public static void SaveButtonClick(int id)
    {
         PlayerPrefs.SetInt("KeySaveButtonClicked" + id, 1);
    }

    public static bool GetButtonClicked(int id)
    {
        return PlayerPrefs.GetInt("KeySaveButtonClicked" + id, 0) == 1;
    }
    



    #region Player

    public static int numExp
    {
        get { return PlayerPrefs.GetInt("KeyNumExp"); }
        set { PlayerPrefs.SetInt("KeyNumExp", value);}
    }
    // public static void setNumExp(int num)
    // {
    //     PlayerPrefs.SetInt("KeyNumExp", num);
    // }
    //
    // public static  int GetNumExp()
    // {
    //     return PlayerPrefs.GetInt("KeyNumExp");
    // }
    
    public static int StatHealthPoint
    {
        get { return PlayerPrefs.GetInt("KeyStatHealthPoint", 100) ; }
        set { PlayerPrefs.SetInt("KeyStatHealthPoint", value> 0 ? value: 0  ); }
    }
    public static int StatSatiety
    {
        get { return PlayerPrefs.GetInt("KeyStatSatiety", 100) ; }
        set { PlayerPrefs.SetInt("KeyStatSatiety", value> 0 ? value: 0 ); }
    }
    public static int StatWater
    {
        get { return PlayerPrefs.GetInt("KeyStatWater", 100) ; }
        set { PlayerPrefs.SetInt("KeyStatWater", value> 0 ? value: 0  ); }
    }
    public static int StatWarm
    {
        get { return PlayerPrefs.GetInt("KeyStatWarm", 100) ; }
        set { PlayerPrefs.SetInt("KeyStatWarm", value> 0 ? value: 0  ); }
    }
    

    #endregion
    
    #region PopupSetting

    public static bool Sound
    {
        get { return PlayerPrefs.GetInt("KeySound", 1) == 1; }
        set { PlayerPrefs.SetInt("KeySound", value ? 1 : 0); }
    }

    // public static bool Music
    // {
    //     get { return PlayerPrefs.GetInt("KeyMusic", 1) == 1; }
    //     set { PlayerPrefs.SetInt("KeyMusic", value ? 1 : 0); }
    // }
    
    public static bool Effect
    {
        get { return PlayerPrefs.GetInt("KeyEffect", 1) == 1; }
        set { PlayerPrefs.SetInt("KeyEffect", value ? 1 : 0); }
    }

    #endregion
    
}
