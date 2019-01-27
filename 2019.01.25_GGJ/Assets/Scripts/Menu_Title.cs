using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Title : MonoBehaviour
{
    int START = 0;
    int QUIT = 1;
    int select = 0;

    public Vector3 iconPos1;
    public Vector3 iconPos2;

    AudioSource selectSFX;

    // Start is called before the first frame update
    void Start()
    {
        selectSFX = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            select += 1;
            selectSFX.Play();
        }
        PlaceIcon();
        SelectOpt();
    }


    void PlaceIcon()
    {
        if (select % 2 == START)
        {
            transform.position = iconPos1;
        }
        else
        {
            transform.position = iconPos2;
        }
    }


    void SelectOpt()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.J))
        {
            if (select % 2 == START)
            {
                SceneManager.LoadScene(2);
            }
            else
            {
                Application.Quit();
            }
        }else if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
