using UnityEngine;

namespace BigRookGames.Weapons
{
    public class GunFireController : MonoBehaviour
    {
        // --- Audio ---
        public AudioClip GunShotClip;
        public AudioSource source;
        public Vector2 audioPitch = new Vector2(.9f, 1.1f);

        // --- Muzzle ---
        public GameObject muzzlePrefab;
        public GameObject muzzlePosition;

        // --- Config ---
        public float shotDelay = 1.5f; 
        public float attackRange = 15f; 
        public float bulletSpeed = 20f; 

        // --- Projectile ---
        public GameObject projectilePrefab;
        public GameObject projectileToDisableOnFire;

        private Transform player;
        private float timeLastFired;
        private bool canShoot = true;

        private void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player")?.transform;
            if (player == null)
            {
                Debug.LogError("Игрок не найден! Добавь тег 'Player' на объект игрока.");
            }

            if (source != null) source.clip = GunShotClip;
            timeLastFired = 0;
        }

        private void Update()
        {
            if (player == null) return;

            // Проверяем дистанцию до игрока
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);
            if (distanceToPlayer <= attackRange && canShoot)
            {
                FireWeapon();
                canShoot = false;
                Invoke(nameof(ResetShoot), shotDelay);
            }
        }

        private void FireWeapon()
        {
            // Запоминаем время выстрела
            timeLastFired = Time.time;

            // Разворачиваем оружие на игрока
            transform.LookAt(player);

            // Создаём эффект выстрела
            Instantiate(muzzlePrefab, muzzlePosition.transform);

            // Стреляем пулей
            if (projectilePrefab != null)
            {
                GameObject newProjectile = Instantiate(projectilePrefab, muzzlePosition.transform.position, muzzlePosition.transform.rotation);
                Rigidbody rb = newProjectile.GetComponent<Rigidbody>();

                if (rb != null)
                {
                    Vector3 direction = (player.position - muzzlePosition.transform.position).normalized;
                    rb.velocity = direction * bulletSpeed;
                }

                Destroy(newProjectile, 5f); // Удаляем пулю через 5 секунд
            }

            // Выключаем объект (если нужно)
            if (projectileToDisableOnFire != null)
            {
                projectileToDisableOnFire.SetActive(false);
                Invoke("ReEnableDisabledProjectile", 3);
            }

            // Воспроизводим звук выстрела
            if (source != null)
            {
                source.Play();
            }
        }

        private void ResetShoot()
        {
            canShoot = true;
        }

        private void ReEnableDisabledProjectile()
        {
            projectileToDisableOnFire.SetActive(true);
        }
    }
}