using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    [SerializeField] int playerHealth = 5;
    [SerializeField] float iFrames = 2;
    bool invincibel = false;

    void DisavleInvincibel()
    {
        invincibel = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) 
        {
            if (invincibel == true)
            {
                return;
            }
            if(playerHealth > 0)
            {
                playerHealth--;
                invincibel = true;
                Invoke("DisavleInvincibel", iFrames);
                Debug.Log("Player health: " +  playerHealth);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
