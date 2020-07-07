using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonController : MonoBehaviour
{
    public GameObject target;
    public Rigidbody2D projectile;
    public float distance;
    public float shootTime = 5;
    private float initialShootTime;

    void Start()
    {
        initialShootTime = shootTime;
        target = GameObject.Find("Minion");
    }

    void Update()
    {
        ChechTarget();
    }

    private void ChechTarget()
    {
        shootTime -= Time.deltaTime;
        if (Vector2.Distance(transform.position, target.transform.position) < distance)
            {
                
                if (shootTime < 0)
                {
                    Rigidbody2D _projectile = projectile;
                    Instantiate(_projectile, transform.position, Quaternion.identity);
                    
                    
                ProjectileBehaviour p = _projectile.GetComponent<ProjectileBehaviour>();
                p.direction = (target.transform.position - transform.position).normalized;
                //_projectile.AddForce()
                shootTime = initialShootTime;
                }

            }
            else
            {
                shootTime = initialShootTime;
            }
        
    }
}
