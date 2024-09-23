using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayButtonOthers : MonoBehaviour
{
    public AudioSource Sound;
    public AudioClip clip;
    void Start()
    {
        Sound.clip = clip;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void reproduce()
    {
        Sound.Play();
    }
    private void OnMouseDown(){

        reproduce();
        Invoke("LoadLevelGame",Sound.clip.length);
    }
    void LoadLevelGame()
    {
        SceneManager.LoadScene("MenuScene");

    }
}

