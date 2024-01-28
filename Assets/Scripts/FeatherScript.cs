using UnityEngine;


public class FeatherScript : ITrigger
{
    private bool dragging = false;

    public string ID => throw new System.NotImplementedException();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (dragging)
        {
            //gameObject.transform.position = Input.mousePosition;
        }
    }

    private void OnMouseDrag()
    {
        dragging = !dragging;

        MicroGameManager.Instance.AddPoint();
    }

    public void Trigger()
    {
        MicroGameManager.Instance.AddPoint();
    }
}
