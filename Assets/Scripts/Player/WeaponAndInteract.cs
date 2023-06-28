using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAndInteract : MonoBehaviour
{
    #region Gun Elements
    [Header("Gun")]
    [SerializeField] private int maxAmmo = 30;
    [SerializeField] private int currentAmmo;
    [SerializeField] private int ammoReserve;
    [SerializeField] private ParticleSystem muzzleFlash;
    [SerializeField] private GameObject gun;
    #endregion
    #region Interact Regions
    [SerializeField] private float interactRange;
    [SerializeField] private Camera m_camera;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        currentAmmo = maxAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        #region Collect Inputs
        if (Input.GetKeyDown(KeyCode.Mouse0) && gun.GetComponent<GunState>().status == CurrentGunStatus.Neutral)
        {

            StartCoroutine(Shoot());
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            Interact();
        }

        #endregion
    }
    IEnumerator Shoot()
    {
        muzzleFlash.Play();
        currentAmmo--;
        gun.GetComponent<GunState>().status = CurrentGunStatus.Firing;
        yield return new WaitForSeconds(0.01f);
        Debug.Log("Pew");
        gun.GetComponent<GunState>().status = CurrentGunStatus.Neutral;
    }
    private void Interact()
    {
        RaycastHit hit;
        if (Physics.Raycast(m_camera.transform.position, m_camera.transform.forward, out hit, interactRange))
        {
            hit.transform.gameObject.SendMessage("Interact");
            //if the player interacts with a gameobject it will attempt to call a "Use" function, depending on what function the object uses.
        }
    }

}
