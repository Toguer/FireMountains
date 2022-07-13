using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    // if you have it in the scene you can reference these right away
    //[SerializeField] private AudioData audioData;
    private bool isMuted;

    [SerializeField] private Sound[] audios;

    public static AudioManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        foreach (Sound s in audios)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.mute = s.mute;
        }
    }


    public void Play(string name)
    {
        Sound s = Array.Find(audios, sound => sound.name == name);
        if (s == null)
            return;
        s.source.Play();
    }
    public void Stop(string name)
    {
        Sound s = Array.Find(audios, sound => sound.name == name);
        s.source.Stop();
    }

    public void Mute()
    {
        //AudioData s = Array.Find(audios, sound => sound.name == name);
        //isMuted = !isMuted;
        //AudioListener.pause = isMuted;

        if (AudioListener.volume == 1)
        {
            AudioListener.volume = 0;
        }
    }

    public void OffMute()
    {
        if (AudioListener.volume == 0)
        {
            AudioListener.volume = 1;
        }
    }

    public void GameOver()
    {
        instance.Stop("Pueblo");
        instance.Play("GameOver");
    }
}

