using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public int speed = 30;

    // Start is called before the first frame update
    void Start()
    {
        // Set the vertical speed to make the bullet move upward
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Vector2 v = rb.velocity;
        v.y = speed;
        rb.velocity = v;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
