using System.Collections;
using System.Collections.Generic;
// using UnityEditorInternal;
using UnityEngine;

public class Define : MonoBehaviour
{
    public enum TypeItem
    {
        Cane,
        Leaves,
        Sticks,
        Stone,
        
        StoneKnife,
        Meat,
        Bucket,
        CaneFishingRod,
        CaneFloor,
        CookingOven,
        Rope,
        WoodenFoundation,
        Hook,
        Fiber,
        WaterBucket,
        Mushroom,
        Wool,
        FireCamp
    }

    public enum TypeEquiptableItem
    {
        Banana,
        Sugar,
        
    }


    public enum TypeFade
    {
        Text,
        Image
    }
    
    public enum TypeFunction{
        None,
        Consume,
        Equip,
        Place,
    }
    
    public enum TypeStat
    {
        HealthPoint,
            Satiety,
           Water,
           Warm,
    }
}
