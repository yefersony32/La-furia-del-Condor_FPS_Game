using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public Rigidbody2D rbody2D;     // Actua bajo el control de la física

    public float SpeedMove = 5f;             // Velocidad de Movimiento 

    private Vector2 moveInput;           // Contralaremos el movimiento en el eje x - y 
    private Vector2 mouseInput;           // Contralaremos el movimiento en el eje x - y 

    public float  mouseSensitivity =1f ;           // 

    public Camera viewCam;

    public GameObject bulletImpact;

    public int currentAmmon;//Municion Actual

    public Animator gunAmin;
    public Animator movingP;


    public int currentHealth;
    public int maxHealth = 100;
    public GameObject deadScreen;
    public bool hasDied;

    public Text healthText, ammoText;

    //private AudioController AudioController;

    public GameObject leveCompleteText;


    public bool stopInput;


    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthText.text = currentHealth.ToString();

        ammoText.text = currentAmmon.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(!hasDied)
        {
            //Movimiento del Jugador Teclado
            moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

            Vector3 moveHorizontal = transform.up * -moveInput.x;
            Vector3 moveVertical = transform.right * moveInput.y;

            rbody2D.velocity = (moveHorizontal + moveVertical) * SpeedMove;

            //Movimiento del Jugador Mouse
            mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) * mouseSensitivity;

            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z - mouseInput.x);

            viewCam.transform.localRotation = Quaternion.Euler(viewCam.transform.localRotation.eulerAngles + new Vector3(0f, mouseInput.y, 0f));

            //Disparo

            if (Input.GetMouseButtonDown(0))
            {
                if (currentAmmon > 0)
                {
                    Ray ray = viewCam.ViewportPointToRay(new Vector3(.5f, .5f, 0f));
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit))
                    {
                        Debug.Log("Te veo" + hit.transform.name);
                        Instantiate(bulletImpact, hit.point, transform.rotation);

                        if (hit.transform.tag == "Enemy")
                        {
                            hit.transform.parent.GetComponent<EnemyController>().getDamage();
                        }

                        AudioController.instance.PlayGunshot();
                    }
                    else
                    {
                        Debug.Log("NO Te veo");

                    }
                    currentAmmon--;
                    gunAmin.SetTrigger("Shoot");
                    UpdateAmmoUI();

                }
            }

            if(moveInput != Vector2.zero)
            {
                movingP.SetBool("isMoving", true);
            }
            else
            {
                movingP.SetBool("isMoving", false);

            }
        }
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        if(currentHealth <=0)
        {
            deadScreen.SetActive(true);
            hasDied = true;
            currentHealth = 0;
        }
        healthText.text = currentHealth.ToString();
        AudioController.instance.PlayPlayerHurt();

    }

    public void  AddHealth(int healAmout)
    {
        currentHealth += healAmout;
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        healthText.text = currentHealth.ToString();

    }
    public void UpdateAmmoUI()
    {
        ammoText.text = currentAmmon.ToString();

    }
}
