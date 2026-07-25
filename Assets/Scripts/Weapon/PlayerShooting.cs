using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 0.5f;

    private float fireCooldown;

    void Update()
    {
        fireCooldown -= Time.deltaTime;

        if (Input.GetMouseButtonDown(0) && fireCooldown <= 0)
        {
            Shoot();
            fireCooldown = fireRate;
        }
    }

    void Shoot()
    {
        // Spawn bullet at exactly the firePoint position and rotation
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}