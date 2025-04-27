using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trap : MonoBehaviour
{
    public float bounceForce = 10f;
    public int damage = 25;
    public PlayerHealth playerHealth;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            HandlePlayerBounce(collision.gameObject);
            Debug.Log("Bounce");
        }
    }

    private void HandlePlayerBounce(GameObject player)
    {
        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();

        if(rb)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0f);

            rb.AddForce(Vector2.up * bounceForce, ForceMode2D.Impulse);
        }
    }
}
