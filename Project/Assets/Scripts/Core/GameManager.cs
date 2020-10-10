using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    int countOfCoin = 0;

    [SerializeField]
    Text text = null;

    public void IncCountOfCount()
    {
        countOfCoin ++;
    }
    private void Start() {
        text.text = "";
    }
    // Update is called once per frame
    void Update()
    {
        text.text = countOfCoin.ToString();
    }
}
