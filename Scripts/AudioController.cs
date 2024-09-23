using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController instance;
    public AudioSource enemyDeath, enemyShot, playerHurt, health, ammo, gunShot;
    // Start is called before the first frame update

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayEnemyDeath()
    {
        enemyDeath.Stop();
        enemyDeath.Play();
    }

    public void PlayEnemyShot()
    {
        enemyShot.Stop();
        enemyShot.Play();
    }
    public void PlayPlayerHurt()
    {
        playerHurt.Stop();
        playerHurt.Play();
    }
    public void PlayHealthPickup()
    {
        health.Stop();
        health.Play();
    }
    public void PlayAmmoPickup()
    {
        ammo.Stop();
        ammo.Play();
    }

    public void PlayGunshot()
    {
        gunShot.Stop();
        gunShot.Play();
    }
}
