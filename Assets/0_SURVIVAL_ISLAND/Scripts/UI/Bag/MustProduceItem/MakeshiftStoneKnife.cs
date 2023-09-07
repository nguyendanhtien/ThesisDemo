using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class MakeshiftStoneKnife : MustProduceItem

{
    private void Awake()
    {
        btn.onClick.AddListener(Choose);
        for (int i = 0; i < typeIngres.Count; i++)
        {
            Ingredient i1 = new Ingredient(typeIngres[i], numIngres[i] );
            DOVirtual.DelayedCall(0.2f, () =>
            {
                ingredients.Add(i1);
            });
        }
    }

    // public override void Choose()
    // {
    //     Debug.Log("choose this");
    //     
    //     PopupProduce pProduce = PopupController.instance.popupProduce;
    //     ProductArea product = pProduce.productArea;
    //     IngredientArea ingredientArea = pProduce.ingredientArea;
    //
    //     pProduce.itemSelectToProduce = this;
    //     
    //     //change icon + name
    //     product.name.text = name;
    //     product.icon.sprite = icon;
    //     product.icon.gameObject.SetActive(true);
    //
    //
    //     bool canProduce = true;
    //     // display Ingredients
    //     for (int i = 0; i < ingredients.Count; i++)
    //     {
    //         ingredientArea.listIngre[i].Display((int)ingredients[i].type, ingredients[i].numItem);
    //         canProduce = canProduce && ingredientArea.listIngre[i].canGenerate;
    //     }
    //
    //     Debug.Log(canProduce);
    //     //change btn confirm
    //     if (canProduce)
    //     {
    //         ingredientArea.ProduceBtn.interactable = true;
    //         ingredientArea.tickImage.color = Color.white;
    //     }
    // }

    public MakeshiftStoneKnife(Define.TypeItem type, int numOwned, int numGenerate, Sprite icon) : base(type, numOwned, numGenerate, icon)
    {
    }
    
    public MakeshiftStoneKnife(Define.TypeItem type, int numGenerate, Sprite icon) : base(type, numGenerate, icon)
    {
    }


    
}
