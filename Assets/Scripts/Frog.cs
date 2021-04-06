using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour
{
    [SerializeField] private float LeftCap;
    [SerializeField] private float RightCap;
    
    [SerializeField] private float JumpLength = 20f;
    [SerializeField] private float JumpHeight = 20f;

    [SerializeField] private LayerMask ground;

    private Rigidbody2D rb;
    private bool facingleft = true;
    private Collider2D coll;

    private void Start()
    {
        coll = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
    }
    

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        if (facingleft)
        {
            //Test if we are on the left cap
            if (transform.position.x > LeftCap)
            {
                //Face the right direction
                if (transform.localScale.x != 1)
                {
                    transform.localScale = new Vector3(1, 1);
                }

                //Test if frog is on the ground
                if (coll.IsTouchingLayers(ground))
                {
                    rb.velocity = new Vector2(-JumpLength, JumpHeight);
                }
            }
            else
            {
                facingleft = false;
            }
        }
        else
        {
            //Test if we are on the right cap
            if (transform.position.x < RightCap)
            {
                //Face the right direction
                if (transform.localScale.x != -1)
                {
                    transform.localScale = new Vector3(-1, 1);
                }

                //Test if frog is on the ground
                if (coll.IsTouchingLayers(ground))
                {
                    rb.velocity = new Vector2(JumpLength, JumpHeight);
                }
            }
            else
            {
                facingleft = true;
            }
        }
    }
}
