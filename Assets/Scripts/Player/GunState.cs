using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum CurrentGunStatus
{
    Neutral, Firing, Reloading, Aiming, AimShot
}
public enum ReloadState
{
    LoadButEmpty, Unloaded, ReloadNotCocked, Ready
}
public class GunState : MonoBehaviour
{
    public CurrentGunStatus status;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
