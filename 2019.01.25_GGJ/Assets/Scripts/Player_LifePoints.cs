using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_LifePoints : MonoBehaviour
{// This script manages player taking damage.

    int lifePoint = 3;
    public GameObject hud;

    AudioSource damageSFX;

    // Start is called before the first frame update
    void Start()
    {
        damageSFX = transform.GetChild(2).GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (lifePoint <= 0)
        {
            SceneManager.LoadScene(3);
        }else if (lifePoint == 1)
        {
            if (!hud.GetComponent<AudioSource>().isPlaying)
            {
                hud.GetComponent<AudioSource>().Play();
            }
        }
        else
        {
            hud.GetComponent<AudioSource>().Stop();
        }
    }


    public void TakeDamage()
    {
        lifePoint -= 1;
        hud.GetComponent<Animator>().SetTrigger("ReduceLP");
        damageSFX.Play();
    }
}
