using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    #region Variables

    public Sound[] sounds;

    #endregion

    #region Unity Methods

    private void Awake()
    {
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