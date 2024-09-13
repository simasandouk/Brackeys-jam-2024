using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerScript : MonoBehaviour
{
    public float Movement_speed, Prev_pos = -1, pos = -1, Max_velocity;
    public Rigidbody2D rb;
    [SerializeField] float Dash_speed = 100;
    [SerializeField] float Dash_duration = 1f;
    [SerializeField] float Dash_cooldown = 1f;
    public LogicScript logic;
    public float maxHeight;
    private Vector2 direction;
    private bool Is_dashing, Can_dash, Can_up = true;
    private float timer = 0.4f;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        Can_dash = true;
    }

    void Update()
    {
        // raycasting to make sure player is within the max height
        RaycastHit2D ground = Physics2D.Raycast(transform.position, Vector2.down);
        if (ground.collider != null)
        {
            Debug.Log(ground.point.y - transform.position.y);
            Can_up = true;
            if (math.abs(ground.point.y - transform.position.y) >= maxHeight)
            {
                Debug.Log("raycast is working");
                Can_up = false;
                if (logic.wind.forceAngle > 0 && logic.wind.forceAngle < 180)
                {
                    logic.SetWind(0, 0, 0);
                }
            }
        }
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Prev_pos = pos;
            timer = 0.4f;
        }
        if (Is_dashing) return;

        // player movement and wind control
        if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D)) && Can_up)
        {
            logic.SetWind(90, 100, 100);
        }
        else
        {
            logic.SetWind(0, 0, 0);
        }

        if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            direction.x = -1;
            if (Prev_pos != pos)
                logic.SetWind(180, 10, 0);
        }
        else if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            direction.x = 1;
            if (Prev_pos != pos)
                logic.SetWind(0, 10, 0);
        }
        else
        {
            direction.x = 0;
            logic.SetWind(0, 0, 0);
            logic.SetWind(0, 0, 0);
        }

        // dashing (uwu)
        if (Input.GetKeyDown(KeyCode.LeftShift) && Can_dash)
        {
            StartCoroutine(Dash());
        }
        else
        {
            rb.velocity += new Vector2(Math.Min(Movement_speed, Math.Abs(direction.x * Max_velocity - rb.velocity.x)) * Time.deltaTime * direction.x, 0);
        }
        pos = Mathf.Round(transform.position.x);

        
    }

    private IEnumerator Dash()
    {
        Can_dash = false;
        Is_dashing = true;
        rb.velocity = new Vector2(Dash_speed * Time.deltaTime * direction.x * 10, rb.velocity.y);
        yield return new WaitForSeconds(Dash_duration);
        Is_dashing = false;
        yield return new WaitForSeconds(Dash_cooldown);
        Can_dash = true;
    }
}