using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle_Gate : MonoBehaviour
{// This script manages gate opening.

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Open()
    {
        Destroy(this.gameObject);
    }
}
