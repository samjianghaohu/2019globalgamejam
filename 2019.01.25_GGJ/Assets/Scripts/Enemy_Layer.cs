using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Layer : MonoBehaviour
{// This script manages layer relations between enemies and player.

    GameObject player;
    SpriteRenderer mySprtrdr;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        mySprtrdr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y < transform.position.y)
        {
            mySprtrdr.sortingOrder = -1;
        }
        else
        {
            mySprtrdr.sortingOrder = 1;
        }
    }
}
