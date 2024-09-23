using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectorLevel : MonoBehaviour
{
    public void changeLevel(string nameLevel)
    {
        SceneManager.LoadScene(nameLevel);
    }

    public void changeLevel(int numberLevel)
    {
        SceneManager.LoadScene(numberLevel);
    }
}
