using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int healthEnemy;
    public GameObject dead;
    public Animator Animator;

    public float playerRange = 10f;

    public Rigidbody2D RB;
    public float speedMove;

    public bool shouldShoot;
    public float fireRate = .5f;
    private float shotCounter;
    public GameObject bullet;
    public Transform firePoint;

    //private AudioController AudioController;



    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position,PlayerController.instance.transform.position)<playerRange)
        {
            Vector3 PlayerDirection = PlayerController.instance.transform.position - transform.position;
            RB.velocity = PlayerDirection.normalized * speedMove;
            if(shouldShoot)
            {
                shotCounter -= Time.deltaTime;
                if (shotCounter <= 0)
                {
                    Instantiate(bullet, firePoint.position, firePoint.rotation);
                    shotCounter = fireRate;
                }
            }
        }
        else 
        {
            RB.velocity = Vector2.zero;
        }
             
    }

    public void getDamage()
    {
        healthEnemy--;
        if(healthEnemy <= 0)
        {
            Destroy(gameObject);
             Instantiate(dead,transform.position,transform.rotation);

            AudioController.instance.PlayEnemyDeath();
        }
        else
        {
            AudioController.instance.PlayEnemyShot();
        }
    }
}
