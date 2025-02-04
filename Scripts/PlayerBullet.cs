using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public int damage = 20; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();

            if (enemyHealth != null)
            {
				Debug.Log("Враг получил урок");
                enemyHealth.TakeDamage(damage);
            }
			if(!other.CompareTag("Weapon"))
            {
				Destroy(gameObject);
			} 
        }
    }
}