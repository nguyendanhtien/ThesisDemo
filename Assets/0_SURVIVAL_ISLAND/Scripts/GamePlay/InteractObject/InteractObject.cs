using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractObject : MonoBehaviour
{
    public List<Item> itemsGenerate;
    public int timeReviveRemain;
    public int timeReviveConst;
    public int expNum;
    public List<Define.TypeItem> typeItems;
    public List<Sprite> icons;
    public int maxHp,remainHp;
    public ParticleSystem cutTreePaticle;


    public virtual void DestroyObj()
    {
        timeReviveRemain = timeReviveConst;
        remainHp = maxHp;
        
    }
}
