using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

namespace Assets.Scripts
{
    public class UIManagerLevel : MonoBehaviour
    {
        [SerializeField] private MixerTools mixer;
        [SerializeField] private GameObject panelPause;
        [SerializeField] private Sprite offSound;
        [SerializeField] private Sprite onSound;
        [SerializeField] private Button playSound;
        [SerializeField] private GameObject player;
        [SerializeField] private NavMeshData navMeshData;
        [SerializeField] private NavMeshSurface2d surface2D;
        
        private bool isSoundPlay = true;
        
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
            player = GameObject.FindWithTag("Player");
            // player.GetComponent<MoveController>().enabled = true;
            Time.timeScale = 1;
            if (PlayerPrefs.GetInt("Sound") == 0)
                OffMixer();
            else if( PlayerPrefs.GetInt("Sound") == 1)
                OnMixer();

//            surface2D.navMeshData = navMeshData;
        }

        public void ChangePlaySound()
        {
            if (isSoundPlay)
                OffMixer();
            else
                OnMixer();
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
            player.GetComponent<MoveController>().enabled = true;

            Time.timeScale = 1;
            
        }

        public void OpenPause()
        {
            Time.timeScale = 0;
            player.GetComponent<MoveController>().enabled = false;

            panelPause.SetActive(true);
            
        
        }
    }
}