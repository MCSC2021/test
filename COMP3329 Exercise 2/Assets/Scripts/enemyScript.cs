using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class enemyScript : MonoBehaviour
{
    // Public variable that contains the speed of the enemy
    public GameObject fireEffect;
    public GameObject PowerUP;
    public int speed = 5;
    public int HP = 10;
    bool isalive;
    // Start is called before the first frame update
    void Start()
    {
        isalive = true;
        //Add a vertical speed to the enemy
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Vector2 v = rb.velocity;
        v.x = 0;
        v.y = -speed;
        rb.velocity = v;
        // Make the enemy rotate on itself
        rb.angularVelocity = UnityEngine.Random.Range(-200, 200);
        // Destroy the enemy in 3 seconds, when it is no longer visible on the screen
        Destroy(gameObject, 3);
    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        string name = obj.gameObject.name;

        // If it collided with a bullet
        if (name == "bullet(Clone)")
        {
            if (HP > 0)
            {
                HP = HP - 1;
            }
            else
            {
                destroyState();
                return;
            }
            // And destroy the bullet
            Destroy(obj.gameObject);
            ScoreSystem.instance.addscore(1);
        }
        // If it collided with homing a bullet
        if (name == "bullet home 1(Clone)")
        {
            if (HP > 0)
            {
                HP = HP - 10;
            }
            else
            {
                destroyState();
                return;
            }
            // And destroy the bullet
            Destroy(obj.gameObject);
            ScoreSystem.instance.addscore(5);
        }
        // If it collided with the spaceship
        if (name == "spaceship")
        {
            Life.instance.lifereduce(1);
            // Destroy itself (the enemy) to keep things simple
            Destroy(gameObject);
        }
    }
    
    // Update is called once per frame
    void destroyState()
    {
        if (isalive == true)
        {
            // Destroy itself (the enemy)
            Destroy(gameObject);
            Instantiate(fireEffect, transform.position, Quaternion.identity);
            Instantiate(PowerUP, transform.position, Quaternion.identity);
            isalive = false;
            ScoreSystem.instance.addscore(10);
        }
    }
}
