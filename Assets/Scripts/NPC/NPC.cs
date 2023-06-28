using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public GameObject player;
    public GameObject talkPanel;
    public TextMeshProUGUI talkText;
    public bool hasUnlockedTerminal;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (talkPanel.gameObject.activeSelf && Input.anyKeyDown)
        {
            talkPanel.gameObject.SetActive(false);
        }
    }
    public void Interact()
    {
        if (player.GetComponent<PlayerInventorySpoof>().hasBribe == true && hasUnlockedTerminal == false)
        {
            hasUnlockedTerminal = true;
            talkPanel.SetActive(true);
            talkText.text = "Wot? You want me to open the inner chamber? What's that you've got there? Well well well! There, the inner chamber terminal's unlocked. You'll have to find your own way in though. Don't worry! I'll look the other way. Heh, heh, heh...";
            player.GetComponent<PlayerInventorySpoof>().hasKey = true;
        }
        else if(player.GetComponent<PlayerInventorySpoof>().hasBribe == true && hasUnlockedTerminal == false)
        {
            talkPanel.SetActive(true);
            talkText.text = "I've done what you asked, away with ye! Before you get me in trouble!";
        }
        else if (player.GetComponent<PlayerInventorySpoof>().hasBribe == false)
        {
            talkPanel.SetActive(true);
            talkText.text = "Wot? You want me to open the inner chamber? Make it worth my while then!";
        }
    }
}
