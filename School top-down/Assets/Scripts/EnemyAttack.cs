using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAttack : MonoBehaviour
{
    [SerializeField] float enemySpeed = 2;
    Rigidbody2D rb;
    GameObject player;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        if (player != null)
        {
            Vector2 lookDir = player.transform.position - transform.position;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
            rb.rotation = angle;
        }
    }

    void FixedUpdate()
    {
        if (player != null)
        {
            Vector2 dir = (player.transform.position - transform.position).normalized;
            rb.MovePosition(rb.position + dir * enemySpeed);
        }
    }
}
