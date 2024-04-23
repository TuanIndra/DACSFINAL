using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth; 
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if(currentHealth <= 0) 
        {
            Die();
            Destroy(gameObject);
        }
    }
    void Die()
    {
        Debug.Log("chet roi");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
