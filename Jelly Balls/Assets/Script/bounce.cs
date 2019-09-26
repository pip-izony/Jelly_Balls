using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class bounce : MonoBehaviour {

    public GameObject ball;
    public GameObject coin;

    public static int coin_l;

    Vector3 col_position;
    public static int bounce_cnt;

	void OnCollisionEnter2D(Collision2D col)
    {
        if (coin_l < 1)
            coin_l = 1;
        if (col.gameObject)
        {
            bounce_cnt += coin_l;
            SaveManager.Instance.SaveGame();
            col_position = ball.transform.position;
            for (int i = 0; i < coin_l; i++)
            {
                GameObject clone = Instantiate(coin) as GameObject;
                clone.transform.position = col_position;
            }
        }
    }
}
