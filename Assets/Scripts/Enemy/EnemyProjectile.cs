using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : EnemyDamage
{
    [SerializeField] float speed;
    [SerializeField] float resetTime;
    float lifeTime;
    float direction = 1;
    public void ActivateProjectile(float _direction) {
        lifeTime = 0;
        gameObject.SetActive(true);
        direction = _direction;
    }

    private void Update()
    {
        float movmentSpeed =  speed * Time.deltaTime;

        transform.Translate(direction * movmentSpeed, 0, 0);

        lifeTime += Time.deltaTime;

        if(lifeTime > resetTime)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        gameObject.SetActive(false);

    }
}
