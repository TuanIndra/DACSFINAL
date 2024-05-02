using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;
public class Health : MonoBehaviour
{
    [SerializeField] int maxHealth;
    int currentHealth;
    public HealthBar healthBar;
    public UnityEvent onDeath;
    public Animator anim;
    public GameObject gameOverCanvas;
    public float maxFallHeight = -6f;
    public int maxHealingCount; // Số lần hồi máu tối đa
    public int currentHealingCount =0; // Số lần hồi máu đã sử dụng


    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.UpdateHealth(currentHealth, maxHealth);
    }
    public void FixedUpdate()
    {
        if (transform.position.y < maxFallHeight)
        {
            currentHealth = 0;
            Die();
        }
    }
    public void Update()
    {
        Recover();  
    }
    //bị gây dame
    public void takeDamage(int damage)
    {
        currentHealth -= damage;
        if(currentHealth < maxHealth) 
        {
            anim.SetTrigger("isHurt");
        }
        if (currentHealth <= 0)
        {
            Die();
        }
        healthBar.UpdateHealth(currentHealth, maxHealth);
    }
    public void HealRandom()
    {
        int minValue = 0;
        int maxValue = 20;
        // Sinh một giá trị ngẫu nhiên trong phạm vi đã cho
        int healAmount = Random.Range(minValue, maxValue);

        // Hồi máu cho đối tượng
        currentHealth += healAmount;

        // Đảm bảo không vượt quá máu tối đa
        currentHealth = Mathf.Min(currentHealth, maxHealth);
    }

    //hồi máu
    public void Recover()
    {
        maxHealingCount = enemyHealth.totalDeathCount;
        if(currentHealingCount < maxHealingCount)
        {
            if (Input.GetKeyDown("c"))
            {
                if (currentHealth < maxHealth)
                {
                    HealRandom();
                    anim.SetTrigger("Recover");
                }
                currentHealingCount++;
                healthBar.UpdateHealth(currentHealth, maxHealth);
            }
            
        }
        else
        {

        }
       
    }
    //chết
    void Die()
    {
        onDeath.Invoke();
        Debug.Log("chet roi");
        anim.SetTrigger("Isdead");
        Time.timeScale = 0f; // Dừng thời gian
        gameOverCanvas.SetActive(true);
    }
}