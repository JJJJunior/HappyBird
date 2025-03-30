using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//单例模式基类，采用线程锁保护
public class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
{
    private static volatile T _instance;
    private static readonly object _lockObject = new object();
    private static bool _applicationIsQuitting = false;

    public static T GetInstance
    {
        get
        {
            if (_applicationIsQuitting)
            {
                Debug.LogWarning("[Singleton] Instance '" + typeof(T) +
                    "' already destroyed on application quit." +
                    " Won't create again - returning null.");
                return null;
            }

            if (_instance == null)
            {
                lock (_lockObject)
                {
                    if (_instance == null)
                    {
                        var singletonObject = new GameObject();
                        _instance = singletonObject.AddComponent<T>();
                        singletonObject.name = typeof(T).ToString() + " (Singleton)";

                        DontDestroyOnLoad(singletonObject);
                    }
                }
            }
            return _instance;
        }
    }

    protected virtual void Awake()
    {
        if (_instance == null)
        {
            _instance = this as T;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    protected virtual void OnApplicationQuit()
    {
        _applicationIsQuitting = true;
    }
}
