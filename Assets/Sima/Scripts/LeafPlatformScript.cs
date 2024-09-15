using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafPlatformScript : MonoBehaviour
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
            rigidBody.simulated = false;
            sr.color = new Color (sr.color.r, sr.color.g, sr.color.b, 0.5f);
        }
        else
        {
            rigidBody.simulated = true;
            sr.color = new Color (sr.color.r, sr.color.g, sr.color.b, 1f);
        }
    }
}
