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
    public AudioClip cursorMove;
    public AudioClip selectConfirm;

    bool selectLock = false;
    bool isConfirmSFXPlayed = false;
    AudioSource selectSFX;

    // Start is called before the first frame update
    void Start()
    {
        selectSFX = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        PlaceIcon();

        if (!selectLock)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                select += 1;
                selectSFX.clip = cursorMove;
                selectSFX.Play();
            }
            SelectOpt();
        }

        if (isConfirmSFXPlayed)
        {
            if (!selectSFX.isPlaying)
            {
                if (select % 2 == START)
                {
                    SceneManager.LoadScene(2);
                }
                else
                {
                    Application.Quit();
                }
            }
        }
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
                if (!isConfirmSFXPlayed)
                {
                    selectSFX.clip = selectConfirm;
                    selectSFX.Play();
                    isConfirmSFXPlayed = true;
                    selectLock = true;
                }
            }
            else
            {
                if (!isConfirmSFXPlayed)
                {
                    selectSFX.clip = selectConfirm;
                    selectSFX.Play();
                    isConfirmSFXPlayed = true;
                    selectLock = true;
                }
            }
        }else if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
