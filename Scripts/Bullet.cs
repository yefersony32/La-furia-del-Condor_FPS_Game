using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //public AudioClip Sound;
    public int damageAmount;
    public float bulletSpped = 5f;
    public Rigidbody2D RB;
    private Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        direction = PlayerController.instance.transform.position - transform.position;
        direction.Normalize();
        direction = direction * bulletSpped;
        //Camera.main.GetComponent<AudioSource>().PlayOneShot(Sound);
    }

    // Update is called once per frame
    void Update()
    {
        RB.velocity = direction * bulletSpped;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PlayerController.instance.TakeDamage(damageAmount);
            Destroy(gameObject);
        }
       else
        {
            Invoke("Destroy", 1f);
        }
    }


    void Destroy()
    {
        Destroy(gameObject);
    }


}
