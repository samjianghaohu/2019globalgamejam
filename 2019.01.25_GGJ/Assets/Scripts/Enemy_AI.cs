using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AI : MonoBehaviour
{ // This scripts determines generic enemy AI (patrol and chase)

    int PATROL = 0;
    int CHASE = 1;
    int state = 0;

    public Vector3[] waypoints;
    public float patrolSpd;

    int patrolPhaseNum;
    int patrolTurningBack;
    int currentPhase = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        patrolPhaseNum = 2 * (waypoints.Length - 1);
        patrolTurningBack = patrolPhaseNum / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (state == PATROL)
        {
            Vector3 targetPos;
            if (currentPhase <= patrolPhaseNum)
            {
                targetPos = waypoints[currentPhase];
            }
            else
            {
                targetPos = waypoints[currentPhase - patrolTurningBack];
            }
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, targetPos, patrolSpd * Time.deltaTime);
            if (Vector3.Distance(transform.localPosition, targetPos) <= 0.0001f)
            {
                currentPhase += 1;
                currentPhase = currentPhase % patrolPhaseNum;
            }
        }
    }
}
