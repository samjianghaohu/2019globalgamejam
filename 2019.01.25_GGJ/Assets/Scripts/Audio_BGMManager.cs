using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_BGMManager : MonoBehaviour
{// This script manages bgm.

    AudioSource myBgmPlayer;
    public AudioClip[] bgmClips;
    bool isWaitingf46 = false;

    // Start is called before the first frame update
    void Start()
    {
        myBgmPlayer = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isWaitingf46)
        {
            if (!myBgmPlayer.isPlaying)
            {
                myBgmPlayer.clip = bgmClips[6];
                myBgmPlayer.loop = true;
                myBgmPlayer.Play();
                isWaitingf46 = false;
            }
        }
    }


    public void PlayClip(int clipNum)
    {
        if (clipNum != -1)
        {
            if (clipNum == 5)
            {
                myBgmPlayer.Stop();
                myBgmPlayer.clip = bgmClips[5];
                myBgmPlayer.loop = false;
                myBgmPlayer.Play();
                isWaitingf46 = true;
            }
            else
            {
                myBgmPlayer.Stop();
                myBgmPlayer.clip = bgmClips[clipNum];
                myBgmPlayer.loop = true;
                myBgmPlayer.Play();
                isWaitingf46 = false;
            }
        }
    }
}
