using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource currentMusic;
    public AudioClip[] soundtrack;

    // Start is called before the first frame update
    void Start()
    {
        currentMusic = this.GetComponent<AudioSource>();
        PlayRandomMusic();
    }

    void PlayRandomMusic() {
        currentMusic.clip = soundtrack[Random.Range(0, soundtrack.Length)];
        currentMusic.Play();
    }
}
