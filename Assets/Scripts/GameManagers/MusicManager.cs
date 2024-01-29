using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private static MusicManager instance;
    public static MusicManager Instance
    {
        get
        {
            if (!instance)
            {
                // Create the GameManager prefab
                instance = GameManager.CreateSingletonManager().GetComponent<MusicManager>();
            }
            return instance;
        }
    }

    [Header("System")]
    [SerializeField] private AudioSource audioSource;

    [SerializeField] private AudioClip _music;

    private void Awake()
    {
        instance = this;
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayMusic()
    {
        if (audioSource.isPlaying)
            return;

        audioSource.clip = _music;
        audioSource.loop = true;
        audioSource.volume = 0.1f;
        audioSource.Play();
    }

    public void PauseMusic()
    {
        audioSource.Pause();
    }

    public void EndMusic()
    {
        audioSource.Stop();
        audioSource.loop = true;
        audioSource.clip = null;
    }
}
