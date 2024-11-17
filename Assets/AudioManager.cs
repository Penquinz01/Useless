using UnityEngine;
using UnityEngine.Audio;
using System;


public class AudioManager : MonoBehaviour
{
    [SerializeField] Sound[] clips;
    void Awake()
    {
        foreach(Sound s in clips)
        {
            s.source  = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }

    // Update is called once per frame
    public void Play(int n)
    {
        Sound s = clips[n];
        s.source.Play();
    } 
}
