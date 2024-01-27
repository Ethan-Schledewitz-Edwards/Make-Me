using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    private void Awake()
    {
        InputManager.Init();
    }

    private void Start()
    {
        //Subscribe SetMovementDirection to game buttons
        InputManager.controls.Game.Space.performed += context =>
        {
            StartGames();
        };
    }

    private void StartGames()
    {
        // Start the first MicroGame using the GameManager
        GameManager.Instance.StartMicroGames();
    }
}
