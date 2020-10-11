using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class MenuManager : MonoBehaviour
    {
        [SerializeField] private MixerTools mixer;
        [SerializeField] private Button sound;
        [SerializeField] private Sprite offSpriteSound;
        [SerializeField] private Sprite onSpriteSound;
        [SerializeField] private Text textCoins;
        [SerializeField] private GameObject shop;

        [SerializeField] private AudioClip clipClick;

        private bool isPlaySound = true;
        private void OffMixer()
        {
            isPlaySound = false;
            sound.image.sprite = offSpriteSound;
            mixer.OffAll();
            PlayerPrefs.SetInt("Sound", 0);
            PlayerPrefs.Save();
        }

        private void OnMixer()
        {
            isPlaySound = true;
            sound.image.sprite = onSpriteSound;
            mixer.OnAll();
            PlayerPrefs.SetInt("Sound", 1);
            PlayerPrefs.Save();
        }
        private void Start()
        {
            textCoins.text = PlayerPrefs.GetInt("Money").ToString();
            if (PlayerPrefs.GetInt("Sound") == 0)
                OffMixer();
            else if (PlayerPrefs.GetInt("Sound") == 1)
                OnMixer();
        }

        public void ChangeStateSound()
        {
            if (isPlaySound)
                OffMixer();
            else
                OnMixer();
            GetComponent<AudioSource>().PlayOneShot(clipClick);
        }

        public void PlayLevel1()
        {
            GetComponent<AudioSource>().PlayOneShot(clipClick);
            SceneManager.LoadScene(1);
        }
        public void PlayLevel2()
        {
            GetComponent<AudioSource>().PlayOneShot(clipClick);
            SceneManager.LoadScene(3);
        }
        public void ToShop()
        {
            GetComponent<AudioSource>().PlayOneShot(clipClick);
            shop.SetActive(true);
        }

        public void ToBack()
        {
            GetComponent<AudioSource>().PlayOneShot(clipClick);
            shop.SetActive(false);
        }
    }
}