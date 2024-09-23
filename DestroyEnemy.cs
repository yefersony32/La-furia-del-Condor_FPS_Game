using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemy : MonoBehaviour
{
    public int healthEnemy;

    public Rigidbody2D RB;

    public GameObject bullet;

    //private AudioController AudioController;



    // Start is called before the first frame update
    void Start()
    {
    }


    public void getDamage()
    {
        healthEnemy--;
        if (healthEnemy <= 0)
        {
            Destroy(gameObject);
            AudioController.instance.PlayEnemyDeath();
        }
        else
        {
            AudioController.instance.PlayEnemyShot();
        }
    }
}

