using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerPoint : MonoBehaviour
{
    public int speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Vector2 v = rb.velocity;
        v.y = -speed;
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
