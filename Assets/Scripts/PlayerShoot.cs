using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject starPrefab;
    public float starSpeed = 50f;
    public bool canShoot = true;
    public float starCooldown = 1;
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && canShoot == true)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        canShoot = false;

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 shootDirection = (mousePosition - transform.position).normalized;

        GameObject ninjaStar = Instantiate(starPrefab, transform.position, Quaternion.identity);

        ninjaStar.GetComponent<Rigidbody2D>().velocity = new Vector2(shootDirection.x, shootDirection.y) * starSpeed;

        Destroy(ninjaStar, 2f);

        StartCoroutine(ShootCooldown());
    }

    private IEnumerator ShootCooldown()
    {
        yield return new WaitForSeconds(starCooldown);
        canShoot = true;
    }
}
