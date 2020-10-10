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
        private bool isPlaySound = true;

        private void Start()
        {
            textCoins.text = PlayerPrefs.GetInt("Money").ToString();
        }

        public void ChangeStateSound()
        {
            if (isPlaySound)
            {
                sound.image.sprite = offSpriteSound;
                isPlaySound = false;
                mixer.OffAll();
            }
            else
            {
                sound.image.sprite = onSpriteSound;
                isPlaySound = true;
                mixer.OnAll();
            }
        }

        public void Play()
        {
            SceneManager.LoadScene(1);
        }

        public void ToShop()
        {
            shop.SetActive(true);
        }

        public void ToBack()
        {
            shop.SetActive(false);
        }
    }
}