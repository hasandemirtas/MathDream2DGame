using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //public float JumpForce = 10f;
    //public float JumpForceLimit = 3;

    //private Rigidbody2D rb;
    //void Start()
    //{
    //    rb = GetComponent<Rigidbody2D>();
    //}

    //void FixedUpdate()
    //{

    //    if (Input.GetKey(KeyCode.UpArrow) && rb.velocity.y < JumpForceLimit)
    //    {
    //        rb.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
    //    }

    //    if (Input.GetKey(KeyCode.RightArrow) && rb.velocity.x < JumpForceLimit)
    //    {
    //        rb.AddForce(new Vector2(JumpForce / 2, JumpForce / 2), ForceMode2D.Impulse);
    //    }

    //    if (Input.GetKey(KeyCode.LeftArrow))
    //    {
    //        if (rb.velocity.x > 0)
    //            rb.AddForce(new Vector2(-JumpForce / 2, JumpForce / 2), ForceMode2D.Impulse);
    //        else if (Mathf.Abs(rb.velocity.x) < JumpForceLimit)
    //            rb.AddForce(new Vector2(-JumpForce / 2, JumpForce / 2), ForceMode2D.Impulse);
    //    }
    public float xdirection;
    public float ydirection;
    public Rigidbody2D RB;
    public float speed=12;
    public float JumpConstant=17;
    public bool isGround = false;

    public void MoveHorizontal()
    {
        xdirection = Input.GetAxis("Horizontal");
        ydirection = Input.GetAxis("Vertical");
        RB.velocity = new Vector2(xdirection * speed, RB.velocity.y);
        if (ydirection == 0)
        {
            isGround = true;
        }
        else
        {
            isGround = false;
        }

    }
    public void Jump()
    {
        ydirection = Input.GetAxis("Vertical");
        RB.velocity = new Vector2(RB.velocity.x, JumpConstant);

    }
    public void AcceleratedJump()
    {
        ydirection = Input.GetAxis("Vertical");
        RB.AddForce(new Vector2(0, JumpConstant), ForceMode2D.Impulse);
    }
    // Start is called before the first frame update
    void Start()
    {
        RB.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveHorizontal();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGround)
            {
                AcceleratedJump();
                //Jump();

            }

        }
    }
}

