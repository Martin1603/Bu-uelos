using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy2 : MonoBehaviour
{
    public float moveSpeed;
    public GameObject[] waypoints;

    int nextWaypoint = 0;
    float distToPoint;
    // Update is called once per frame
    void Update()
    {
        Move();
    }
    void Move()
    {
        distToPoint = Vector2.Distance(transform.position, waypoints[nextWaypoint].transform.position);

        transform.position = Vector2.MoveTowards(transform.position, waypoints[nextWaypoint].transform.position, moveSpeed * Time.deltaTime);

        if(distToPoint < 0.2f)
        {
            TakeTurn();
        }
    }

    void TakeTurn()
    {
        Vector3 currRot = transform.eulerAngles;
        currRot.z += waypoints[nextWaypoint].transform.eulerAngles.z;
        transform.eulerAngles = currRot;
        ChooseNextWayPoint();
    }
    void ChooseNextWayPoint()
    {
        nextWaypoint++;

        if(nextWaypoint == waypoints.Length)
        {
            nextWaypoint = 0;
        }
    }
}
