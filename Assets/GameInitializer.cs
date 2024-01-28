using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    private bool started;

    private void Awake()
    {
        InputManager.Init();
    }

    private void Start()
    {
        //Subscribe SetMovementDirection to game buttons
        InputManager.controls.Game.Space.performed += context =>
        {
            if (!started)
                StartGames();
        };
    }

    private void StartGames()
    {
        started = true;

        // Start the first MicroGame using the GameManager
        GameManager.Instance.StartMicroGameLoop();
    }
}
