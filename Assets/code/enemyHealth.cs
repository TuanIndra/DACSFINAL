using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    public int maxHealth;
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
    // Biến để lưu trữ tổng số lần chết của tất cả các địch
    public static int totalDeathCount = 0; 

    private void OnDestroy()
    {
        
        totalDeathCount++;  
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
