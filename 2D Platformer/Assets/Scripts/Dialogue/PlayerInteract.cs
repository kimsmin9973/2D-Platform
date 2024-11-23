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
    public float typeSpeed;

    private Queue<String> lines = new Queue<string> ();
    private string currentText;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        nameText = GameObject.Find("Canvas/Dialogue Background/NPC_Name").GetComponent<TextMeshProUGUI>();
        dialogueText = GameObject.Find("Canvas/Dialogue Background/Dialogue_Text").GetComponent<TextMeshProUGUI>();
        
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
        animator.Play("Show");
        TypeText();
    }

    public void GetDialogueByNPC(NPCText npc)
    {
        foreach (var line in npc.dialogues)
        {
            lines.Enqueue(line);
        }
    }



    private void TypeText()
    {
        if (lines.Count == 0)
        {
            EndDialogue();
            return;
        }

        DialogueBackGround.SetActive(true);
        nameText.text = currentNPC.npcName;
        currentText = lines.Dequeue();
        
        StopAllCoroutines();
        StartCoroutine(TypeSentence(currentText));
    }

    IEnumerator TypeSentence(string currentLine)
    {
        dialogueText.text = "";
        foreach (char letter in currentLine)
        {
            dialogueText.text +=letter;
            yield return new WaitForSeconds(typeSpeed);
        }

    }

    private void EndDialogue()
    {
        lines.Clear();
        animator.Play("Hide");
    }

    public void CloseText()
    {
        lines.Clear();
        animator.Play("Hide");
    }
}
