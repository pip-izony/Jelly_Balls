using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopControll : MonoBehaviour {
    Text coinText;
    public Text coinPrice;
    public Text ballPrice;
    public Text coinT;
    public Text ballT;

    public static int coin;
    public static int ball;

    public Button buyCoin;
    public Button buyBall;
    // Use this for initialization
    void Start() {
        SaveManager.Instance.LoadGame();
    }

    // Update is called once per frame
    void Update() {
        if (coin < 100)
            coin = 100;
        if (ball < 100)
            ball = 100;
        if (bounce.bounce_cnt >= coin)
            buyCoin.interactable = true;
        else
            buyCoin.interactable = false;
        if (bounce.bounce_cnt >= ball)
            buyBall.interactable = true;
        else
            buyBall.interactable = false;
        coinT.text = coin.ToString();
        ballT.text = ball.ToString();
    }

    public void upgradeCoin()
    {
        bounce.bounce_cnt -= coin;
        coin *= 3;
        bounce.coin_l++;
        SaveManager.Instance.SaveGame();
        SaveManager.Instance.LoadGame();
    }

    public void upgradeBall()
    {
        bounce.bounce_cnt -= ball;
        ball *= 10;
        SaveManager.Instance.SaveGame();
        SaveManager.Instance.LoadGame();
    }
    public void restertButton()
    {
        SceneManager.LoadScene("SampleScene");
    }

}
