using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMusicFix : MonoBehaviour
{
    public static BGMusicFix Instance = null;
    public AudioSource musicSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
}
