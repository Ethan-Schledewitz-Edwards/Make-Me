using UnityEngine;


public class FeatherScript : MonoBehaviour
{
    private bool dragging = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (dragging)
        {
            gameObject.transform.position = Input.mousePosition;
        }
    }

    private void OnMouseDrag()
    {
        dragging = !dragging;

        MicroGameManager.Instance.AddPoint();
    }
}
