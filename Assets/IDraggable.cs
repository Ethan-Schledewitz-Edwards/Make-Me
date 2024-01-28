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
    private Vector3 currentPos;
    private bool followingMouse;

    public void Start()
    {
        press.Enable();
        mousePos.Enable();

        if (_startFollowingMouse)
            followingMouse = true;

        mousePos.performed += ctx => { currentPos = ctx.ReadValue<Vector2>(); };
    }

    private void FixedUpdate()
    {
        if (followingMouse)
        {
            transform.position = currentPos;
        }
    }

    public virtual void Pickup()
    {
        followingMouse = true;
    }

    public abstract void Click();
}
