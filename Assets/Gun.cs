using UnityEngine;

public class Gun : IDraggable
{
    [Header("Trigger Layers")]
    [SerializeField] private LayerMask layersTargetted;

    public override void Click()
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
