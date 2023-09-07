using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class GameController : MonoBehaviour
{
    public List<Tree> listTree;
    public bool canCollectSth;
    public InteractObject tarGetObj;
    public InteractObject attackObj;
    public InteractObject pond;
    public HPBar hpBarObj;

    public static GameController instance;

    private void Awake()
    {
        instance = this;
    }

    private IEnumerator Start()
    {
        while (true)
        {
            CheckInRange();

            yield return new WaitForSeconds(1);
        }
    }

    

    public void CheckInRange()
    {
        canCollectSth = false;
        foreach (var tree in listTree)
        {
            tree.CheckInRange();
            
        }
        
        Player.instance.collectBtn.gameObject.SetActive(tarGetObj != null  );
        
            
        
    }
}
