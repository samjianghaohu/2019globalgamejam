using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{ // This scripts manages player movements

    public float mvSpd;
    public bool inCutscene = false;

    Rigidbody2D myRGBody;
    Player_AnimationController myAnim;
    AudioSource walkingSFX;
   

    // Start is called before the first frame update
    void Start()
    {
        myRGBody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Player_AnimationController>();
        walkingSFX = transform.GetChild(3).GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!inCutscene)
        {
            myRGBody.velocity = Vector2.zero;

            if (Input.GetKey(KeyCode.UpArrow))
            {
                myRGBody.velocity = new Vector2(myRGBody.velocity.x, 1f * mvSpd * Time.deltaTime); 
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                myRGBody.velocity = new Vector2(myRGBody.velocity.x, -1f * mvSpd * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                myRGBody.velocity = new Vector2(-1 * mvSpd * Time.deltaTime, myRGBody.velocity.y);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                myRGBody.velocity = new Vector2(1 * mvSpd * Time.deltaTime, myRGBody.velocity.y);
            }
        }
        else
        {
            myRGBody.velocity = Vector2.zero;
        }

        // Trigger/Stoping walking animation and sfx
        if (myRGBody.velocity == Vector2.zero)
        {
            myAnim.StopWalking();
            walkingSFX.Stop();
        }
        else
        {
            myAnim.StartWalking();
            if (!walkingSFX.isPlaying)
            {
                walkingSFX.Play();
            }
        }

        // Flip character depending on direction
        if (myRGBody.velocity.x > 0)
        {
            transform.eulerAngles = new Vector3(transform.rotation.x, 180, transform.rotation.z);
        }
        else if (myRGBody.velocity.x < 0)
        {
            transform.eulerAngles = new Vector3(transform.rotation.x, 0, transform.rotation.z);
        }
    }
}
