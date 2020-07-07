using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemyController : MonoBehaviour
{
    private Rigidbody2D enemy;
    public GameObject position1, position2;
    private bool firstMov;
    public float velocity = 2;

    private void Start()
    {
        enemy = GetComponent<Rigidbody2D>();
        firstMov = true;
    }


    void FixedUpdate()
    {
        if (firstMov)
        {
            transform.position = Vector2.MoveTowards(transform.position, position1.transform.position, velocity * Time.deltaTime);
            if (enemy.transform.position == position1.transform.position)
            {
                transform.rotation = new Quaternion(0, 180, 0, 0);
                firstMov = false;
            }
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, position2.transform.position, velocity * Time.deltaTime);
            if (enemy.transform.position == position2.transform.position)
            {
                transform.rotation = new Quaternion(0, 0, 0, 0);
                firstMov = true;
            }
        }
    }
}
