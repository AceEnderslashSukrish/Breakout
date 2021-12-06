using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMover : MonoBehaviour
{
    public Vector2 speed;
    private PlayerMovement playerMovementScript;
    public GameObject Player;

    private Vector2 directionMove;
    private float horiz;
    private Rigidbody2D rBody;
    private bool ballOnPaddle = true;

    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        directionMove = new Vector2(Random.Range(-1, 2), 1);

        while (directionMove == Vector2.up)
        {
            directionMove = new Vector2(Random.Range(-1, 2), 1);
        }
        speed = new Vector2(Random.Range(4, 6), Random.Range(4, 6));

        rBody.velocity = directionMove * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
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
