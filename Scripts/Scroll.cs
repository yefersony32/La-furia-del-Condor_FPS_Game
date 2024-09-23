using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    public float speed;
    private Renderer rnd;


    void Start()
    {
        rnd = GetComponent<Renderer>();
    }

    private void Update()
    {
        rnd.material.mainTextureOffset = new Vector2(rnd.material.mainTextureOffset.x + speed * Time.deltaTime, 0);

    }

}
