using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    int countOfCoin = 0;

    [SerializeField]
    Text text = null;

    Timer gameTime = null;
    
    public void IncCountOfCount()
    {
        countOfCoin ++;
    }
    private void Start()
    {
        text.text = "";
        gameTime = GetComponent<Timer>();
    }
    // Update is called once per frame
    void Update()
    {
        text.text = countOfCoin.ToString();
        if(!gameTime.timerIsRunning)
        {
            TheEnd();
        }
    }

    public void TheEnd()
    {
        int money = 0;
        if (PlayerPrefs.HasKey("Money"))
            money = PlayerPrefs.GetInt("Money");
        money += countOfCoin;
        PlayerPrefs.SetInt("Money", money);
        PlayerPrefs.Save();

        SceneManager.LoadScene(2);
    }
}
