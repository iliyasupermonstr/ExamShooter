using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    [Header("Респавн")]
    public GameObject enemyPrefab; // Префаб врага
    public Transform spawnPoint;   // Точка респавна
    public float respawnDelay = 3f; // Время до респавна

    private void Start()
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

        // Добавляем убийство в GameManager
        if (GameManager.Instance != null)
        {
            GameManager.Instance.AddKill();
        }

        gameObject.SetActive(false); // Отключаем объект
        Invoke(nameof(Respawn), respawnDelay); // Запускаем респавн через заданное время
    }

    private void Respawn()
    {
        if (spawnPoint != null && enemyPrefab != null)
        {
            GameObject newEnemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
            newEnemy.SetActive(true);  // Убедимся, что он активен
        }
        else
        {
            Debug.LogError("Ошибка респавна: не назначен префаб или точка респавна!");
        }
        
        Destroy(gameObject); // Уничтожаем старый объект
    }
}