using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : MonoBehaviour
{
    [SerializeField] MixerTools mixer;
    [SerializeField] GameObject explosion;
    [SerializeField] private Vector3 pos;
    void Start()
    {
        Debug.Log("Hello");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(explosion, pos, Quaternion.identity);
        }
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
