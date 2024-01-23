using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spaceshipScript : MonoBehaviour
{
    public GameObject bullet, bullet2;
    private Rigidbody2D rb;
    private Vector2 v;
    public float interval = 20;
    float timer;
    int Points,count;
    bool flag;


    // Start is called before the first frame update
    void Start()
    {
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        rb = GetComponent<Rigidbody2D>();
        v = rb.velocity;
        // GetAxis() returns a value between 1 and -1. Depending on which arrow key is
        // pressed. So we change the spaceship X speed by GetAxis("Horizontal") * 10
        v.x = Input.GetAxis("Horizontal") * 10;
        v.y = Input.GetAxis("Vertical") * 10;
        rb.velocity = v;
        timer += Time.deltaTime;
        if (timer >= interval && Input.GetKey("space"))
        {
            Shooting();
            timer -= interval;
            if(count > 3)
            {
                Homing();
                count = 0;
            }
            count++;
        }

    }
    void OnTriggerEnter2D(Collider2D obj)
    {
        string _name = obj.gameObject.name;
        // If it collided with the spaceship
        if (_name == "BB(Clone)")
        {
            Points += 5;
            Destroy(obj.gameObject);
            ScoreSystem.instance.addscore(10);
        }
    }
    void Shooting()
    {

        if (Points < 10)
        {
            Instantiate(bullet, transform.position + new Vector3(0.1f, 0, 0), Quaternion.identity);
            Instantiate(bullet, transform.position + new Vector3(-0.1f, 0, 0), Quaternion.identity);
        }
        else if (Points < 20)
        {
            Instantiate(bullet, transform.position + new Vector3(0.15f, 0, 0), Quaternion.identity);
            Instantiate(bullet, transform.position + new Vector3(-0.15f, 0, 0), Quaternion.identity);
            Instantiate(bullet, transform.position, Quaternion.identity);
            
        }
        else
        {
            Instantiate(bullet, transform.position + new Vector3(0.15f, 0, 0), Quaternion.identity);
            Instantiate(bullet, transform.position + new Vector3(-0.15f, 0, 0), Quaternion.identity);
            Instantiate(bullet, transform.position, Quaternion.identity);

        }
    }

    void Homing()
    {
        if (Points < 20) return;
        if (flag)
        {
            Instantiate(bullet2, transform.position + new Vector3(0.5f, 0, 0), Quaternion.Euler(0,0,60));
            flag = false;
        }
        else
        {
            Instantiate(bullet2, transform.position + new Vector3(-0.5f, 0, 0), Quaternion.Euler(0, 0, -60));
            flag = true;
        } 
    }

}
