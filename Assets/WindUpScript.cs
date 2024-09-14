using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindUpScript : MonoBehaviour
{
    public AreaEffector2D upWind;
    private LogicScript logic;
    public float upWindMultiplier;
    public float upWindInterval;
    private float timer = 0;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        StopUpWind();
    }
    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D)) && logic.Can_up)
        {
            FireUpWind();
        }
        else if (timer >= upWindInterval)
        {
            timer = 0;
            StopUpWind();
        }
        else
        {
            timer += Time.deltaTime;
        }
    }

    void FireUpWind()
    {
        upWind.forceAngle = 90;
        upWind.forceMagnitude = logic.WindStrength * upWindMultiplier;
        upWind.forceVariation = logic.WindStrength * upWindMultiplier;
    }
    void StopUpWind()
    {
        upWind.forceAngle = 0;
        upWind.forceMagnitude = 0;
        upWind.forceVariation = 0;
    }
}
