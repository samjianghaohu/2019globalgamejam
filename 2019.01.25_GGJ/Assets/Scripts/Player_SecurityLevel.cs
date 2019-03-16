using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player_SecurityLevel : MonoBehaviour
{// This script manages the security level.

    public float increaseSpd;
    public float decreaseSpd;
    public bool isKid = false;
    public Slider securitySldr;

    float level = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isKid)
        {
            level += increaseSpd * Time.deltaTime;
            if (level >= 1f)
            {
                level = 1f;
                SceneManager.LoadScene(3);
            }
        }
        else
        {
            level -= decreaseSpd * Time.deltaTime;
            if (level < 0f)
            {
                level = 0f;
            }

        }

        if (level >= 0.78f)
        {
            if (!securitySldr.GetComponent<AudioSource>().isPlaying)
            {
                securitySldr.GetComponent<AudioSource>().Play();
            }
        }
        else
        {
            securitySldr.GetComponent<AudioSource>().Stop();
        }
        DrawLevel();
    }


    void DrawLevel()
    {
        securitySldr.value = level;
        Color sliderColor = Color.Lerp(Color.white, Color.red, level);
        securitySldr.transform.GetChild(1).GetChild(0).GetComponent<Image>().color = sliderColor;
    }
}
