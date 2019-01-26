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
    public LayerMask myLayerMask;

    int patrolPhaseNum;
    int patrolTurningBack;
    int currentPhase = 1;

    Transform playerTrans;
    Animator myAnimator;

    
    // Start is called before the first frame update
    void Start()
    {
        patrolPhaseNum = 2 * (waypoints.Length - 1);
        patrolTurningBack = patrolPhaseNum / 2;

        playerTrans = GameObject.FindWithTag("Player").transform;
        myAnimator = GetComponent<Animator>();
       
    }

    // Update is called once per frame
    void Update()
    {

        myAnimator.SetBool("IsWalking", true);
       
        if (state == PATROL)
        {
            Vector3 targetPos;
            if (currentPhase <= patrolTurningBack)
            {
                targetPos = waypoints[currentPhase];
            }
            else
            {
                targetPos = waypoints[waypoints.Length - 1 - (currentPhase - patrolTurningBack)];
            }

            // Flip itself depending on the direction it's going.
            if (targetPos.x >= transform.localPosition.x)
            {
                transform.eulerAngles = new Vector3(transform.rotation.x, 180, transform.rotation.z);
            }
            else
            {
                transform.eulerAngles = new Vector3(transform.rotation.x, 0, transform.rotation.z);
            }

            // Change walking loop when walking up.
            if (targetPos.y > transform.localPosition.y && Mathf.Abs(targetPos.y - transform.localPosition.y) > Mathf.Abs(targetPos.x - transform.localPosition.x))
            {
                myAnimator.SetBool("IsUp", true);
                
            }
            else
            {
                myAnimator.SetBool("IsUp", false);

            }


            // Change detect areas based on the direction it's going.
            if (Mathf.Abs(targetPos.x - transform.localPosition.x) >= 0.0001f)
            {
                transform.GetChild(0).gameObject.SetActive(true);
                transform.GetChild(1).gameObject.SetActive(false);
                transform.GetChild(2).gameObject.SetActive(false);
            }
            else
            {
                if (targetPos.y > transform.localPosition.y)
                {
                    transform.GetChild(0).gameObject.SetActive(false);
                    transform.GetChild(1).gameObject.SetActive(true);
                    transform.GetChild(2).gameObject.SetActive(false);

                }
                else
                {
                    transform.GetChild(0).gameObject.SetActive(false);
                    transform.GetChild(1).gameObject.SetActive(false);
                    transform.GetChild(2).gameObject.SetActive(true);
                }
            }

            transform.localPosition = Vector3.MoveTowards(transform.localPosition, targetPos, patrolSpd * Time.deltaTime);
            if (Vector3.Distance(transform.localPosition, targetPos) <= 0.0001f)
            {
                currentPhase += 1;
                currentPhase = currentPhase % patrolPhaseNum;
            }
        }else if (state == CHASE)
        {
            // Look at the player
            RaycastHit2D hit = Physics2D.Raycast(transform.position, (playerTrans.position - transform.position), Mathf.Infinity, myLayerMask);
            //If enemy is able to see player
            if (hit != null && hit.collider != null && hit.collider.tag == "Player")
            {
                if (hit.distance <= 6f)
                { // Chase player if player's close by
                    ChasePlayer();
                }
                else
                {
                    state = PATROL;
                }




                //Unless enemy is stunned, it should tay patrolling if player is blocked and enemy can't see it
            }
        }
    }

    public void Chase()
    {
        if (state != CHASE)
        {
            state = CHASE;
        }
    }


    void ChasePlayer()
    {
        // Flip itself depending on the direction it's going.
        if (playerTrans.position.x >= transform.position.x)
        {
            transform.eulerAngles = new Vector3(transform.rotation.x, 180, transform.rotation.z);
        }
        else
        {
            transform.eulerAngles = new Vector3(transform.rotation.x, 0, transform.rotation.z);
        }


        // Change walking loop when walking up.
        if (playerTrans.position.y > transform.position.y && Mathf.Abs(playerTrans.position.y - transform.position.y) > Mathf.Abs(playerTrans.position.x - transform.position.x))
        {
            myAnimator.SetBool("IsUp", true);

        }
        else
        {
            myAnimator.SetBool("IsUp", false);

        }


        transform.position = Vector3.MoveTowards(transform.position, playerTrans.position, patrolSpd * Time.deltaTime);
    }

}
