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

    [Header("System")]
    protected Vector3 currentPos;
    protected bool followingMouse;

    public void Start()
    {
        press.Enable();
        mousePos.Enable();

        if (_startFollowingMouse)
            followingMouse = true;

        PlayerInput.Instance.OnClick += Click;
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

    public abstract void Click();
}
