using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StormDoorScript : MonoBehaviour
{
    public Sprite opened;
    public Sprite closed;
    public LogicScript logic;
    private bool open = true;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }
    void Update()
    {
        if (logic.stormy && open == false)
        {
            OpenDoor();
        }
        else if (!logic.stormy && open == true)
        {
            CloseDoor();
        }
    }

    void OpenDoor()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = opened;
        gameObject.GetComponent<Rigidbody2D>().simulated = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        open = true;
    }

    void CloseDoor()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = closed;
        gameObject.GetComponent<Rigidbody2D>().simulated = true;
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        open = false;
    }
}
