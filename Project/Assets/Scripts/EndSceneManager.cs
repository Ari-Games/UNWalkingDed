using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class EndSceneManager : MonoBehaviour
    {

        [SerializeField] private Text textCoins;

        void Start()
        {
            textCoins.text = PlayerPrefs.GetInt("Money").ToString();
        }

        public void ExitFromScene()
        {
            SceneManager.LoadScene(0);
        }
    }
}