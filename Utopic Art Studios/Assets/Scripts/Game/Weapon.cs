using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject shooter;
    public GameObject explosionEffect;
    public LineRenderer lineRenderer;

    private Transform _firePoint;

    void Awake()
    {
        _firePoint = transform.Find("FirePoint");
    }

    void Start()
    {
        Shoot();
    }

    void Update()
    {
        
    }

    public void Shoot()
    {
        if (bulletPrefab != null && _firePoint != null && shooter != null)
        {
            GameObject myBullet = Instantiate(bulletPrefab, _firePoint.position, Quaternion.identity) as GameObject;
            Bullet bulletComponent = myBullet.GetComponent<Bullet>();

            bulletComponent.direction = (shooter.transform.localScale.x < 0f ? Vector2.left : Vector2.right);
        }
    }

    public IEnumerator ShootWithRaycast()
    {
        if (explosionEffect != null && lineRenderer != null)
        {
            RaycastHit2D hitInfo = Physics2D.Raycast(_firePoint.position, _firePoint.right);
            if (hitInfo)
            {
                //if(hitInfo.collider.tag == "Player"){
                //  Transform player = hitInfo.transform;
                //  player.GetComponent<PlayerHealt>().ApllyDamage(5);
                Instantiate(explosionEffect, hitInfo.point, Quaternion.identity);

                lineRenderer.SetPosition(0, _firePoint.position);
                lineRenderer.SetPosition(1, hitInfo.point);
            }
            else
            {
                lineRenderer.SetPosition(0, _firePoint.position);
                lineRenderer.SetPosition(1, hitInfo.point + Vector2.right * 100);
            }

            lineRenderer.enabled = true;
            yield return null;

            lineRenderer.enabled = false;
        }
    }
}
