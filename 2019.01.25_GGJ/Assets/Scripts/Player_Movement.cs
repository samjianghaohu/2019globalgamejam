using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{ // This scripts manages player movements
    public float mvSpd;
    Rigidbody2D myRGBody;
   

    // Start is called before the first frame update
    void Start()
    {
        myRGBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            myRGBody.velocity = new Vector2(0, 1f) * mvSpd * Time.deltaTime;
        }else if (Input.GetKey(KeyCode.DownArrow))
        {
            myRGBody.velocity = new Vector2(0, -1f) * mvSpd * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            myRGBody.velocity = new Vector2(-1, 0) * mvSpd * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            myRGBody.velocity = new Vector2(1, 0) * mvSpd * Time.deltaTime;
        }
        else
        {
            myRGBody.velocity = Vector2.zero;
        }
    }
}
