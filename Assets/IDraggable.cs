using UnityEngine;
using UnityEngine.InputSystem;

public abstract class IDraggable: MonoBehaviour
{
    [Header("Properties")]
    [SerializeField] private bool _startFollowingMouse;

    [Header("Input")]
    [SerializeField] private InputAction press, mousePos;

    [Header("Sprites")]
    [SerializeField] private Sprite _regularSprite;
    [SerializeField] private Sprite _interactSprite;

    [Header("Components")]
    Camera cam;

    [Header("System")]
    protected Vector3 currentPos;
    private bool followingMouse;

    public void Start()
    {
        cam = Camera.current;

        press.Enable();
        mousePos.Enable();

        if (_startFollowingMouse)
            followingMouse = true;

        //Subscribe SetMovementDirection to game buttons
        InputManager.controls.Game.LeftClick.performed += context =>
        {
            if (PlayerInput.Instance.CheckInputEnabled())
                Click();
        };
    }

    private void FixedUpdate()
    {
        if (followingMouse)
        {
            Vector3 newPos = Camera.main.ScreenToWorldPoint(PlayerInput.Instance.GetMousePos());
            newPos.z = 0;
            transform.position = newPos;
        }
    }

    public virtual void Pickup()
    {
        followingMouse = true;
    }

    public abstract void Click();
}
