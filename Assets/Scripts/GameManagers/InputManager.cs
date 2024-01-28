

public static class InputManager
{
    public static Controls controls;
    static bool initialized = false;

    public static void Init()
    {
        if (initialized) return;
        controls = new Controls();
        controls.Enable();
        initialized = true;
    }

    public static void Destroy()
    {
        controls.Dispose();
        initialized = false;
    }
}
