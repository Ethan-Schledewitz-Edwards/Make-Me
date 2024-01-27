using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Instead of having the player hard coded for each scene, this will be on the game manager and will serve as the player between scenes.
public class PlayerInput : MonoBehaviour
{
    private bool takesInput;

    private void Awake()
    {
        InputManager.Init();
    }

    private void Start()
    {
        //Subscribe SetMovementDirection to game buttons
        InputManager.controls.Game.LeftClick.performed += context =>
        {
            if (takesInput)
                DebugMethod();
        };
    }

    private void DebugMethod()
    {
        Debug.Log("INPUT");
    }
}
