using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class UIManagerLevel : MonoBehaviour
    {
        [SerializeField] private MixerTools mixer;
        [SerializeField] private GameObject panelPause;
        [SerializeField] private Sprite offSound;
        [SerializeField] private Sprite onSound;
        [SerializeField] private Button playSound;
        private bool isSoundPlay = true;
        [SerializeField] private AudioClip clipClick;
        private void OffMixer()
        {
            isSoundPlay = false;
            playSound.image.sprite = offSound;
            mixer.OffAll();
            PlayerPrefs.SetInt("Sound", 0);
            PlayerPrefs.Save();
        }

        private void OnMixer()
        {
            isSoundPlay = true;
            playSound.image.sprite = onSound;
            mixer.OnAll();
            PlayerPrefs.SetInt("Sound", 1);
            PlayerPrefs.Save();
        }
        private void Start()
        {
            if (PlayerPrefs.GetInt("Sound") == 0)
                OffMixer();
            else if( PlayerPrefs.GetInt("Sound") == 1)
                OnMixer();
        }

        public void ChangePlaySound()
        {
            if (isSoundPlay)
                OffMixer();
            else
                OnMixer();
            GetComponent<AudioSource>().PlayOneShot(clipClick);
        }

        public void Repeat()
        {
            GetComponent<AudioSource>().PlayOneShot(clipClick);
            SceneManager.LoadScene(1);
        }

        public void ToMenu()
        {
            GetComponent<AudioSource>().PlayOneShot(clipClick);
            SceneManager.LoadScene(0);
        }

        public void PlayContinue()
        {
            GetComponent<AudioSource>().PlayOneShot(clipClick);
            panelPause.SetActive(false);
            
        }

        public void OpenPause()
        {
            GetComponent<AudioSource>().PlayOneShot(clipClick);
            panelPause.SetActive(true);
            
        
        }
    }
}