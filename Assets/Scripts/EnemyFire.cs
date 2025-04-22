using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    public GameObject rock;
    public Transform rockPos;
    public Animator animator;

    private float timer;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);
        Debug.Log(distance);

        if(distance < 10)
        {
            timer += Time.deltaTime;
            animator.SetTrigger("Throw");
            if (timer > 2)
            {
                timer = 0;
                Fire();
                animator.SetTrigger("NotThrow");
            }
        }
        if (distance > 10)
        {
            animator.SetTrigger("NotThrow");
        }
    }

    void Fire()
    {
        Instantiate(rock, rockPos.position, Quaternion.identity);
    }
}
