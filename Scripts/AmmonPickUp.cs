using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmonPickUp : MonoBehaviour
{
    public int amountAmmo =25;
    //private AudioController AudioController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PlayerController.instance.currentAmmon += amountAmmo;
            PlayerController.instance.UpdateAmmoUI();

            AudioController.instance.PlayAmmoPickup();
            Destroy(gameObject);
        }
    }
}
