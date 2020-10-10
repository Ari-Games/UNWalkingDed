using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
            //TODO
            //NextScene GameOver
            print("!!!!");
        }
    }
}
