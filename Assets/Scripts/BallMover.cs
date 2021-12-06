using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMover : MonoBehaviour
{
    private Rigidbody2D rBody;
    public Vector2 speed;
    private PlayerMovement playerMovementScript;
    private bool ballOnPaddle = true;
    public GameObject Player;

    [HideInInspector]
    public Vector2 directionMove;
    public float horiz;

    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        //directionMove = new Vector2(playerMovementScript.horiz, 1);
        //speed = new Vector2(1, 1);
        //rBody.velocity = directionMove * speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (ballOnPaddle)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                horiz = playerMovementScript.horiz;
                directionMove = new Vector2(horiz, 1);
                speed = new Vector2(speed.x, speed.y);
                rBody.velocity = directionMove * speed;
                ballOnPaddle = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            directionMove = new Vector2(directionMove.x, -directionMove.y);
            rBody.velocity = directionMove * speed;
        }
        else
        {
            directionMove = new Vector2(-directionMove.x, directionMove.y);
            rBody.velocity = directionMove * speed;
        }
    }
}
