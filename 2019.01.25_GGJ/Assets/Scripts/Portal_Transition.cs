using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal_Transition : MonoBehaviour
{ // This script manages transiting between areas.

    public Transform targetAreaTrans;
    public Transform camTrans;
    public float fadeSpd;
    public int bgmNum;

    GameObject player;
    GameObject bgmManager;
    bool isTransiting = false;
    bool ifRelocated = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        bgmManager = GameObject.FindWithTag("BGM");
    }

    // Update is called once per frame
    void Update()
    {
        if (isTransiting)
        {
            SpriteRenderer blackCurtainRenderer = camTrans.GetChild(0).GetComponent<SpriteRenderer>();

            // When transition starts, black curtain fades in.
            if (blackCurtainRenderer.color.a < 1f && !ifRelocated)
            {
                blackCurtainRenderer.color += new Color(0, 0, 0, 1) * fadeSpd * Time.deltaTime;
            }
            else
            {
                // When the curtain's black, relocate player and camera to next area.
                if (!ifRelocated)
                {
                    camTrans.GetComponent<Camera_Movement>().boundaries = targetAreaTrans.GetChild(0);
                    Vector3 newPlayerPos = targetAreaTrans.GetChild(1).position;
                    player.transform.position = newPlayerPos;

                    bgmManager.GetComponent<Audio_BGMManager>().PlayClip(bgmNum);

                    ifRelocated = true;
                }
                else
                {
                    // After relocation's done, black curtain fades out.
                    if (blackCurtainRenderer.color.a > 0f)
                    {
                        blackCurtainRenderer.color -= new Color(0, 0, 0, 1) * fadeSpd * Time.deltaTime;
                    }
                    else
                    {
                        isTransiting = false;
                        ifRelocated = false;
                    }
                }
            }


        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Start transition when player touches the portal.
        if (collision.tag == "Player")
        {
            if (!isTransiting)
            {
                isTransiting = true;
            }
        }
    }
}
