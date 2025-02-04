using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private Transform leftEdge;

    [SerializeField] private Transform rightEdge;

    [SerializeField] private Transform enemy;

    [SerializeField] private float speed;

    [SerializeField] private Animator anim;

    [SerializeField] private float idleDuration;
    private float idleTimer;

    private Vector3 initScale;
    private bool movingLeft;

  

    private void Awake()
    {
        initScale = enemy.localScale;
    }

    private void Update()
    {
        if (movingLeft) {
            if (enemy.position.x >= leftEdge.position.x) {
                MoveInDirection(-1);
            }
            else
            {
                DirectionChange();
            }
        }
        else {
            if (enemy.position.x <= rightEdge.position.x)
            {
                MoveInDirection(1);
            }
            else
            {
                DirectionChange();
            }
        }
    }

    private void OnDisable()
    {
        anim.SetBool("isWalking", false);
    }
    private void DirectionChange()
    {
        anim.SetBool("isWalking", false);

        idleTimer += Time.deltaTime;

        if(idleTimer > idleDuration) 
            movingLeft = !movingLeft;
    }
    private void MoveInDirection(int direction) {
        idleTimer = 0;

        anim.SetBool("isWalking", true);
        enemy.localScale = new Vector3 (Mathf.Abs(initScale.x) * direction, initScale.y);

        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * direction * speed, enemy.position.y);
    }
}
