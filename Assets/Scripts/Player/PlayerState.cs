using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum State
{
    Neutral, Walking, Running, Hanging, Climbing, Crouching, Jumping
}
public class PlayerState : MonoBehaviour
{
    #region Variables
    public State state;

    #endregion
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
}
