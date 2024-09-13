using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicScript : MonoBehaviour
{
    public AreaEffector2D wind;
    public float playerSpeedNormalized;
    public float maxWindStrength;
    // Start is called before the first frame update
    void Start()
    {
        wind = GameObject.FindGameObjectWithTag("Wind").GetComponent<AreaEffector2D>();
        SetWindSide(1);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SetWindUp()
    {
        wind.forceAngle = 90;
        wind.forceMagnitude = maxWindStrength * 10;
        wind.forceVariation = maxWindStrength * 10;
    }
    public void SetWindSide(int dir)
    {
        wind.forceAngle = 0;
        wind.forceMagnitude = maxWindStrength * playerSpeedNormalized * dir;
        wind.forceVariation = maxWindStrength * playerSpeedNormalized;
    }

    public void StopWind()
    {
        wind.forceAngle = 0;
        wind.forceMagnitude = 0;
        wind.forceVariation = 0;
    }

}
