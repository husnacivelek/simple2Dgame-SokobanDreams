using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private float jumpForce = 50f;
    private Rigidbody2D _rigidbody2d;
    private Animator _animator;

    private bool grounded;
    private bool started;
    private bool jumping;

    private void Awake()
    {
        _rigidbody2d = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        grounded = true;

    }

    private void Update()
    {
        if(Input.GetKeyDown("space"))
        {
            if(started && grounded)
            {
                _animator.SetTrigger("Jump");
                grounded = false;
                jumping = true;

            }
            else
            {
                 _animator.SetBool("GameStarted",true);
                 started = true;

            }
        }

           
         _animator.SetBool("Grounded", grounded); 

            

        

    }

    private void FixedUpdate()
    {
        if(started)
        {
            _rigidbody2d.velocity = new Vector2(speed,_rigidbody2d.velocity.y);
        }

         if(jumping)
        {
            _rigidbody2d.AddForce(new Vector2(0f,jumpForce));
            jumping = false;
        }
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
    }
}
