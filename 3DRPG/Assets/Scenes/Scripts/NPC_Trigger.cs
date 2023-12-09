using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Trigger : MonoBehaviour
{
    public string ChatText = "";
    private GameObject UI_Control;

    // Start is called before the first frame update
    void Start()
    {
        UI_Control = GameObject.Find("UI_Control");   
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            UI_Control.GetComponent<UIController>().NPCChatEnter(ChatText);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            UI_Control.GetComponent<UIController>().NPCChatExit();
        }
    }
}
