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
    

    [Header("대화에 필요한 정보")]
    public NPCText npc;
    

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //충돌 대상이 플레이어 일 때 대화를 실행시킨다.
        if (collision.CompareTag("Player"))
        {
            Debug.Log($"{gameObject.name} 와 상호작용을 했습니다.");
            PlayerInteract Player = collision.GetComponent<PlayerInteract>();
            Player.hasExistNPC = true;
            Player.currentNPC = npc;
            Player.GetDialogueByNPC(npc);
        }
               
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //충돌 대상이 플레이어 일 때 대화를 실행시킨다.
        if (collision.CompareTag("Player"))
        {
            PlayerInteract Player = collision.GetComponent<PlayerInteract>();
            Player.hasExistNPC = false;
            Player.CloseText();
            Player.currentNPC = null;
        }
    }
}
