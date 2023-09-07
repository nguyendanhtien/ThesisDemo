using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : StillObject
{
    private void OnEnable()
    {
        itemsGenerate = new List<Item>();
        Item item1 = new Item(typeItems[0], Random.Range(1, 3), icons[0]);
        // Item item2 = new Item(typeItems[1], Random.Range(1, 3), icons[1]);
        // Item item3 = new Item(typeItems[2], Random.Range(1, 3), icons[2]);
        
        itemsGenerate.Add(item1);
        // itemsGenerate.Add(item2);
        // itemsGenerate.Add(item3);
      
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("rayPlayer"))
        {
            var gController = GameController.instance;
            gController.tarGetObj = this;
            
            // change center color
            // GamePlayUI.instance.centerImg.color = Color.red;
            //
            // gController.hpBarObj.DisplayBar(remainHp, maxHp);
            Debug.Log("targeted");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("rayPlayer"))
        {
            var gController = GameController.instance;
            gController.tarGetObj = null;
            // gController.hpBarObj.HideBar();
            
            // change center color
            // GamePlayUI.instance.centerImg.color = Color.white;
        }
    }
}
