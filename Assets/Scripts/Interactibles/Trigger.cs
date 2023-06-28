using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public GameObject connectedDoor;
    [SerializeField]
    private bool isLocked;
    [SerializeField]
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact()
    {
        if (!isLocked)
        {
            connectedDoor.SetActive(false);
        }
        else if(isLocked && player.GetComponent<PlayerInventorySpoof>().hasKey)
        {
            connectedDoor.SetActive(false);
        }
        else
        {
            Debug.LogError("No key!");
        }
    }
}
