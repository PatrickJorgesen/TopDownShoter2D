using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    public float moveSpeed;
    [SerializeField] float rotationSpeed = 2000;

    public Rigidbody2D rb;

    Vector2 screenBoundery;
    Vector2 moveDir;

    void Update()
    {
        float moveDirX = Input.GetAxisRaw("Horizontal");
        float moveDirY = Input.GetAxisRaw("Vertical");

        moveDir = new Vector2(moveDirX, moveDirY).normalized;

        if (moveDir != Vector2.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(transform.forward, moveDir);
            Quaternion rotate = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            rb.MoveRotation(rotate);
        }
        else
        {
            rb.angularVelocity = 0;
        }

        screenBoundery = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -screenBoundery.x, screenBoundery.x), Mathf.Clamp(transform.position.y, -screenBoundery.y, screenBoundery.y));
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDir.x * moveSpeed, moveDir.y * moveSpeed);
    }
}
