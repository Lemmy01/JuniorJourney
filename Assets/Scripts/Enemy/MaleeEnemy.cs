using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Malee : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private int damage;
    [SerializeField] private float colliderDistance;
    private float cooldownTimer = Mathf.Infinity;
    [SerializeField] private BoxCollider2D boxCollider2D;
    [SerializeField] private LayerMask playerLayer;

    private EnemyPatrol enemyPatrol;
    private Animator anim;
    private Health playerHealth;

    private void Awake()
    {
        enemyPatrol = GetComponentInParent<EnemyPatrol>();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        cooldownTimer += Time.deltaTime;
        if (enemyPatrol != null)
        {
            enemyPatrol.enabled = !PlayerInSight();
        }
        if (PlayerInSight()) {
            if (cooldownTimer >= attackCooldown)
            {
                cooldownTimer = 0;       
                anim.SetTrigger("maleeAttack");
            }
        }   
    }
    private bool PlayerInSight() {

        RaycastHit2D hit = Physics2D.BoxCast(boxCollider2D.bounds.center+ transform.right * range * transform.localScale.x* colliderDistance,
            new Vector3(boxCollider2D.bounds.size.x*range, boxCollider2D.bounds.size.y, boxCollider2D.bounds.size.z),
            0,Vector2.left,0, playerLayer);
        if(hit.collider!=null)
            playerHealth = hit.collider.GetComponent<Health>();
        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider2D.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider2D.bounds.size.x * range, boxCollider2D.bounds.size.y, boxCollider2D.bounds.size.z));
    }

    private void DamagePlayer() { 
       if(PlayerInSight())
        {
            playerHealth.TakeDamage(damage);
        }
    }
}
