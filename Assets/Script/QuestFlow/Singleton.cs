using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;

    public static T Instance { get => instance; }
    private void Awake()
    {
        Debug.Assert(this is T);
        instance = this as T;
    }
}