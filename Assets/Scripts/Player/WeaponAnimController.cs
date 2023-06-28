using System.Collections;
using System.Collections.Generic;
using UnityEngine.Animations;
using UnityEngine;
using System;
using Unity.VisualScripting;

public class WeaponAnimController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject gun;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.GetComponent<PlayerState>().state == State.Walking)
        {
            anim.SetBool("Walk", true);
        }
        else if (player.GetComponent<PlayerState>().state != State.Walking)
        {
            anim.SetBool("Walk", false);
        }
        if(player.GetComponent<PlayerState>().state == State.Running)
        {
            anim.SetBool("Sprint", true);
        }
        else if(player.GetComponent<PlayerState>().state != State.Running)
        {
            anim.SetBool("Sprint", false);
        }

        if (gun.GetComponent<GunState>().status == CurrentGunStatus.Firing)
        {
            anim.SetTrigger("Fire");
        }
    }
}
