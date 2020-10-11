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

        public void ChangePlaySound()
        {
            if (isSoundPlay)
            {
                isSoundPlay = false;
                playSound.image.sprite = offSound;
                mixer.OffAll();
            }
            else
            {
                isSoundPlay = true;
                playSound.image.sprite = onSound;
                mixer.OnAll();
            }
        }

        public void Repeat()
        {
            SceneManager.LoadScene(1);
        }

        public void ToMenu()
        {
            SceneManager.LoadScene(0);
        }

        public void PlayContinue()
        {
            panelPause.SetActive(false);
            
        }

        public void OpenPause()
        {
            panelPause.SetActive(true);
            
        
        }
    }
}