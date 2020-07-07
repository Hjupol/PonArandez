using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using System;

public class FollowingEnemyController : MonoBehaviour
{
    public Transform target;
    
    public float distance;
    public float nextWayPointDistance = 1f;
    public float speed;

    Path path;
    int currentWaypoint=0;
    bool reachedEndOfPath = false;

    Seeker seeker;
    Rigidbody2D rb;


    void Start()
    {
        target = GameObject.Find("Minion").GetComponent<Transform>();
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        //seeker.StartPath(rb.position, target.position, OnPathComplete);

    }

    private void Update()
    {
        ChechTarget();
    }

    void FixedUpdate()
    {
        if (path == null)
            return;

        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else
        {
            reachedEndOfPath = false;
        }

        Vector2 direction = ((Vector2) path.vectorPath[currentWaypoint+1] - rb.position).normalized;

        Vector2 force = direction * speed * Time.deltaTime;

        rb.AddForce(force);

        float distanceToNxtWp = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if (distance < nextWayPointDistance)
        {
            currentWaypoint++;
        }
    }

    private void ChechTarget()
    {
        if (Vector2.Distance(transform.position, target.transform.position) < distance)
        {
            if(seeker.IsDone())
                seeker.StartPath(rb.position, target.position, OnPathComplete);
        }
        else
        {
            path = null;
        }

    }

     void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;

        }
    }
}
