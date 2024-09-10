using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerScript : MonoBehaviour
{
    private Vector3 direction; // normalized movement vector
    public float movementSpeed;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            direction.x = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            direction.x = 1;
        }
        else
        {
            direction.x = direction.y = direction.z = 0;
        }
        transform.position += movementSpeed * Time.deltaTime * direction;
    }
}
