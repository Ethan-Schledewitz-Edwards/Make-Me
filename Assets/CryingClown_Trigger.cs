using UnityEngine;

public class CryingClown_Trigger : MonoBehaviour, ITrigger
{
    [Header("Components")]
    [SerializeField] private Animator _animator;

    [SerializeField] private string id;
    public string ID => id;

    public void Trigger()
    {
        _animator.SetTrigger("Shot");
        PlayerInput.Instance.SetInputEnabled(false);
    }




    /// <summary>
    /// This method is used by the animator after the clown has died
    /// </summary>
    public void FinishScene()
    {
        Application.Quit();
    }
}
