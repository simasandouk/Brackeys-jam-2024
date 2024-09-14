using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
    public AreaEffector2D wind;
    public float playerSpeedNormalized;
    public float WindStrength, MaxSpeed, MaxNormalized;
    private float Wind_dir = 1;
    public bool stormy;
    public GameObject lightningBolt;
    public Image Speed;
    private Color clr;
    private float timer = 0;
    public float lightningInterval;
    // Start is called before the first frame update
    void Start()
    {
        wind = GameObject.FindGameObjectWithTag("Wind").GetComponent<AreaEffector2D>();
        SetWindSide(1);
        clr = Speed.color;
        stormy = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer >= lightningInterval)
        {
            timer = 0;
            lightningBolt.SetActive(false);
            stormy = false;
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
    }
    public void LetThereBeLightning()
    {
        stormy = true;
        lightningBolt.SetActive(true);
        timer = 0;
    }
    public void SetWindUp()
    {
        wind.forceAngle = 90;
        wind.forceMagnitude = WindStrength * 10;
        wind.forceVariation = WindStrength * 10;
    }
    public void SetWindSide(int dir)
    {
        wind.forceAngle = (Wind_dir * dir == 1) ? 0 : 180;
        wind.forceMagnitude = WindStrength;
        wind.forceVariation = WindStrength / 3;
    }

    public void StopWind()
    {
        wind.forceAngle = 0;
        wind.forceMagnitude = 0;
        wind.forceVariation = 0;
    }

}