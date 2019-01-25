using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Movement : MonoBehaviour
{// This script determines how camera follows the player.

    public Transform playerTrans;
    public Vector3 camOffset;
    public Transform boundaries;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 camTargetPos = playerTrans.position + camOffset;


        transform.position = new Vector3(camTargetPos.x, camTargetPos.y, transform.position.z);
    }
}
