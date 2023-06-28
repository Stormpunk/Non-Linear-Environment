using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LedgeHang : MonoBehaviour
{
    #region Hang Basics
    public GameObject player;
    public Transform ledgeTransform;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Ledge")
        {
            player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            player.GetComponent<Movement>().isHanging = true;
            ledgeTransform = other.transform;
        }
    }

}
