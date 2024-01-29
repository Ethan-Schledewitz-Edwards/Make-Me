using UnityEngine;

public class CryingClown_Trigger : MonoBehaviour, ITrigger
{
    [Header("Components")]
    [SerializeField] private Animator _animator;

    [SerializeField] private string id;
    public string ID => id;

    [SerializeField] private AudioClip _hurtEffect;
    [SerializeField] private AudioClip _tromboneWahWah;

    public void Trigger()
    {
        AudioManager.Instance.PlayClip(_hurtEffect);
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


    public void PlayTrobone()
    {
        AudioManager.Instance.PlayClip(_tromboneWahWah);
    }
}
