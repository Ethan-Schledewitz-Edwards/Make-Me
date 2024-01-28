using UnityEngine;

public class CryingClown : ITrigger
{
    [Header("Components")]
    [SerializeField] private Animator _animator;

    public override void Trigger()
    {
        Debug.Log("DIE");
        _animator.SetTrigger("Shot");
    }




    /// <summary>
    /// This method is used by the animator after the clown has died
    /// </summary>
    public void FinishScene()
    {
        Application.Quit();
    }
}
