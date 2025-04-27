using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    private PlayerEnergy playerEnergy;

    public bool isInAir;

    [SerializeField] float moveSpeed;
    [SerializeField] float jumpSpeed;
    [SerializeField] float energyPerJump;
    public float currentEnergy;
    public float maxEnergy;

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
        playerEnergy = GetComponent<PlayerEnergy>();

        isInAir = false;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move(){
        // Horizontal Movement
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, rb.velocity.y);

        // Jump (No air jump)
        if (!isInAir && currentEnergy > 0 && Input.GetKeyDown(KeyCode.Space)){
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);

            isInAir = true;

            loseEnergy();
        }
    }

    public void loseEnergy()
    {
        if (currentEnergy - energyPerJump <= 0)
        {
            currentEnergy = 0;
        }
        else
        {
            currentEnergy -= energyPerJump;
        }

        playerEnergy.UpdateEnergyBar();
    }

    public void GameOver()
    {
        SceneManager.LoadScene(3);
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform" ||
         collision.gameObject.tag == "Falling Platform")
        {
            isInAir = false;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Game Over!!");
        
        if (collision.gameObject.tag == "Dead Zone")
        {
            GameOver();
        }
    }
}
