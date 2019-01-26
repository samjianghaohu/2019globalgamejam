using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_LifePoints : MonoBehaviour
{// This script manages player taking damage.

    int lifePoint = 3;
    public GameObject hud;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (lifePoint <= 0)
        {
            Debug.Log("Game Over");
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemies") { 
            lifePoint -= 1;
            hud.GetComponent<Animator>().SetTrigger("ReduceLP");
        }

    }
}
