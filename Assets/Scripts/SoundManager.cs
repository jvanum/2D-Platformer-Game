using System;
using UnityEngine;

public enum SoundTypes
{
    GAMEMUSIC,
    BUTTONCLICK,
    LEVELLOAD,
    LEVELLOCKED,
    PLAYERMOVE,
    PLAYERJUMP,
    PLAYERTELEPORT,
    PLAYERDEATH,
    PLAYERHURT,
    COLLECTKEY,
    PLAYERFELL
}

[Serializable]
public class Sounds
{
    public SoundTypes soundType;
    public AudioClip audioClip;
}


public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;
    public static SoundManager Instance { get { return instance; } }

    public AudioSource soundEffect;
    public AudioSource music;
    public Sounds[] sounds;

    private void Start()
    {
        PlayMusic(SoundTypes.GAMEMUSIC);
    }
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        MuteMusic();
    }

    private void MuteMusic()
    {
        if (Input.GetKeyDown(KeyCode.M))
            music.mute = !music.mute;
    }

    public void PlayMusic(SoundTypes soundType)
    {
        if (music.isPlaying) 
        return;

        AudioClip clip = GetAudioClip(soundType);
        if (clip != null)
        {
            music.clip = clip;
            music.Play();
        }
    }
    public void Play(SoundTypes soundType)
    {
        if (soundEffect.isPlaying)
        {
            soundEffect.Stop();
        }

        AudioClip clip = GetAudioClip(soundType);
        if(clip != null)
        {
            soundEffect.PlayOneShot(clip);
        }
    }

    public void PlayContinuous(SoundTypes soundType)
    {
        if (soundEffect.isPlaying) 
        return;

        AudioClip clip = GetAudioClip(soundType);
        if (clip != null)
        {
            soundEffect.PlayOneShot(clip);
        }
    }
    public AudioClip GetAudioClip(SoundTypes soundType)
    {
        Sounds sound =  Array.Find(sounds, i => i.soundType == soundType);
        if(sound != null)
        {
            return sound.audioClip;
        }
        return null;
    }
}