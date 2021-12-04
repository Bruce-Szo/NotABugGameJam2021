using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hellmade.Sound;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] soundtrack;
    public AudioClip shootFX;

    // Start is called before the first frame update
    void Start()
    {
        PlayRandomMusic();
    }

    void PlayRandomMusic() {
        int backgroundMusicID = EazySoundManager.PlayMusic(soundtrack[Random.Range(0, soundtrack.Length)], 0.1f, true, false, 1, 1);
    }

    void PlayShootEffect() {
        int shootID = EazySoundManager.PlaySound(shootFX, 0.2f);
    }
}
