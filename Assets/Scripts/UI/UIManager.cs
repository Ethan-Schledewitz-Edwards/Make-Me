using UnityEngine;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;
    public static UIManager Instance
    {
        get
        {
            if (!instance)
            {
                // Create the GameManager prefab
                instance = GameManager.CreateSingletonManager().GetComponent<UIManager>();
            }
            return instance;
        }
    }

    [Header("Components")]
    [SerializeField] private Animator Animator;





    public void StartMakeMeAnim()
    {
        Animator.SetTrigger("MakeMe");
    }




    public void FailedMakeMeAnim()
    {
        Animator.SetTrigger("Failed");
    }




    private void Awake()
    {
        instance = this;
    }
}
