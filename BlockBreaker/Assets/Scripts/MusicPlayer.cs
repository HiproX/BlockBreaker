using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private static MusicPlayer instance = null;
    private void Awake()
    {
        Debug.Log($"MusicPlayer[ID:{GetInstanceID()}].Awake");
        if (instance != null)
        {
            Destroy(gameObject);
            Debug.Log($"Дубликат MusicPlayer[ID:{GetInstanceID()}].Awake самоуничтожился");
        }
        else
        {
            Debug.Log($"(instance = MusicPlayer[ID:{GetInstanceID()}]).Awake");
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log($"MusicPlayer[ID: {GetInstanceID()}].Start");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
