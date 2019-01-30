using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_FormSwitch : MonoBehaviour
{// This script manages switching between old and kid form.

    int OLD = 0;
    int KID = 1;
    int state = 0;

    public GameObject hudObj;
    public GameObject pageParticlePrefab;
    public bool isSwitcheEnabled = false;

    Player_AnimationController playerAnim;
    Player_Movement playerMv;
    Player_Attack playerAtk;
    Player_SecurityLevel playerSLvl;

    AudioSource changeSFX;
    

    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<Player_AnimationController>();
        playerMv = GetComponent<Player_Movement>();
        playerAtk = GetComponent<Player_Attack>();
        playerSLvl = GetComponent<Player_SecurityLevel>();

        changeSFX = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            if (isSwitcheEnabled)
            {
                GameObject pagesObj = Instantiate(pageParticlePrefab) as GameObject;
                pagesObj.transform.position = transform.position - new Vector3(0, 0.85f, 0);
                changeSFX.Play();

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
    }

    public void ChangeToKid()
    {
        playerMv.mvSpd = 297f;
        playerAnim.BecomeKid();
        hudObj.GetComponent<Animator>().SetTrigger("BecomeKid");
        playerAtk.isEnabled = true;
        playerSLvl.isKid = true;

    }

    public void ChangeToOld()
    {
        playerMv.mvSpd = 180f;
        playerAnim.BecomeOld();
        hudObj.GetComponent<Animator>().SetTrigger("BecomeOld");
        playerAtk.isEnabled = false;
        playerSLvl.isKid = false;
    }
}
