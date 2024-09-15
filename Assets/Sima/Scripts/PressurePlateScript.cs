using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PressurePlateScript : MonoBehaviour
{
    public UnityEvent pressureEvent;
    Vector3 originalPos;
    private bool moveBack;
    private int countOfStuff = 0;
    public float distanceToGoDown;
    public float movingSpeed;
    bool allTheWay;
    public GameObject endGame;
    // Start is called before the first frame update
    void Start()
    {
        moveBack = false;
        originalPos = transform.position;
        endGame = GameObject.FindGameObjectWithTag("end");
    }

    // Update is called once per frame
    void Update()
    {
        if (moveBack)
        {
            if (transform.position.y < originalPos.y)
            {
                transform.Translate(0f, movingSpeed, 0f);
                allTheWay = false;
            }
            else
            {
                moveBack = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == 3)
            return;
        countOfStuff++;
        other.transform.parent = transform;
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.layer == 3)
            return;
        if (transform.position.y >= originalPos.y - distanceToGoDown)
            transform.Translate(0f, -movingSpeed, 0f);
        else if (!allTheWay)
        {
            allTheWay = true;
            // you can add a function from the editor
            Time.timeScale = 0;
            endGame.SetActive(true);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.layer == 3)
            return;
        countOfStuff--;
        other.transform.parent = null;
        if (countOfStuff == 0)
        {
            moveBack = true;
        }
    }
}