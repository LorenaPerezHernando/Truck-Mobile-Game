using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T Instance { get; private set; }

    protected virtual void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); // ya existe, se elimina este
        }
        else
        {
            Instance = this as T;
            DontDestroyOnLoad(gameObject); // opcional, si quieres que persista entre escenas
        }
    }
}
