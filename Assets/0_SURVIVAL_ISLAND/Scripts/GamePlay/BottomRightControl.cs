using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class BottomRightControl : MonoBehaviour
{
    public Button weaponBtn;
    public Button increaseSpeedBtn;
    public Button crawlBtn;
    public Button jumpBtn;

    public void ClickWeapon()
    {
        if(Player.instance.mainWeapon != null && GameController.instance.attackObj != null)
            Player.instance.mainWeapon.PlayAnimAttack();
        if (Player.instance.mainWeapon == Player.instance.weapons[2] && GameController.instance.pond != null)
        {
            Player.instance.mainWeapon.PlayAnimCollectWater();
        }
    }

    public void ClickIncreaseSpeedBtn()
    {
        var player = Player.instance;
        if (player.speed > 4)
            player.speed = 2;
        else
        {
            player.speed = 10;
        }
    }

    public void ClickCrawlBtn()
    {
        var player = Player.instance;
        var camPos = player.camFollowPlayer.transform.localPosition;
        if (camPos.y > 1f)
        {
            Debug.Log("enter?");
            player.camFollowPlayer.transform.localPosition -= Vector3.up;
        }
        else
        {
            player.camFollowPlayer.transform.localPosition += Vector3.up;
            
        }
            
    }

    public void ClickJumpBtn()
    {
        var player = Player.instance;
        player.transform.DOMove(player.transform.position + Vector3.up*3, 1).SetEase(Ease.OutExpo);
    }
    
}
