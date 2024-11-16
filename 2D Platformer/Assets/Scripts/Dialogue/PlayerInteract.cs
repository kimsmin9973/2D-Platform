using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{


    [Header("��ȭ �ý���")]
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
        //�÷��̾ e��ư�� �������� + NPC�� �ֺ��� ������
        if (Input.GetKeyDown(KeyCode.E) && canSpeak)
        {
            EnableDialogue();
        }
    }

    private void EnableDialogue()
    {
        // ��ȭâ�� ��Ȱ��ȭ�Ǿ� �ִ� ���� -> Ȱ��ȭ
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
