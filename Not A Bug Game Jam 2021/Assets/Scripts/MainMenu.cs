using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Start()
    {
        AudioManager aM = GameObject.FindWithTag("AudioManager").GetComponent<AudioManager>();
        aM.PlayRandomMusic();
        aM.SetGlobalVolume(5);
        aM.SetSoundVolume(5);
        aM.SetMusicVolume(5);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
