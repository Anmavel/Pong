using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player_Movement : MonoBehaviour
{
    [SerializeField] private GameObject player1;
    [SerializeField] private GameObject player2;
    private Rigidbody rb_Player1;
    private Rigidbody rb_Player2;
    private float playerSpeed = 10;


    private void Start()
    {
        rb_Player1 = player1.GetComponent<Rigidbody>();
        rb_Player2 = player2.GetComponent<Rigidbody>();

    }

    private void Move_Player1()
    {
        Vector3 velocity = new Vector3();
        if (Input.GetKey(KeyCode.W))
        {
            velocity.y = playerSpeed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            velocity.y = -playerSpeed;
        }

        rb_Player1.velocity = velocity;
    }

    private void Move_Player2()
    {
        Vector3 velocity = new Vector3();
        if (Input.GetKey(KeyCode.UpArrow))
        {
            velocity.y = playerSpeed;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            velocity.y = -playerSpeed;
        }

        rb_Player2.velocity = velocity;
    }


    private void Update()
    {

        Move_Player1();
        Move_Player2();
    }


}
