using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_NoteJump : MonoBehaviour
{// This script manages jumping of music note enemies

    public float jumpIntervals;
    public Vector3[] jumpPos;

    float jumpTimer;
    int nextJump = 1;

    // Start is called before the first frame update
    void Start()
    {
        jumpTimer = jumpIntervals;
    }

    // Update is called once per frame
    void Update()
    {
        jumpTimer -= Time.deltaTime;
        if (jumpTimer <= 0f)
        {
            int posIndx = nextJump % jumpPos.Length;
            Jump(jumpPos[posIndx]);
            nextJump += 1;
            jumpTimer = jumpIntervals;
        }
    }

    void Jump(Vector3 nextPos)
    {
        transform.localPosition = nextPos;
    }
}
