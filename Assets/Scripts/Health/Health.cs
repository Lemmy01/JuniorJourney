using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header ("Health")]
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }

    private Animator anim;
    private bool isDead;

    [Header("iFrames")]
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int noOfFlashes;

    [SerializeField] private Behaviour[] components;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>(); 
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    

    public void TakeDamage(float _damage) { 
    
        currentHealth = Mathf.Clamp(currentHealth-_damage,0,startingHealth);

        if (currentHealth > 0)
        {
            //hurt
            anim.SetTrigger("hurt");
            StartCoroutine(Invunerability());
        }
        else {
            //die
                Die();       
        }
    }

    public void Die() { 
    if (!isDead)
        {
            anim.SetTrigger("die");
           
            foreach (Behaviour behaviour in components)
            {
                behaviour.enabled = false;
            }

            isDead = true;
        }
    }

   private IEnumerator Invunerability() {
        Physics2D.IgnoreLayerCollision(10, 11, ignore: true);
        for (int i = 0; i < noOfFlashes; i++)
        {
            spriteRenderer.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iFramesDuration / (noOfFlashes*2 ));
            spriteRenderer.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (noOfFlashes * 2));
        }
        Physics2D.IgnoreLayerCollision(10, 11, ignore: false);

    }
}
