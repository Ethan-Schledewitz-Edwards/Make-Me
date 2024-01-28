using UnityEngine;

public class LifeIconComponent : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Animator Animator;

    [Header("SFX")]
    [SerializeField] private AudioClip _hurtEffect;

    [Header("System")]
    private bool lost = false;

    public void LoseLife()
    {
        if (!lost)
        {
            lost = true;
            Animator.SetTrigger("Lose");
        }
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }

    public void PlayFunniSound()
    {
        AudioManager.Instance.PlayClip(_hurtEffect);
    }
}
