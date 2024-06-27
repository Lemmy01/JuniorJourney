using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    private Rigidbody2D body;
    [SerializeField] private float speed;
    [SerializeField] private float jump;
    [SerializeField] private float scale;
    private Animator animator;
    private bool grounded;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }

    private void Update()
    { 
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed,body.velocity.y);

        //flip player (-0.5 for first,image is fliped)
        if (horizontalInput > 0.01f) { 
            transform.localScale =new Vector3(-scale, scale, scale);
        }
        else if(horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(scale, scale, scale);
        }
        
        if(Input.GetKey(KeyCode.Space) && grounded) {
            Jump();
        }

        animator.SetBool("run", horizontalInput != 0);
    }

    private void Jump() {
        body.velocity = new Vector2(body.velocity.x, jump);
        grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Ground")
        {
            grounded = true;
        }
    }

    public bool canAttack() {

        return grounded && Input.GetAxis("Horizontal") == 0;
    }
}
