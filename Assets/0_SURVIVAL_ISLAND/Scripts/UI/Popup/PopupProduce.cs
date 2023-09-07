using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupProduce : Popup
{
    public ProductArea productArea;
    public IngredientArea ingredientArea;

    public MustProduceItem itemSelectToProduce;

    public GameObject eff;
    
    public void Produce()
    {
        int type = (int)itemSelectToProduce.type;
        PrefData.SetNumItem(type,PrefData.GetNumItem(type) + 1);
        foreach (Ingredient ingre in itemSelectToProduce.ingredients)
        {
            PrefData.SetNumItem((int)ingre.type,PrefData.GetNumItem((int)ingre.type) - ingre.numItem);
        }
        
        UpdateIngredient(itemSelectToProduce.ingredients);

        GameObject o = Instantiate(eff, transform);
        Destroy(o, 2);
    }

    public void UpdateIngredient(List<Ingredient >ingredients)
    {
        bool canProduce = true;
        for (int i = 0; i < 3; i++)
        {
            if (i < ingredients.Count)
            {
                ingredientArea.listIngre[i].Display((int)ingredients[i].type, ingredients[i].numItem);
                canProduce = canProduce && ingredientArea.listIngre[i].canGenerate;
            }
            else
            {
                ingredientArea.listIngre[i].Hide();
            }
        }
    }
}
