using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth;
    public Image healthBar;

    [SerializeField] private float iFrameDuration;
    [SerializeField] private int numberOfFlashes = 3;

    private SpriteRenderer spriteRenderer;

    public static event Action OnPlayerDied;

    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        ResetHealth();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        GameController.OnRestart += ResetHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = Mathf.Clamp(currentHealth / maxHealth, 0, 100);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(25);
        }
        else if(collision.gameObject.CompareTag("Projectile"))
        {
            TakeDamage(25);
        }
    }

    void ResetHealth()
    {
        maxHealth = 100;
        currentHealth = maxHealth;
        healthBar.fillAmount = maxHealth;
    }

    private void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            Debug.Log("First Success");
            OnPlayerDied.Invoke();
        }
        else if(currentHealth > 0)
        {
            StartCoroutine(FlashRed());
        }
    }

    private IEnumerator FlashRed()
    {
        Physics2D.IgnoreLayerCollision(8, 9, true);
        for(int i = 0; i < numberOfFlashes; i++)
        {
            spriteRenderer.color = Color.red;
            yield return new WaitForSeconds(iFrameDuration/numberOfFlashes);
            spriteRenderer.color = Color.white;
            yield return new WaitForSeconds(iFrameDuration/numberOfFlashes);
        }
        spriteRenderer.color = Color.white;
        Physics2D.IgnoreLayerCollision(8, 9, false);
    }
}
