using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Load : MonoBehaviour
{
    public GameObject LoadScreen;
    public Slider slider;
    
    public void LoadL(int numberScene)
    {
        StartCoroutine(LoadAsync(numberScene));
    }
    

    IEnumerator LoadAsync(int numberScene)
    {
        AsyncOperation Operation = SceneManager.LoadSceneAsync(numberScene);

        LoadScreen.SetActive(true);
        while(!Operation.isDone)
        {
            float Progreso = Mathf.Clamp01(Operation.progress / .9f);
            slider.value = Progreso;

            yield return null;

        }
    }
}
