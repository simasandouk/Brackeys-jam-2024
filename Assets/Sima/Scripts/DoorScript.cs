using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public Sprite opened;
    public Sprite closed;
    public SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Key collided with door");
        if (collision.gameObject.name == "Key")
        {
            // Collision detected with the specific object

        }
    }

    void OpenDoor()
    {
        spriteRenderer.sprite = opened;
    }

    void CloseDoor()
    {
        spriteRenderer.sprite = closed;
    }
}
