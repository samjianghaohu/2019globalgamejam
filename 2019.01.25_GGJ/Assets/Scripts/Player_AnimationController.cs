using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_AnimationController : MonoBehaviour
{// This script manages player animation;

    Animator myAnimator;
    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void BecomeKid()
    {
        myAnimator.SetTrigger("BecomeKid");
    }


    public void BecomeOld()
    {
        myAnimator.SetTrigger("BecomeOld");
    }

    public void StartWalking() {
        myAnimator.SetBool("IsWalking", true);
    }

    public void StopWalking()
    {
        myAnimator.SetBool("IsWalking", false);
    }


    public void Attack()
    {
        myAnimator.SetTrigger("Attack");
    }
}
