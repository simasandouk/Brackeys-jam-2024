using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudPlatformScript : MonoBehaviour
{
    private LogicScript logic;
    public bool isLeaf;
    private Rigidbody2D rigidBody;
    private SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (logic.stormy)
        {
            rigidBody.simulated = true;
            sr.color = Color.Lerp(sr.color, Color.gray, 0.3f);
        }
        else
        {
            rigidBody.simulated = false;
            sr.color = Color.Lerp(sr.color, Color.white, 0.3f);
        }
    }
}
