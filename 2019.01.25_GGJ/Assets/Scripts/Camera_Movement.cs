using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Movement : MonoBehaviour
{// This script determines how camera follows the player.

    public Transform playerTrans;
    public Vector3 camOffset;
    public Transform boundaries;
    public bool inCutscene = false;

    float halfHeight;
    float halfWidth;
    Camera myCam;

    // Start is called before the first frame update
    void Start()
    {
        myCam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!inCutscene)
        {
            // Get camera view size
            halfHeight = myCam.orthographicSize;
            halfWidth = myCam.aspect * halfHeight;

            // Get the max&min positions for cam movement
            Vector3 camTargetPos = playerTrans.position + camOffset;
            float camxMin = boundaries.GetChild(0).position.x + halfWidth;
            float camxMax = boundaries.GetChild(1).position.x - halfWidth;
            float camyMin = boundaries.GetChild(2).position.y + halfHeight;
            float camyMax = boundaries.GetChild(3).position.y - halfHeight;

            // Check with x boundaries
            if (camTargetPos.x > camxMax)
            {
                camTargetPos = new Vector3(camxMax, camTargetPos.y, camTargetPos.z);
            }
            else if (camTargetPos.x < camxMin)
            {
                camTargetPos = new Vector3(camxMin, camTargetPos.y, camTargetPos.z);
            }


            // Check with y boundaries
            if (camTargetPos.y > camyMax)
            {
                camTargetPos = new Vector3(camTargetPos.x, camyMax, camTargetPos.z);
            }
            else if (camTargetPos.y < camyMin)
            {
                camTargetPos = new Vector3(camTargetPos.x, camyMin, camTargetPos.z);
            }

            transform.position = new Vector3(camTargetPos.x, camTargetPos.y, transform.position.z);
        } // apply new pos
    }
}
