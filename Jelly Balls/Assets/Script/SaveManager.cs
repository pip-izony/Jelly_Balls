using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour {
	// Use this for initialization
    public static SaveManager Instance { set; get; }
	void Start () {
        Instance = this;
        LoadGame();
	}
	public void LoadGame()
    {
        string LoadCoin = PlayerPrefs.GetString("coin");
        if (LoadCoin != null && LoadCoin.Length > 0)
        {
            SaveState s = JsonUtility.FromJson<SaveState>(LoadCoin);
            if(s!=null)
            {
                bounce.bounce_cnt = s.gold;
                ShopControll.coin = s.coin_price;
                ShopControll.ball = s.ball_price;
                bounce.coin_l = s.coin_level;
                PhysicsController.ball_l = s.ball_level;
            }
        }
    }
	// Update is called once per frame
	void Update () {
		
	}
    public void SaveGame()
    {
        SaveState coin = new SaveState();
        coin.gold = bounce.bounce_cnt;
        coin.coin_price = ShopControll.coin;
        coin.ball_price = ShopControll.ball;
        coin.coin_level = bounce.coin_l;
        coin.ball_level = PhysicsController.ball_l;

        string json = JsonUtility.ToJson(coin);
        PlayerPrefs.SetString("coin", json);
    }
}
