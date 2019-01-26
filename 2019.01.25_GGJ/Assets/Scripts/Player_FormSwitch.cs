﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_FormSwitch : MonoBehaviour
{// This script manages switching between old and kid form.

    int OLD = 0;
    int KID = 1;
    int state = 0;

    public GameObject hudObj;

    Player_AnimationController playerAnim;
    Player_Movement playerMv;
    Player_Attack playerAtk;
    

    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<Player_AnimationController>();
        playerMv = GetComponent<Player_Movement>();
        playerAtk = GetComponent<Player_Attack>();
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
        playerMv.mvSpd = 297f;
        playerAnim.BecomeKid();
        hudObj.GetComponent<Animator>().SetTrigger("BecomeKid");
        playerAtk.isEnabled = true;

    }

    public void ChangeToOld()
    {
        playerMv.mvSpd = 170f;
        playerAnim.BecomeOld();
        hudObj.GetComponent<Animator>().SetTrigger("BecomeOld");
        playerAtk.isEnabled = false;
    }
}
