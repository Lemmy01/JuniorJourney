using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
   [SerializeField] private float attackCooldown;
    [Header("Ranged Attack")]
    [SerializeField] private Transform firepoint;
    [SerializeField] private GameObject[] fireballs;



    private Animator animator;
    private MovementScript movement;

    private float cooldownTimer=Mathf.Infinity;


    private void Awake()
    {
        animator = GetComponent<Animator>();
        movement = GetComponent<MovementScript>();
    }

    private void Update()
    {
      
        if (Input.GetMouseButtonDown(0) && cooldownTimer>attackCooldown && movement.canAttack()) { 
          Attack();
        }

        cooldownTimer += Time.deltaTime;
    }

    private void Attack() {

        animator.SetTrigger("attack");
        cooldownTimer = 0;

        fireballs[GetFireball()].transform.position = firepoint.position;
        fireballs[GetFireball()].GetComponent<Projectile>().SetDirection(-Mathf.Sign(transform.localScale.x));

    }

    private int GetFireball()
    {
        for (int i = 0; i < fireballs.Length; i++)
        {
            if (!fireballs[i].activeInHierarchy)
                return i;
        }
        return 0;
    }
}

