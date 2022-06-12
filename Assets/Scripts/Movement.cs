using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float JumpForce = 10f;
    public float JumpForceLimit = 3;

    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.UpArrow) && rb.velocity.y < JumpForceLimit)
        {
            rb.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        }

        if (Input.GetKey(KeyCode.RightArrow) && rb.velocity.x < JumpForceLimit)
        {
            rb.AddForce(new Vector2(JumpForce / 2, JumpForce / 2), ForceMode2D.Impulse);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (rb.velocity.x > 0)
                rb.AddForce(new Vector2(-JumpForce / 2, JumpForce / 2), ForceMode2D.Impulse);
            else if (Mathf.Abs(rb.velocity.x) < JumpForceLimit)
                rb.AddForce(new Vector2(-JumpForce / 2, JumpForce / 2), ForceMode2D.Impulse);
        }
    }
}
