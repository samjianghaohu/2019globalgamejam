using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_TVOnOff : MonoBehaviour
{// This script manages TV on & offs.

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GetComponent<Animator>().SetTrigger("TurnOn");
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GetComponent<Animator>().SetTrigger("TurnOff");
        }
    }
}
