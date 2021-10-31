using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSevice : MonoBehaviour {

    public void Play()
    {
        GetComponent<AudioSource>().Play();
    }


    public void Stop()
    {
        GetComponent<AudioSource>().Stop();
    }

    void Awake()
    {

        if (!ServiceLocator.HasService<LevelService>())
        {
            DontDestroyOnLoad(this.gameObject);
            ServiceLocator.RegisterService(this);
        }
        else
            Destroy(gameObject);
    }
}
