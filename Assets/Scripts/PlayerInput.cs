using UnityEngine;

// Instead of having the player hard coded for each scene, this will be on the game manager and will serve as the player between scenes.
public class PlayerInput : MonoBehaviour
{
    [Header("Singleton")]
    private static PlayerInput instance;
    public static PlayerInput Instance
    {
        get
        {
            if (!instance)
            {
                // Create the GameManager prefab
                instance = GameManager.CreateSingletonManager().GetComponent<PlayerInput>();
            }
            return instance;
        }
    }

    private bool takesInput = true;
    private Vector3 currentPos;

    private void Awake()
    {
        instance = this;
        InputManager.Init();
    }

    private void Start()
    {
        InputManager.controls.Game.MousePos.performed += context => 
        {
            if (takesInput)
                currentPos = context.ReadValue<Vector2>(); 
        };
    }

    public bool CheckInputEnabled()
    {
        return takesInput;
    }

    public void SetInputEnabled(bool allowed)
    {
        takesInput = allowed;
    }

    public Vector3 GetMousePos()
    {
        return currentPos;
    }
}
