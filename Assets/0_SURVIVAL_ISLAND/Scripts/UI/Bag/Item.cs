using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item: MonoBehaviour
{
    public Define.TypeItem type;
    public int numOwned;
    public int numGenerate;
    // public Image icon;

    public Sprite icon;
    public Item(Define.TypeItem type, int numOwned, int numGenerate, Sprite icon)
    {
        this.type = type;
        this.numOwned = numOwned;
        this.numGenerate = numGenerate;
        this.icon = icon;
    }
    
    public Item(Define.TypeItem type, int numGenerate, Sprite icon)
    {
        this.type = type;
        this.numGenerate = numGenerate;
        this.icon = icon;
    }

    // public Item(Define.TypeItem type, int numOwned, int numGenerate, Image icon)
    // {
    //     this.type = type;
    //     this.numOwned = numOwned;
    //     this.numGenerate = numGenerate;
    //     this.icon = icon;
    // }
    //
    // public Item(Define.TypeItem type, int numGenerate, Image icon)
    // {
    //     this.type = type;
    //     this.numGenerate = numGenerate;
    //     this.icon = icon;
    // }
}





