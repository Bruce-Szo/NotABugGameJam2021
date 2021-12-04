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

    // Start is called before the first frame update
    void Start()
    {
        PlayRandomMusic();
    }

    public void PlayRandomMusic() {
        int backgroundMusicID = EazySoundManager.PlayMusic(soundtrack[Random.Range(0, soundtrack.Length)], musicVolume, true, false, 1, 1);
    }

    public void PlayShootEffect() {
        int shootID = EazySoundManager.PlaySound(shootFX, soundVolume);
    }
}
