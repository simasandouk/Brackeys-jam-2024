using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public Sprite opened;
    public Sprite closed;

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.layer == 6)
        {
            // Collision detected with the opener object
            Debug.Log(collision.gameObject.name + " opened the door");
            OpenDoor();
            Destroy(collision.gameObject);
        }
    }

    void OpenDoor()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = opened;
        gameObject.GetComponent<Rigidbody2D>().simulated = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }

    /*void CloseDoor()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = closed;
        gameObject.GetComponent<Rigidbody2D>().simulated = true;
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }*/
}
