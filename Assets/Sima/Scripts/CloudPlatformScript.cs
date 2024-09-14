using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudPlatformScript : MonoBehaviour
{
    private LogicScript logic;
    public bool isLeaf;
    private Rigidbody2D rigidBody;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (logic.stormy)
        {
            rigidBody.simulated = true;
        }
        else
        {
            rigidBody.simulated = false;
        }
    }
}
