using System;
using UnityEngine;
using UnityEngine.Audio;


public class AudioManager : MonoBehaviour
{
    #region Variables

    public Sound[] sounds;
    private static AudioManager _instance;
    
    #endregion

    #region Unity Methods

    private void Awake()
    {
        if (_instance == null)
            _instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        
        foreach (var s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.looping;
        }
    }

    private void Start()
    {
        Play("LevelMusic");
    }

    #endregion

    public void Play(string clipName)
    {
        Sound s = Array.Find(sounds, sound => sound.name == clipName);
        
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " was not found");
            return;
        }
        
        s.source.Play();
    }
}
