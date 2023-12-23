using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int damage;
    public int maxHealth;
    public bool isDead;

    [SerializeField] private int currentHealth;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        currentHealth = maxHealth;
    }

    protected virtual void Update()
    {

    }

    public virtual void TakeDamage(int _damage)
    {
        currentHealth -= _damage;

        if (currentHealth < 0 && !isDead)
            Die();
    }

    protected virtual void Die()
    {
        isDead = true;
    }
}
