using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100; 
    private int currentHealth;

    public void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Враг получил урон: " + damage + ". Текущее здоровье врага: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Враг погиб!");
        Destroy(gameObject); 
    }
}