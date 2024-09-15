using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleScript : MonoBehaviour
{
    private LogicScript logic;
    public ParticleSystem leaves;
    private ParticleSystem.VelocityOverLifetimeModule velocityModule;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        velocityModule = leaves.velocityOverLifetime;
        velocityModule.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        SetParticleVelocity(logic.windSpeed);
    }

    void SetParticleVelocity(float windSpeed)
    {
        // Modify the velocity in the x direction based on wind speed
        velocityModule.y = new ParticleSystem.MinMaxCurve(windSpeed);

        // Optionally, adjust y or z if you want vertical or depth-based wind effects
        // velocityModule.y = new ParticleSystem.MinMaxCurve(0f); // No vertical change by default
    }
}
