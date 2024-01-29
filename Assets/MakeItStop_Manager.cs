public class MakeItStop_Manager : MicroGameManager
{
    protected override void Awake()
    {
        Instance = this;

        if (PlayerInput.Instance == null)
            PlayerInput.Instance.SetInputEnabled(true);

        MusicManager.Instance.EndMusic();
    }
}
