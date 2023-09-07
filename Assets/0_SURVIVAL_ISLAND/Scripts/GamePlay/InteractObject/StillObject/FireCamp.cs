using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCamp : MonoBehaviour
{
    public float intervalTime;

    public float remainTime;

    public StatControl warm;
    private void Start()
    {
        remainTime = 0;
    }

    private void Update()
    {
        remainTime -= Time.deltaTime;
        
        if (Vector3.Distance(transform.position, Player.instance.transform.position) < 5)
        {
            if (remainTime <= 0)
            {
                PrefData.StatWarm += 1;
                remainTime = intervalTime;
                warm.UpdateFill();
            }    
        }
        
        
    }
}
