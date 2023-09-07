using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Tree : InteractObject
{
    
    
    
    
    
    public virtual void CheckInRange(){}

    public virtual void GenerateRandomItem(Item item1, Item item2 = null, Item item3 = null)
    {
        item1.numGenerate = Random.Range(1, 3);
        if (item2 != null) item2.numGenerate = Random.Range(1, 3);
        if(item3 != null)   item3.numGenerate = Random.Range(1, 3);
    }
}
