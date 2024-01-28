using UnityEngine;

public class Feather_Trigger : IDraggable, ITrigger
{
    [Header("Components")]
    [SerializeField] private string id;
    public string ID => id;
    [SerializeField] private BoxCollider2D _boxCol;

    [Header("Trigger Layers")]
    [SerializeField] private LayerMask layersTargetted;

    private void Start()
    {
        PlayerInput.Instance.OnClick += CheckMousePos;
        PlayerInput.Instance.OnClick += Click;
    }

    private void OnDestroy()
    {
        PlayerInput.Instance.OnClick -= CheckMousePos;
        PlayerInput.Instance.OnClick -= Click;
    }

    private void CheckMousePos()
    {
        //Check if we are under the mouse when clicked
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(PlayerInput.Instance.GetMousePos()), -Vector2.up, layersTargetted);
        if (hit)
        {
            ITrigger objectID = hit.transform.GetComponent<ITrigger>();
            if (objectID.ID == "Feather")
            {
                objectID.Trigger();
            }
        }

    }

    public void Trigger()
    {
        followingMouse = true;
        _boxCol.enabled = false;
    }

    public override void Click()
    {

        Debug.Log("BALLZ");

        if (followingMouse)
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(PlayerInput.Instance.GetMousePos()), -Vector2.up, layersTargetted);
            if (hit)
            {
                ITrigger clown = hit.transform.GetComponent<ITrigger>();
                if (clown.ID == "Clown")
                {
                    clown.Trigger();
                }
            }
        }
    }
}
