using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicScript : MonoBehaviour
{
    public AreaEffector2D wind;
    // Start is called before the first frame update
    void Start()
    {
        wind = GameObject.FindGameObjectWithTag("Wind").GetComponent<AreaEffector2D>();
        SetWind(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SetWind(float angle, float magnitude, float forceVariation)
    {
        wind.forceAngle = angle;
        wind.forceMagnitude = magnitude;
        wind.forceVariation = forceVariation;
    }
}
