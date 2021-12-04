using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hellmade.Sound;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] soundtrack;
    public AudioClip shootFX;

    public float soundVolume;
    public float musicVolume;

    public void PlayRandomMusic() {
        int backgroundMusicID = EazySoundManager.PlayMusic(soundtrack[Random.Range(0, soundtrack.Length)], musicVolume, true, true, 1, 1);
    }

    public void PlayShootEffect() {
        int shootID = EazySoundManager.PlaySound(shootFX, soundVolume);
    }

    public void SetGlobalVolume(float volume)
    {
        EazySoundManager.GlobalVolume = volume;
    }
    public void SetSoundVolume(float volume)
    {
        EazySoundManager.GlobalSoundsVolume = volume;
    }
    public void SetMusicVolume(float volume)
    {
        EazySoundManager.GlobalMusicVolume = volume;
    }
}
