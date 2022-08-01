using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T: MonoBehaviour
{

    private static T _Instant = null;
    public static T Instant => _Instant;

    private void Awake()
    {
        if (_Instant != null)
            return;
        var GMs = FindObjectsOfType<T>();
        _Instant = GMs[0];

        if (GMs.Length > 1)
            Destroy(this.gameObject);
    }
}
