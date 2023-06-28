using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    #region Basic Look Functions
    private float mouseX;
    private float mouseY;
    private float rotateX;
    [SerializeField] private float mouseSmooth;
    [SerializeField] private Transform parent;
    [SerializeField] private Camera cam;
    public bool cursorLocked;
    #endregion
    #region Min and Max Values
    [Header("Min and Max X Camera Rotates")]
    [SerializeField] private float rotateMax;
    [SerializeField] private float rotateMin;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        MouseInput();
        RotateY();
        RotateX();
    }
    void MouseInput()
    {
        mouseX = Input.GetAxis("Mouse X") * mouseSmooth;
        mouseY = Input.GetAxis("Mouse Y") * mouseSmooth;
    }
    void RotateY()
    {
        parent.Rotate(Vector3.up.normalized * mouseX);
    }
    void RotateX()
    {
        rotateX += mouseY;
        rotateX = Mathf.Clamp(rotateX, rotateMin, rotateMax);
        cam.transform.localRotation = Quaternion.Euler(-rotateX, 0, 0);  
    }
}
