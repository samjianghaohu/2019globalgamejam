using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu_Title : MonoBehaviour
{
    int START = 0;
    int QUIT = 1;
    int select = 0;

    public Vector3 iconPos1;
    public Vector3 iconPos2;
    public AudioClip cursorMove;
    public AudioClip selectConfirm;

    public SpriteRenderer title;
    public Text opt1;
    public Text opt2;
    public Text load;

    bool selectLock = false;
    bool isConfirmSFXPlayed = false;
    bool isLoadInitialized = false;
    AudioSource selectSFX;
    AsyncOperation async;

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
                    if (!isLoadInitialized)
                    {
                        async = SceneManager.LoadSceneAsync(2);
                        async.allowSceneActivation = false;
                        isLoadInitialized = true;
                    }
                    else
                    {
                        if (async.progress == 0.9f)
                        {
                            async.allowSceneActivation = true;
                        }
                        else
                        {
                            title.enabled = false;
                            GetComponent<SpriteRenderer>().enabled = false;
                            opt1.enabled = false;
                            opt2.enabled = false;
                            load.enabled = true;
                        }
                    }
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
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
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
