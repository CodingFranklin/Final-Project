using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rb;

    public bool isInAir;

    [SerializeField] float moveSpeed;
    [SerializeField] float jumpSpeed;

    void Awake() {
        rb = GetComponent<Rigidbody2D>();

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
        if (!isInAir && Input.GetKeyDown(KeyCode.Space)){
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);

            isInAir = true;
        }
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform" ||
         collision.gameObject.tag == "Falling Platform"){
            isInAir = false;
        }
    }
}
