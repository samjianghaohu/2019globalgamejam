using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu_Slides : MonoBehaviour
{
    public Sprite[] slides;
    public string[] texts;
    int currentSlide = 0;
    float interval = 7.075f;
    float timer = 0f;

    public Text slideText;

    // Start is called before the first frame update
    void Start()
    {
        timer = interval;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.anyKeyDown)
        //{
        //    currentSlide += 1;
        //}
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            currentSlide += 1;
            timer = interval;
        }

        if (currentSlide >= slides.Length || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            DisplaySlide();
        }
    }

    void DisplaySlide()
    {
        GetComponent<SpriteRenderer>().sprite = slides[currentSlide];
        slideText.text = texts[currentSlide];
    }
}
