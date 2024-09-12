using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerScript : MonoBehaviour
{
    private Vector2 direction;
    public float Movement_speed;
    public Rigidbody2D rb;
    [SerializeField] float Dash_speed = 10;
    [SerializeField] float Dash_duration = 1f;
    [SerializeField] float Dash_cooldown = 1f;
    bool Is_dashing;
    bool Can_dash;

    void Start()
    {
        Can_dash = true;
    }

    void Update()
    {
        if (Is_dashing) return;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            direction.x = Input.GetKey(KeyCode.A) ? -1 : 1;
        }
        else
        {
            direction.x = 0;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && Can_dash)
        {
            StartCoroutine(Dash());
        }
        else
        {
            rb.velocity = new Vector2(Movement_speed * Time.deltaTime * direction.x * 10, rb.velocity.y);
        }
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