using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindSideScript : MonoBehaviour
{
    public AreaEffector2D sideWind;
    private LogicScript logic;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        StopSideWind();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            if (logic.Wind_dir == 1)
                FireSideWind(180);
            else
                FireSideWind(0);
        }
        else if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            if (logic.Wind_dir == 1)
                FireSideWind(0);
            else
                FireSideWind(180);
        }
        else
        {
            StopSideWind();
        }
    }

    void FireSideWind(float angle)
    {
        sideWind.forceAngle = angle;
        sideWind.forceMagnitude = logic.WindStrength;
        sideWind.forceVariation = logic.WindStrength;
    }
    void StopSideWind()
    {
        sideWind.forceAngle = 0;
        sideWind.forceMagnitude = 0;
        sideWind.forceVariation = 0;
    }
}
