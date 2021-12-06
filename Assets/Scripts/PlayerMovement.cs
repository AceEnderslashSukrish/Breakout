using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rBody;
    public Vector2 speed;
    public float minX, maxX;
    public GameObject ball;
    private BallMover ballMoverScript;

    [HideInInspector]
    public float horizVal;
    public float horiz;
    public float directionalMove;

    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        horiz = 0;
    }

    // Update is called once per frame
    void Update()
    {
        horiz = Input.GetAxis("Horizontal");        
        float vert = GetComponent<Transform>().position.y;

        Vector2 newVelocity = new Vector2(horiz, 0);
        rBody.velocity = newVelocity * speed.x;

        float newX;

        newX = Mathf.Clamp(rBody.position.x, minX, maxX);

        rBody.position = new Vector2(newX, vert);
    }
}
