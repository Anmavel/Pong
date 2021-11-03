using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ball_Movement : MonoBehaviour
{
    private Rigidbody rb_ball;
    private float ballSpeed = 5;
    private Vector3 direction;
    [SerializeField] private Score_Manager score_Manager;



    void Start()
    {
        rb_ball = GetComponent<Rigidbody>();
        Invoke(nameof(Go_ball), 1); // Verzögerung
    }

    void Go_ball()
    {
        direction.x = 1;
        int random = Random.Range(0, 2);
        if (random == 0)
        {
            direction.x = -1;
        }

        direction.y = Random.Range(-0.5f, 0.5f);
        rb_ball.velocity = direction.normalized * ballSpeed;

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall_up_down"))
        {
            direction.y = -direction.y;
            rb_ball.velocity = direction.normalized * ballSpeed;
        }

        else if (collision.gameObject.CompareTag("Wall_right_left"))
        {
            score_Manager.Increase_Score(transform.position.x > 0);
            Reset_ball();

        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            direction.x = -direction.x;
            direction.y += collision.collider.attachedRigidbody.velocity.y / 10;
            rb_ball.velocity = direction.normalized * ballSpeed; // Energie vom Player wird den auf Ball übertragen
        }

    }

    private void Reset_ball()
    {
        transform.position = Vector3.zero; // setzt den Vector auf 0,0,0
        rb_ball.velocity = Vector3.zero;
        if (score_Manager.GetGameEnd() == true) return;
        Invoke(nameof(Go_ball), 1);
       
    }

}
