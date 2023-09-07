using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    public Animator m_animator;
    
    public List<ItemDisplay> items;
    public Define.TypeItem type;

    public Image resistanceImg;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayAnimAttack()
    {
        m_animator.Play("StoneKnife");
        GameController ins = GameController.instance;
        DOVirtual.DelayedCall(1f, () =>
            {
                m_animator.SetBool("PlayAttack", false);
                
                
                
                // target attack obj
                
                UpdateHPBar(ins);
                
                //play sound
                PlaySound(ins);
                
                //chnage resistance
                ChangeResistance();
                
                // play particle
                PlayParticle(ins);
                
                DisPlayItemByAttack();
            }
        );
    }

    void ChangeResistance()
    {
        resistanceImg.fillAmount -= 0.2f;
        
            if (resistanceImg.fillAmount <= 0f)
            {
                PrefData.SetNumItem((int)type, PrefData.GetNumItem((int)type) -1 );
                if (PrefData.GetNumItem((int)type) == 0)
                {
                    gameObject.SetActive( false);
                    Player.instance.mainWeapon = null;
                
                }
                else
                {
                    resistanceImg.fillAmount = 1;
                }
            }
        
        
    }

    void PlaySound(GameController instance)
    {
        var soundIns = SoundControler.instance;
        var obj = instance.attackObj;
        if (obj is Rock)
        {
            soundIns.PlayShot(soundIns.rockExploit);
        } else if (obj is Tree)
        {
            soundIns.PlayShot(soundIns.cutdownTree);
        }
        else if(obj is Animal)
        {
            if(obj is Bear) soundIns.PlayShot(soundIns.Bear);
            else if(obj is Cat) soundIns.PlayShot(soundIns.Cat);
            else if(obj is Rabbit) soundIns.PlayShot(soundIns.Rabbit);
            else if(obj is Fox) soundIns.PlayShot(soundIns.Fox);
            else if(obj is Iguana) soundIns.PlayShot(soundIns.Iguana);
            
            
            
        }
    }
    public void PlayParticle(GameController ins)
    {
        if (!PrefData.Effect)
        {
            return;
        }
        var obj = ins.attackObj;
        if (obj is Tree)
        {
            obj.cutTreePaticle.gameObject.SetActive(true);
            DOVirtual.DelayedCall(1f, () => 
                obj.cutTreePaticle.gameObject.SetActive(false));
        }
        
        else if (obj is StillObject)
        {
            var stillObj = (StillObject)obj;
            GameObject o = Instantiate(stillObj.effect, stillObj.transform) ;
            Destroy(o,2);
        }
        
    }
    public void UpdateHPBar(GameController ins)
    {
        InteractObject obj = ins.attackObj;
        obj.remainHp -= 20;
        ins.hpBarObj.DisplayBar(obj.remainHp, obj.maxHp);
        
    }

    
    
    void DisPlayItemByAttack()
    {
        GameController ins = GameController.instance;
        var obj = ins.attackObj;

        if (!(obj is Animal))
        {
            Debug.Log("aaaaaaaaaaaaa");
            DisplayEachItem(items[0], ins.attackObj.itemsGenerate[0]);
            if(ins.attackObj.itemsGenerate.Count > 1)
                DisplayEachItem(items[1], ins.attackObj.itemsGenerate[1]);
            if(ins.attackObj.itemsGenerate.Count > 2)
                DisplayEachItem(items[2], ins.attackObj.itemsGenerate[2]);
        }

        if(obj is Animal)
        {
            Debug.Log("aaaaaaaaaaaaa");
            if (obj.remainHp <= 0)
            {
                DisplayEachItem(items[0], ins.attackObj.itemsGenerate[0]);
                if(ins.attackObj.itemsGenerate.Count > 1)
                    DisplayEachItem(items[1], ins.attackObj.itemsGenerate[1]);
                if(ins.attackObj.itemsGenerate.Count > 2)
                    DisplayEachItem(items[2], ins.attackObj.itemsGenerate[2]);
            }
        }
        
        
        if (obj.remainHp <= 0)
        {
            obj.DestroyObj();
            obj.gameObject.SetActive(false);
            ins.attackObj = null;
            GamePlayUI.instance.centerImg.color = Color.white;
            ins.hpBarObj.HideBar();
        }
    }

    void DisplayEachItem(ItemDisplay itemObj, Item item)
    {
        
            itemObj.transform.GetChild(0).GetComponent<Text>().text = item.numGenerate.ToString();
            itemObj.transform.GetChild(1).GetComponent<Image>().sprite = item.icon;
            itemObj.item = item;
            itemObj.gameObject.SetActive(true);
        
        
    }
    
    
    
    // collect water

    public void PlayAnimCollectWater()
    {
        // m_animator.SetBool("CollectWater", true);
        // DOVirtual.DelayedCall(1f, () =>
        //     {
        //         m_animator.SetBool("CollectWater", false);
        //
        //         GameController ins = GameController.instance;
        //         Debug.Log("collect water");
        //         DisplayEachItem(items[0], ins.pond.itemsGenerate[0]);
        //     }
        // );
        
        

        m_animator.Play("CollectWater");
        SoundControler.instance.PlayShot(SoundControler.instance.collectWater);
        ChangeResistance();
        GameController ins = GameController.instance;
        DisplayEachItem(items[0], ins.pond.itemsGenerate[0]);
    }
    

    
}
