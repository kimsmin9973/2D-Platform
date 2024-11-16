using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{


    [Header("대화 시스템")]
    public GameObject DialogueBackGround;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public GameObject dialogueObject;
    [Space]
    public bool hasExistNPC = false;
    public NPCText currentNPC;

    // Start is called before the first frame update
    void Start()
    {
        nameText = GameObject.Find("Canvas/Dialogue Background/NPC_Name").GetComponent<TextMeshProUGUI>();
        dialogueText = GameObject.Find("Canvas/Dialogue Background/Dialogue_Text").GetComponent<TextMeshProUGUI>();
        dialogueObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        InterractNPC(hasExistNPC);
    }

    public void InterractNPC(bool canSpeak)
    {
        //플레이어가 e버튼을 눌렀을때 + NPC가 주변에 있을떄
        if (Input.GetKeyDown(KeyCode.E) && canSpeak)
        {
            EnableDialogue();
        }
    }

    private void EnableDialogue()
    {
        // 대화창이 비활성화되어 있는 상태 -> 활성화
        if (DialogueBackGround.activeInHierarchy)
        {
            DialogueBackGround.SetActive(false);

        }
        else
        {
            TypeText();
        }
    }

    private void TypeText()
    {
        DialogueBackGround.SetActive(true);
        nameText.text = currentNPC.npcName;
        dialogueText.text = currentNPC.dialogues[0];

        //
    }

    public void CloseText()
    {
        DialogueBackGround.SetActive(false);
    }
}
