using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : MonoBehaviour
{
    [SerializeField] MixerTools mixer;
    void Start()
    {
        Debug.Log("Hello");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleMusic(bool enabled)
    {
        if (enabled)
            mixer.OnMusic();
        else
            mixer.OffMusic();
    }

    public void ChangeVolume(float volume)
    {
        Debug.Log(volume);
        mixer.ChangeVolumeAll(volume);
    }
}
