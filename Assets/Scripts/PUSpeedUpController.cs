using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUSpeedUpController : MonoBehaviour
{
    public Collider2D ball;
    public float magnitude;
    public PowerUpManager manager;
    private float timer;
    public float selfDestroyInterval;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == ball)
        {
            // Speed Up the ball
            ball.GetComponent<Ball>().ActivatePUSpeedUp(magnitude);
            manager.RemovePowerUp(gameObject);
        }
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > selfDestroyInterval)
        {
            manager.RemovePowerUp(gameObject);
        }
    }
}
