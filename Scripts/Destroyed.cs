using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyed : MonoBehaviour
{
    //public AudioClip Sound;
    public float lifetCountDownTime;
    // Start is called before the first frame update
    void Start()
    {
        //Camera.main.GetComponent<AudioSource>().PlayOneShot(Sound);

    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, lifetCountDownTime);
    }
}
