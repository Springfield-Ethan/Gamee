using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class Frog : Enemy
{
    [SerializeField] private float LeftCap;
    [SerializeField] private float RightCap;
    
    [SerializeField] private float JumpLength = 20f;
    [SerializeField] private float JumpHeight = 20f;

    [SerializeField] private LayerMask ground;

    private Rigidbody2D rb;
    private bool facingleft = true;
    private Collider2D coll;
    protected override void Start()
    {
        base.Start();
        coll = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
    }
    

    private void Update()
    {
        //Transition from jumping to falling
        if (anim.GetBool("Jumping"))
        {
            if (rb.velocity.y < 0.1f)
            {
                anim.SetBool(("Jumping"), false);
                anim.SetBool("Falling", true);
            }    
        }    
        
        //Transition from falling to idle
        if (anim.GetBool("Falling") && coll.IsTouchingLayers(ground))
        {
            anim.SetBool("Falling", false);
        }    
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
                    anim.SetBool("Jumping", true );
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
                    anim.SetBool("Jumping", true );
                }
            }
            else
            {
                facingleft = true;
            }
        }
    }
    
}
