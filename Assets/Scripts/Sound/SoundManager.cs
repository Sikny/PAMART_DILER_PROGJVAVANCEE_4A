using System;
using UnityEngine;


public class SoundManager : MonoBehaviour
{
    public Sound[] sounds;
    
    public void Init()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }
    
    public void Play(string soundName)
    {
        Sound s = Array.Find(sounds, sound => sound.name == soundName);
        if (s == null)
            return;
        if (s.loop) //is a music
            s.source.volume = s.volume;
        else
            s.source.volume = s.volume;
        s.source.Play();
    }

    public void StopPlayingAllMusics()
    {
        foreach(var s in sounds)
        {
            if (s.loop)
            {
                s.source.Stop();
            }
        }
    }

    public void StopPlayingAllAudioSources()
    {
        foreach (var s in sounds)
        {
            s.source.Stop();
        }
    }

    public void StopPlayingAllSounds()
    {
        foreach (var s in sounds)
        {
            if (!s.loop)
                StopPlayingSource(s);
        }
    }

    public void StopPlayingSource(Sound s)
    {
        s.source.Stop();
    }

}
