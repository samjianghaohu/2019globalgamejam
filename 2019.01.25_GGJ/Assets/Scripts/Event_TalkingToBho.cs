using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_TalkingToBho : MonoBehaviour
{// This script manages the dialogue talking to bho.

    public Transform cameraTrans;
    public float dialogeBoxWidth;
    public string[] dialogueSequence;

    Transform playerTrans;
    GameObject dialogueBox;
    GameObject dialogue;
    int dialogueIndx = 0;

    bool isDialogueTriggered = false;
    bool isTalking = false;

    // Start is called before the first frame update
    void Start()
    {
        playerTrans = GameObject.FindWithTag("Player").transform;
        dialogueBox = transform.GetChild(1).gameObject;
        dialogue = transform.GetChild(2).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (isTalking)
        {
            cameraTrans.GetComponent<Camera_Movement>().inCutscene = true;
            playerTrans.GetComponent<Player_Movement>().inCutscene = true;
            playerTrans.eulerAngles = new Vector3(playerTrans.rotation.x, 0, playerTrans.rotation.z);

            Vector3 camTargetPos = transform.GetChild(0).position;

            cameraTrans.position = Vector3.Lerp(cameraTrans.position, camTargetPos, 0.8f * Time.deltaTime);

            if (DialogueBoxAppear())
            {
                dialogue.SetActive(true);
                dialogue.GetComponent<MeshRenderer>().sortingOrder = 5;
                dialogue.GetComponent<TextMesh>().text = dialogueSequence[dialogueIndx];

                if (Input.anyKeyDown)
                {
                    if (dialogueIndx < dialogueSequence.Length - 1)
                    {
                        dialogueIndx += 1;
                    }
                    else
                    {
                        cameraTrans.GetComponent<Camera_Movement>().inCutscene = false;
                        playerTrans.GetComponent<Player_Movement>().inCutscene = false;
                        isTalking = false;
                        isDialogueTriggered = true;
                    }
                }
            }
        }
        else
        {
            if (dialogueBox.transform.localScale.x > 0f)
            {
                dialogueBox.transform.localScale -= new Vector3(1, 0, 0) * 0.5f * Time.deltaTime;
            }
            else
            {
                dialogueBox.transform.localScale = new Vector3(0, dialogueBox.transform.localScale.y, dialogueBox.transform.localScale.z);
            }
            dialogue.SetActive(false);
        }
    }


    bool DialogueBoxAppear()
    {
        if (dialogueBox.transform.localScale.x < dialogeBoxWidth)
        {
            dialogueBox.transform.localScale += new Vector3(1, 0, 0) * 0.5f * Time.deltaTime;
            return false;
        }
        else
        {
            return true;
        }
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !isDialogueTriggered)
        {
            isTalking = true;
        }
    }
}
