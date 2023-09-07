using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : CollectableTree
{
    private void Awake()
    {
        originScale = gameObject.transform.localScale ;
    }

    public override void CheckInRange()
    {
        timeReviveRemain = timeReviveRemain > 0 ? (timeReviveRemain - 1) : 0;
        if (Vector3.Distance(gameObject.transform.position, Player.instance.transform.position) < 30)
        {
            gameObject.SetActive(true);
            CheckScaleObj();
                
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    

    // tam ko dung 
    // public override void CheckCanCollect()
    // {
    //     if (Vector3.Distance(gameObject.transform.position, Player.instance.center.transform.position) < 6)
    //     {
    //         Debug.Log("can collect");
    //         canCollect = true;
    //         
    //     }
    //     else
    //     {
    //         canCollect = false;
    //     }
    //
    //     GameController.instance.canCollectSth = GameController.instance.canCollectSth || canCollect;
    // }

    private void OnEnable()
    {
        itemsGenerate = new List<Item>();
        
        Item item1 = new Item(typeItems[0], Random.Range(1, 3), icons[0]);
        itemsGenerate.Add(item1);
        
        if (typeItems.Count >= 2)
        {
            Item item2 = new Item(typeItems[1], Random.Range(1, 3), icons[1]);
            itemsGenerate.Add(item2);
            
            if (typeItems.Count == 3)
            {
                Item item3 = new Item(typeItems[2], Random.Range(1, 3), icons[2]);
                itemsGenerate.Add(item3);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("rayPlayer"))
        {
            GameController.instance.tarGetObj = (Tree)this;
            GameController.instance.canCollectSth = true;
            Debug.Log("targeted");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("rayPlayer"))
        {
            GameController.instance.tarGetObj = null;
            
        }
    }
}
