using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
    public float playerSpeedNormalized;
    public float WindStrength, MaxSpeed, MaxNormalized;
    public float Wind_dir = 1;
    public bool stormy;
    public GameObject lightningBolt, LightningBolt2;
    public Image Speed;
    public Sprite Calm;
    public Sprite Storm;
    public Image Indicator_sr;
    public float windSpeed;
    private Color clr;
    private float timer = 0;
    public float lightningInterval;
    public bool Is_dashing, Can_dash = true, Can_up = true;
    // Start is called before the first frame update
    void Start()
    {
        clr = Speed.color;
        stormy = false;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer >= 0.5)
        {
            lightningBolt.SetActive(false);
            LightningBolt2.SetActive(false);
        }
        if (timer >= lightningInterval)
        {
            stormy = false;
            Indicator_sr.sprite = Calm;
            timer = 0;
        }
        else if (stormy)
            timer += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Wind_dir *= -1;
        }
        if (playerSpeedNormalized >= MaxNormalized)
        {
            LetThereBeLightning();
        }
        Speed.fillAmount = playerSpeedNormalized / 2;
        Speed.color = Color.Lerp(clr, Color.red, playerSpeedNormalized / 2);
        if (!stormy)
            windSpeed = WindStrength * Wind_dir;
        else
        {
            windSpeed = WindStrength * 4;
        }
    }
    public void LetThereBeLightning()
    {
        stormy = true;
        Indicator_sr.sprite = Storm;
        lightningBolt.SetActive(true);
        LightningBolt2.SetActive(true);
        timer = 0;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}