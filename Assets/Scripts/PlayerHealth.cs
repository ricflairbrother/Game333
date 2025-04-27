using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth;
    public Image healthBar;
    public float currentShield;
    public float maxShield;
    public Image shieldBar;

    [SerializeField] private float iFrameDuration;
    [SerializeField] private int numberOfFlashes = 3;

    private SpriteRenderer spriteRenderer;

    public GameController gameController;

    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        ResetHealth();
        maxShield = 100;
        currentShield = 0;
        shieldBar.fillAmount = currentShield;
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = Mathf.Clamp(currentHealth / maxHealth, 0, 100);
        shieldBar.fillAmount = Mathf.Clamp(currentShield / maxShield, 0, 25);
    }

    void ResetHealth()
    {
        maxHealth = 100;
        currentHealth = maxHealth;
        healthBar.fillAmount = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if(currentShield > 0)
        {
            currentShield -= 25;
            StartCoroutine(FlashRed());
            return;
        }
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            SceneTransition.numOfLives -= 1;
            if(SceneTransition.numOfLives <= 0)
            {
                SceneManager.LoadScene("GameOverMenu");
                return;
            }
            else if(SceneTransition.numOfLives > 0)
            {
                gameController.GameOverScreen();
                return;
            }
        }
        else if(currentHealth > 0)
        {
            StartCoroutine(FlashRed());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Projectile"))
        {
            TakeDamage(25);
        }
        else if(collision.gameObject.CompareTag("Spike"))
        {
            TakeDamage(25);
        }
    }

    public void GainHealth(int gainedHealth)
    {
        currentHealth += gainedHealth;
    }

    public void GainShield(int gainedShield)
    {
        currentShield += gainedShield;
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
