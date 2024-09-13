using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicScript : MonoBehaviour
{
    public AreaEffector2D windSide;
    public AreaEffector2D windUp;
    // Start is called before the first frame update
    void Start()
    {
        windSide = GameObject.FindGameObjectWithTag("WindSide").GetComponent<AreaEffector2D>();
        windUp = GameObject.FindGameObjectWithTag("WindUp").GetComponent<AreaEffector2D>();
        windSide.forceMagnitude = windSide.forceAngle = windUp.forceAngle = windUp.forceMagnitude = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SetWind(float angle, float magnitude, float forceVariation)
    {
        windUp.forceAngle = angle;
        windUp.forceMagnitude = magnitude;
        windUp.forceVariation = forceVariation;
    }
}
