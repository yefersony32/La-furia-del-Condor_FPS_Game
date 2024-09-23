using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePause : MonoBehaviour
{

    public GameObject pauseMenu;
    
    public void pauseButton()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;

        AudioSource[] audios = FindObjectsOfType<AudioSource>();
        
        foreach(AudioSource a in audios)
        {
            a.Pause();
        }
    }
    public void playButton()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;

        AudioSource[] audios = FindObjectsOfType<AudioSource>();

        foreach (AudioSource a in audios)
        {
            a.Play();
        }
    }
    private void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            //pauseButton;
        }
    }
}
