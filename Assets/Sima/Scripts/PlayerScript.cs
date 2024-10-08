using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerScript : MonoBehaviour
{
    public float Movement_speed, Prev_pos = -1, pos = -1, Max_velocity, maxHeight;
    public Rigidbody2D rb;
    [SerializeField] float Dash_speed = 100;
    [SerializeField] float Dash_duration = 1f;
    [SerializeField] float Dash_cooldown = 1f;
    public LogicScript logic;
    private Vector2 direction;
    private float timer = 2f;
    private SpriteRenderer bunny;
    public bool Is_grounded;
    private Animator animator;
    private GameObject currentOneWayPlatform;

    [SerializeField] private BoxCollider2D playerCollider;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        logic.Can_dash = true;
        bunny = gameObject.GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        animator.SetFloat("X_velocity", Math.Abs(rb.velocity.x));
        animator.SetFloat("Y_velocity", Math.Abs(rb.velocity.y));
        animator.SetBool("Is_dashing", logic.Is_dashing);
        RaycastHit2D ground = Physics2D.Raycast(transform.position, Vector2.down);
        if (ground.collider != null)
        {
            //Debug.Log(ground.point.y - transform.position.y);
            logic.Can_up = true;
            if (math.abs(ground.point.y - transform.position.y) >= maxHeight)
            {
                Debug.Log("raycast is working");
                logic.Can_up = false;
            }
        }
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Prev_pos = pos;
            timer = 2f;
        }
        if (logic.Is_dashing) return;

        // player movement and wind control

        if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            direction.x = -1;
            bunny.flipX = true;
        }
        else if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            direction.x = 1;
            bunny.flipX = false;
        }
        else
        {
            direction.x = 0;
        }

        // dashing (uwu)
        if (Input.GetKeyDown(KeyCode.LeftShift) && logic.Can_dash && direction.x != 0)
        {
            StartCoroutine(Dash());
        }
        else
        {
            rb.velocity += new Vector2(Math.Min(Movement_speed, Max_velocity - rb.velocity.x * direction.x) * Time.deltaTime * direction.x, 0);
        }
        pos = Mathf.Round(transform.position.x);

        logic.playerSpeedNormalized = math.abs(rb.velocity.x) / logic.MaxSpeed;
        //UnityEngine.Debug.Log(rb.velocity.x);

        // get down through one way platform
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (currentOneWayPlatform != null)
            {
                Debug.Log("this fucker is being pressed and called");
                StartCoroutine(DisableCollision());
            }
        }
    }

    private IEnumerator Dash()
    {
        logic.Can_dash = false;
        logic.Is_dashing = true;
        rb.velocity += new Vector2(Dash_speed * Time.deltaTime * direction.x, rb.velocity.y);
        yield return new WaitForSeconds(Dash_duration);
        logic.Is_dashing = false;
        yield return new WaitForSeconds(Dash_cooldown);
        logic.Can_dash = true;
    }

    private void OnTriggerEnter2D(Collider2D trigger)
    {
        Is_grounded = true;
        animator.SetBool("Is_hovering", !Is_grounded);
        if (trigger.gameObject.CompareTag("OneWayPlatform"))
        {
            currentOneWayPlatform = trigger.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D trigger)
    {
        Is_grounded = false;
        animator.SetBool("Is_hovering", !Is_grounded);
        if (trigger.gameObject.CompareTag("OneWayPlatform"))
        {
            currentOneWayPlatform = null;
        }
    }

    private IEnumerator DisableCollision()
    {
        rb.velocity = new Vector2 (rb.velocity.x, 0f);
        BoxCollider2D platformCollider = currentOneWayPlatform.GetComponent<BoxCollider2D>();
        Physics2D.IgnoreCollision(playerCollider, platformCollider);
        yield return new WaitForSeconds(1f);
        Physics2D.IgnoreCollision(playerCollider, platformCollider, false);
    }
}