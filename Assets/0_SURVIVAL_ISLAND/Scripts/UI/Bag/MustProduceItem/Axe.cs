using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Axe : MustProduceItem
{
    private void Awake()
    {
        for (int i = 0; i < typeIngres.Count; i++)
        {
            Ingredient i1 = new Ingredient(typeIngres[i], numIngres[i] );
            DOVirtual.DelayedCall(0.2f, () =>
            {
                ingredients.Add(i1);
            });
        }
        
    }


    public Axe(Define.TypeItem type, int numOwned, int numGenerate, Sprite icon) : base(type, numOwned, numGenerate, icon)
    {
    }

    public Axe(Define.TypeItem type, int numGenerate, Sprite icon) : base(type, numGenerate, icon)
    {
    }
}
