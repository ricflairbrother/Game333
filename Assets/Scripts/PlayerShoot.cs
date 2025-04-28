using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject starPrefab;
    public float starSpeed = 25f;
    public bool canShoot = true;
    public float starCooldown = 1;
    public float ammoCount = 5;
    public bool reloading;
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && canShoot == true && ammoCount > 0)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        canShoot = false;

        ammoCount -= 1;

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 shootDirection = (mousePosition - transform.position).normalized;

        GameObject ninjaStar = Instantiate(starPrefab, transform.position, Quaternion.identity);

        ninjaStar.GetComponent<Rigidbody2D>().velocity = new Vector2(shootDirection.x, shootDirection.y).normalized * starSpeed;

        Destroy(ninjaStar, 1f);

        StartCoroutine(ShootCooldown());

        if(ammoCount <= 0)
        {
            Reload();
        }
    }

    void Reload()
    {
        if(!reloading)
        {
            reloading = true;
            StartCoroutine(ReloadingCoroutine());
        }
    }

    private IEnumerator ShootCooldown()
    {
        yield return new WaitForSeconds(starCooldown);
        canShoot = true;
    }

    private IEnumerator ReloadingCoroutine()
    {
        yield return new WaitForSeconds(3);
        Debug.Log("Reloading");
        ammoCount = 5;
        reloading = false;
    }
}
