using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PhysicsController : MonoBehaviour
{
    public static int ball_l;

    public Text gem_text;

    public Button shop;

    public float ShakeDectionThreshold;
    public float MinShakeInterval;

    public float ShakeForceMultiplier;
    public Rigidbody2D[] ShakingRigidbodies;

    private float sqrShakeDectionThreshold;
    private float timeSinceLastShake;

    //public Camera camera;
    void start()
    {
        sqrShakeDectionThreshold = Mathf.Pow(ShakeDectionThreshold, 2);
        SaveManager.Instance.LoadGame();
    }

    void Update()
    {
        gem_text.text = bounce.bounce_cnt.ToString();
        if (Input.acceleration.sqrMagnitude >= sqrShakeDectionThreshold && Time.unscaledTime >= timeSinceLastShake + MinShakeInterval)
        {
            foreach (var rigidbody in ShakingRigidbodies)
            {
                rigidbody.AddForce(Input.acceleration * ShakeForceMultiplier * 25, ForceMode2D.Impulse);
            }
            timeSinceLastShake = Time.unscaledTime;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    public void shopButton()
    {
        SceneManager.LoadScene("ShopScene");
    }
}