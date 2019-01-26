using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack : MonoBehaviour
{// This scirpt manages player attack (as kid fox).

    public bool isEnabled = false;
    public float attackLast;

    float attackTimer;
    Player_AnimationController myAnimControl;

    // Start is called before the first frame update
    void Start()
    {
        myAnimControl = GetComponent<Player_AnimationController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isEnabled)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Attack();
            }

            attackTimer -= Time.deltaTime;
            if (attackTimer <= 0f)
            {
                transform.GetChild(0).gameObject.SetActive(false);
                GetComponent<Player_Movement>().mvSpd = 297f;
            }
            else
            {
                GetComponent<Player_Movement>().mvSpd = 238f;
            }
        }
    }


    void Attack()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        myAnimControl.Attack();
        attackTimer = attackLast;
    }
}
