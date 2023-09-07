using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupSettings : Popup
{
    public Image onSound, offSound, onEffect, offEffect;

    private void OnEnable()
    {
        var isSound = PrefData.Sound;
        var isEffect = PrefData.Effect;
        onSound.gameObject.SetActive(isSound);
        offSound.gameObject.SetActive(!isSound);
        
        onEffect.gameObject.SetActive(isEffect);
        offEffect.gameObject.SetActive(!isEffect);
    }

    public void OnClickToggleSound()
    {
        PrefData.Sound = !PrefData.Sound;
        onSound.gameObject.SetActive(PrefData.Sound);
        offSound.gameObject.SetActive(!PrefData.Sound);
        SoundControler.instance.SetSoundVolume();
        // SoundControler.instance.SetMusicVolume();
    }
    
    public void OnClickToggleEffect()
    {
        PrefData.Effect = !PrefData.Effect;
        onEffect.gameObject.SetActive(PrefData.Effect);
        offEffect.gameObject.SetActive(!PrefData.Effect);
        // SoundControler.instance.SetSoundVolume();
        // SoundControler.instance.SetMusicVolume();
    }

    public void OnclickDefault()
    {
        PrefData.Sound = true;
        PrefData.Effect = true;
        onSound.gameObject.SetActive(PrefData.Sound);
        offSound.gameObject.SetActive(!PrefData.Sound);
        onEffect.gameObject.SetActive(PrefData.Effect);
        offEffect.gameObject.SetActive(!PrefData.Effect);
    }
}
