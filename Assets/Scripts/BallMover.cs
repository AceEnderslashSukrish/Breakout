using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMover : MonoBehaviour
{
    public Vector2 speed;
    public Transform objectToFollow;
    public Vector3 offset;

    private Vector2 directionMove;
    private float horiz;
    private Rigidbody2D rBody;
    private bool ballOnPaddle = true;
    private GameController gameControllerScript;
    private int scoreValue = 1;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = objectToFollow.position + offset;
        ballOnPaddle = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (ballOnPaddle)
        {
            transform.position = objectToFollow.position + offset;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ballOnPaddle = false;
                rBody = GetComponent<Rigidbody2D>();
                directionMove = new Vector2(Random.Range(-1, 2), 1);

                while (directionMove == Vector2.up)
                {
                    directionMove = new Vector2(Random.Range(-1, 2), 1);
                }
                speed = new Vector2(Random.Range(4, 6), Random.Range(4, 6));

                rBody.velocity = directionMove * speed;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        gameControllerScript = GameObject.Find("GameController").GetComponent<GameController>();
        if (other.gameObject.CompareTag("Block"))
        {
            Destroy(other.gameObject);
            gameControllerScript.AddToScore(scoreValue);
        }
        if (GameObject.FindGameObjectsWithTag("Block") == null)
        {
            gameControllerScript.PlayerWin();
        }
        //else
        //{
        //    directionMove = new Vector2(-directionMove.x, directionMove.y);
        //    rBody.velocity = directionMove * speed;
        //}
    }
}
