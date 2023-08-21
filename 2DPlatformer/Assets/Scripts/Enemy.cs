using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : PhysicsObject
{
    [SerializeField] private float maxSpeed = 2;
    private int direction = 1;

    private RaycastHit2D rightLedgeRaycastHit;
    private RaycastHit2D leftLedgeRaycastHit;
    private RaycastHit2D rightWallRaycastHit;
    private RaycastHit2D leftWallRaycastHit;

    [SerializeField] LayerMask rayCastLayerMask;
    [SerializeField] private Vector2 rayCastOffcet;
    [SerializeField] private int rayCastLength = 2;
    [SerializeField] private int attackPower = 10;

    void Start()
    {

    }

    void Update()
    {
        targetVelocity = new Vector2(maxSpeed * direction, 0);

        //check for right ledge
        rightLedgeRaycastHit = Physics2D.Raycast(new Vector2(transform.position.x + rayCastOffcet.x, transform.position.y + rayCastOffcet.y), Vector2.down, rayCastLength);
        Debug.DrawRay(new Vector2(transform.position.x + rayCastOffcet.x, transform.position.y + rayCastOffcet.y), Vector2.down * rayCastLength, Color.green);
        if (rightLedgeRaycastHit.collider == null) direction = -1;

        //check for left ledge
        leftLedgeRaycastHit = Physics2D.Raycast(new Vector2(transform.position.x - rayCastOffcet.x, transform.position.y + rayCastOffcet.y), Vector2.down, rayCastLength);
        Debug.DrawRay(new Vector2(transform.position.x - rayCastOffcet.x, transform.position.y + rayCastOffcet.y), Vector2.down * rayCastLength, Color.red);
        if (leftLedgeRaycastHit.collider == null) direction = 1;

        //check for right wall
        rightWallRaycastHit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), Vector2.right, rayCastLength, rayCastLayerMask);
        Debug.DrawRay(new Vector2(transform.position.x, transform.position.y), Vector2.right * rayCastLength, Color.blue);
        if (rightWallRaycastHit.collider != null) direction = -1;

        //check for left wall
        leftWallRaycastHit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), Vector2.left, rayCastLength, rayCastLayerMask);
        Debug.DrawRay(new Vector2(transform.position.x, transform.position.y), Vector2.left * rayCastLength, Color.black);
        if (leftWallRaycastHit.collider != null) direction = 1;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == NewPlayer.Instance.gameObject)
        {
            NewPlayer.Instance.health -= attackPower;
            NewPlayer.Instance.UpdateUI();
        }
    }
}
