using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControler : MonoBehaviour
{
    public static SoundControler instance;

    [SerializeField]
     AudioSource bgSource;
     [SerializeField]
     AudioSource[] loopSources,soundSources;
     

    private Queue<AudioSource> _queueLoops;
    private Queue<AudioSource> _queueSounds;
    private Dictionary<AudioClip, AudioSource> _dicLoop = new Dictionary<AudioClip, AudioSource>();

    [Header("Sound Effect")]
    public AudioClip BgGame;
    public AudioClip rockExploit, cutdownTree, collectWater;

    [Header("Animal")] 
    public AudioClip getHit;
    public AudioClip Bear, Cat, Iguana, Fox, Rabbit;

    
    private void Awake()
    {
        PlayBG(BgGame);
        SetSoundVolume();
        // SetMusicVolume();
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        _queueLoops = new Queue<AudioSource>(loopSources);
        _queueSounds = new Queue<AudioSource>(soundSources);
    }

    public void SetSoundVolume()
    {
        // bgSource.mute = !PrefData.Sound;
        bgSource.mute = !PrefData.Sound;
        
        foreach (var sound in soundSources)
        {
            sound.mute = !PrefData.Sound;
        }

        foreach (var loop in loopSources)
        {
            loop.mute = !PrefData.Sound;
        }
        
    }

    public void PlayVibrate(int vibrate)
    {
        //if (!PrefData.Vibrate)
        //{
        //    return;
        //}
    }

    // public void SetMusicVolume()
    // {
    //     // bgSource.mute = !PrefData.Music;
    //     foreach (var sound in soundSources)
    //     {
    //         sound.mute = !PrefData.Sound;
    //     }
    //
    //     foreach (var loop in loopSources)
    //     {
    //         loop.mute = !PrefData.Sound;
    //     }
    // }

    public void PlayBG(AudioClip clip, float volume = 1f)
    {
        if (clip == null)
        {
            return;
        }
        bgSource.volume = volume;
        bgSource.clip = clip;
        bgSource.Play();
    }

    public void PlayShot(AudioClip clip, float volume = 1f)
    {
        if (clip == null)
        {
            return;
        }
      
        var source = _queueSounds.Dequeue();
        source.volume = volume;
        source.PlayOneShot(clip);
        _queueSounds.Enqueue(source);
    }


    public void PlayLoop(AudioClip clip, float volume = 1f)
    {
        if (clip == null)
        {
            return;
        }
        var loopSource = _queueLoops.Dequeue();
        loopSource.volume = volume;
        loopSource.clip = clip;
        loopSource.Play();
        _dicLoop.Add(clip, loopSource);
    }

    public void StopLoop(AudioClip clip)
    {
        if (!clip || !_dicLoop.ContainsKey(clip))
        {
            return;
        }
        var loopSource = _dicLoop[clip];
        if (loopSource)
        {
            loopSource.Stop();
            _queueLoops.Enqueue(loopSource);
            _dicLoop.Remove(clip);
        }
    }
}
