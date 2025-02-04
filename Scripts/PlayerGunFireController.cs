using UnityEngine;

public class PlayerGunFireController : MonoBehaviour
{
    // --- Настройки звука ---
    public AudioClip gunShotClip;
    public AudioSource source;
    public Vector2 audioPitch = new Vector2(.9f, 1.1f);

    // --- Точка выстрела и эффекты ---
    public GameObject muzzlePrefab;
    public Transform muzzlePosition;

    // --- Конфигурация стрельбы ---
    public float shotDelay = 0.2f; // Задержка между выстрелами
    public float bulletSpeed = 50f; // Скорость пули
    public GameObject projectilePrefab; // Префаб пули

    private float lastShotTime;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time >= lastShotTime + shotDelay)
        {
            FireWeapon();
            lastShotTime = Time.time;
        }
    }

    private void FireWeapon()
    {
        // --- Создаем эффект выстрела ---
        if (muzzlePrefab)
        {
            Instantiate(muzzlePrefab, muzzlePosition.position, muzzlePosition.rotation);
        }

        // --- Спавн пули ---
        if (projectilePrefab)
        {
            GameObject newProjectile = Instantiate(projectilePrefab, muzzlePosition.position, Quaternion.identity);
            Rigidbody rb = newProjectile.GetComponent<Rigidbody>();

            if (rb)
            {
                // Направление из центра камеры (имитирует прицел)
                Vector3 shootDirection = Camera.main.transform.forward;

                // Задаем направление пули
                newProjectile.transform.rotation = Quaternion.LookRotation(shootDirection);
                rb.velocity = shootDirection * bulletSpeed;
            }

            Destroy(newProjectile, 5f); // Удаляем пулю через 5 секунд
        }

        // --- Воспроизведение звука выстрела ---
        if (source)
        {
            source.pitch = Random.Range(audioPitch.x, audioPitch.y);
            source.PlayOneShot(gunShotClip);
        }
    }
}