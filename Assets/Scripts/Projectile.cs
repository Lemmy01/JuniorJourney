using System.Collections;
using System.Collections.Generic;

using Unity.VisualScripting;

using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed;
    private bool hit;

    private BoxCollider2D boxCollider;
    private Animator animator;

    private float direction;
    private float lifetime;


    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (hit) { return; }
        float movementSpeed = speed * Time.deltaTime * direction;
        transform.Translate(movementSpeed, 0, 0);

        lifetime += Time.deltaTime;
        if (lifetime > 5) {
           
            gameObject.SetActive(false);   
    }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!(collision.tag == "Player")) { 
            hit = true;
            boxCollider.enabled = false;
            animator.SetTrigger("deactivate");

            if (collision.tag == "Enemy")
            {
                collision.GetComponent<Health>().TakeDamage(1);
            }
        }
    }

    public void SetDirection(float _direction)
    {
        lifetime = 0;
        direction = _direction;
        gameObject.SetActive(true);
        hit=false;
        boxCollider.enabled=true;
        
        float localScaleX=transform.localScale.x;
        if(Mathf.Sign(localScaleX) != _direction) {
            localScaleX = -localScaleX;

            transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
        }
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }

    
}
