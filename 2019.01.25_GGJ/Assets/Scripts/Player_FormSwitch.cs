using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_FormSwitch : MonoBehaviour
{// This script manages switching between old and kid form.

    int OLD = 0;
    int KID = 1;
    int state = 0;

    public GameObject hudObj;

    GameObject player;
    Player_AnimationController playerAnim;
    Player_Movement playerMv;
    

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerAnim = player.GetComponent<Player_AnimationController>();
        playerMv = player.GetComponent<Player_Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            if (state == OLD)
            {
                ChangeToKid();
                state = KID;
            }
            else if (state == KID)
            {
                ChangeToOld();
                state = OLD;
            }
        }
    }

    public void ChangeToKid()
    {
        playerMv.mvSpd = 350f;
        playerAnim.BecomeKid();
        hudObj.GetComponent<Animator>().SetTrigger("BecomeKid");

    }

    public void ChangeToOld()
    {
        playerMv.mvSpd = 200f;
        playerAnim.BecomeOld();
        hudObj.GetComponent<Animator>().SetTrigger("BecomeOld");
    }
}
