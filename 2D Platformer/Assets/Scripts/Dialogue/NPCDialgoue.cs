using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[System.Serializable]
public class NPCText
{
    public string npcName;
    public string[] dialogues;
}
public class NPCDialgoue : MonoBehaviour
{
    

    [Header("��ȭ�� �ʿ��� ����")]
    public NPCText npc;
    

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //�浹 ����� �÷��̾� �� �� ��ȭ�� �����Ų��.
        if (collision.CompareTag("Player"))
        {
            Debug.Log($"{gameObject.name} �� ��ȣ�ۿ��� �߽��ϴ�.");
            PlayerInteract Player = collision.GetComponent<PlayerInteract>();
            Player.hasExistNPC = true;
            Player.currentNPC = npc;
            Player.GetDialogueByNPC(npc);
        }
               
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //�浹 ����� �÷��̾� �� �� ��ȭ�� �����Ų��.
        if (collision.CompareTag("Player"))
        {
            PlayerInteract Player = collision.GetComponent<PlayerInteract>();
            Player.hasExistNPC = false;
            Player.CloseText();
            Player.currentNPC = null;
        }
    }
}
