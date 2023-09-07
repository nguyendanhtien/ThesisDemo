using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CollectableTree : Tree
{
    public bool canCollect;
    protected Vector3 originScale;
    public virtual void CheckCanCollect(){}

    public virtual void OnTargeted()
    {
    }
    
    protected void CheckScaleObj()
    {
        if(timeReviveRemain >= 0.8 * timeReviveConst )
            transform.localScale = originScale * 0.2f;
        else if (timeReviveRemain >= 0.6 * timeReviveConst)
            transform.localScale = originScale * 0.4f;
        else if (timeReviveRemain >= 0.4 * timeReviveConst)
            transform.localScale = originScale * 0.6f;
        else if (timeReviveRemain >= 0.2 * timeReviveConst)
            transform.localScale = originScale * 0.8f;
        else if (timeReviveRemain >= 0 * timeReviveConst)
            transform.localScale = originScale ;
    }

}
