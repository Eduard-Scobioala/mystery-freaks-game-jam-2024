using UnityEngine;

public class ShootingController : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bulletPrefab;

    [Range(0.1f, 1f)]
    [SerializeField] private float fireRate = 0.2f;
    private float fireTimer = 0f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && fireTimer < 0f)
        {
            Shoot();
            fireTimer  = fireRate;
        }
        else
        {
            fireTimer -= Time.deltaTime;
        }
    }

    private void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
