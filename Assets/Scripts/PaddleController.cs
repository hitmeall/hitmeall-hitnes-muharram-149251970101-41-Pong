using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public int speed;
    public KeyCode upKey;
    public KeyCode downKey;
    private Rigidbody2D rig;
    public Collider2D ball;

    private Color initBallCol;

    // Power UP variable
    private bool isExtended = false;
    private bool isFaster = false;
    private float timerPUDouble;
    private float timerPUFaster;
    private Vector3 initialScale;
    private float speedUP;
    private float powerUPTime = 5;

    // Start is called before the first frame update

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (ball.GetComponent<Ball>().GetPUDoubleSize())
        {
            if (!isExtended)
            {
                ExtendPaddle();
            }
            else
            {
                timerPUDouble = 0;
            }
            ball.GetComponent<Renderer>().material.SetColor("_Color", initBallCol);
        }
        if (ball.GetComponent<Ball>().GetPUFasterPaddle())
        {
            if (!isFaster)
            {
                FasterPaddle();
            }
            else
            {
                timerPUFaster = 0;
            }
            ball.GetComponent<Renderer>().material.SetColor("_Color", initBallCol);
        }
    }

    private void Start()
    {
        initialScale = gameObject.transform.localScale;
        speedUP = speed;
        Debug.Log("Paddle speed: " + speedUP);
        rig = GetComponent<Rigidbody2D>();

        initBallCol = ball.GetComponent<Renderer>().material.GetColor("_Color");
    }

    // Update is called once per frame
    private void Update()
    {
        // get input 
        Vector2 movement = GetInput();

        // move object 
        MoveObject(movement);

        if (isExtended)
        {
            timerPUDouble += Time.deltaTime;
            if (timerPUDouble > powerUPTime)
            {
                ResetScalePaddle();
            }
        }
        if (isFaster)
        {
            timerPUFaster += Time.deltaTime;
            if (timerPUFaster > powerUPTime)
            {
                ResetFasterPaddle();
            }
        }
    }

    private Vector2 GetInput()
    {
        if (Input.GetKey(upKey))
        {
            return Vector2.up * speedUP;
        }
        else if (Input.GetKey(downKey))
        {
            return Vector2.down * speedUP;
        }

        return Vector2.zero;
    }

    private void MoveObject(Vector2 movement)
    {
        //Debug.Log("TEST: " + movement);
        Debug.Log("Paddle speed: " + speedUP);
        rig.velocity = movement;
    }
    private void ExtendPaddle()
    {
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y * 2, transform.localScale.z);
        isExtended = true;

        ball.GetComponent<Ball>().DeactivatePUDoubleSizePaddle();
    }
    private void ResetScalePaddle()
    {

        transform.localScale = initialScale;
        isExtended = false;

        timerPUDouble = 0;
    }

    private void FasterPaddle()
    {
        speedUP *= 2;
        isFaster = true;

        ball.GetComponent<Ball>().DeactivatePUFasterPaddle();
    }

    private void ResetFasterPaddle()
    {
        speedUP = speed;
        isFaster = false;
        timerPUFaster = 0;
    }
}
