using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Homing_bullet : MonoBehaviour
{
    public GameObject enemy;
    public GameObject enemytag;
    public float speed;
    Vector2 direction;
    private float distance,degree;
    float angle;
    private void Start()
    {

    }
    private void Update()
    {
        
        if (GameObject.FindGameObjectWithTag("Enemy"))
        {
            enemy = GameObject.FindGameObjectWithTag("Enemy");
            distance = Vector2.Distance(transform.position, enemy.transform.position);
            direction = enemy.transform.position - transform.position;
            direction.Normalize();
            angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
            
        }
        else
        {
            degree = gameObject.transform.localRotation.eulerAngles.z;
            Vector2 dir = (Vector2)(Quaternion.Euler(0, 0, degree+90) * Vector2.right);
            dir.Normalize();
            transform.position = transform.position + new Vector3(dir.x * speed * Time.deltaTime, dir.y * speed * Time.deltaTime, 0);
            return;
        } 
        if (distance < 6)
            {
                transform.position = Vector2.MoveTowards(this.transform.position, enemy.transform.position, speed * Time.deltaTime);
                transform.rotation = Quaternion.Euler(Vector3.forward * angle);

            }

        enemytag = null;
                    
    }


    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
