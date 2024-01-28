using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Singleton")]
    private static AudioManager instance;
    public static AudioManager Instance
    {
        get
        {
            if (!instance)
            {
                // Create the GameManager prefab
                instance = GameManager.CreateSingletonManager().GetComponent<AudioManager>();
            }
            return instance;
        }
    }

    [Header("Components")]
    [SerializeField] private AudioSource _audioSource;

    public void PlayClip(AudioClip audioClip)
    {
        _audioSource.PlayOneShot(audioClip);
    }
}
