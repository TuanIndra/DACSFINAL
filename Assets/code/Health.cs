using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Health : MonoBehaviour
{
    [SerializeField] int maxHealth;
    int currentHealth;
    public HealthBar healthBar;
    public UnityEvent onDeath;
    public Animator anim;
    
    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.UpdateHealth(currentHealth, maxHealth);
    }
    public void takeDamage(int damage)
    {
        currentHealth -= damage;
        if(currentHealth < maxHealth) 
        {
            anim.SetTrigger("isHurt");
        }
        if (currentHealth <= 0)
        {
            onDeath.Invoke();
            anim.SetTrigger("Isdead");
        }
        healthBar.UpdateHealth(currentHealth, maxHealth);
    }
     
}