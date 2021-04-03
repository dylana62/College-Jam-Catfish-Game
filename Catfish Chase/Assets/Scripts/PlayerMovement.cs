using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed = 5f;

    float initialYPos;
    bool isJumping;

    // Start is called before the first frame update
    void Start()
    {
        isJumping = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
            isJumping = true;
        }

        if (isJumping)
        {
            if (transform.position.y < initialYPos)
            {
                rb.gravityScale = 0;
                rb.velocity = new Vector2(0f, 0f);
                isJumping = false;
            }
        }
    }

    void Jump()
    {
        initialYPos = transform.position.y;
        rb.AddForce(new Vector2(0f, 7f), ForceMode2D.Impulse);

        rb.gravityScale = 1;
    }
}
