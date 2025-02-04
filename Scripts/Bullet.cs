using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject bulletPrefab; // Префаб пули
    public Transform firePoint;     // Точка вылета пули
    public float bulletSpeed = 20f; // Скорость пули
    public float bulletLifetime = 5f; // Время жизни пули

    public void Shoot()
    {
        if (bulletPrefab != null && firePoint != null)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

            
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            if (rb == null)
            {
                rb = bullet.AddComponent<Rigidbody>(); 
            }

            rb.useGravity = false; 
            rb.velocity = firePoint.forward * bulletSpeed; 


            Destroy(bullet, bulletLifetime);
        }
    }
}