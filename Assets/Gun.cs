using UnityEngine;

public class Gun : IDraggable
{
    [SerializeField] private LayerMask layersTargetted;

    public override void Click()
    {
        Debug.Log(PlayerInput.Instance.GetMousePos());

        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(PlayerInput.Instance.GetMousePos()), -Vector2.up, layersTargetted);
        if (hit)
        {
            Debug.Log(hit.transform.name);

            ITrigger clown = hit.transform.GetComponent<ITrigger>();
            if (clown.ID == "Clown")
            {
                Debug.Log("BALLZ");
                clown.Trigger();
            }
        }
        
    }

    public override void Pickup()
    {
        throw new System.NotImplementedException();
    }
}
