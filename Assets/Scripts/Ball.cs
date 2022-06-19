using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Vector2 speed;
    public Vector2 resetPosition;
    private Rigidbody2D rig;
    private bool canExtendPaddle = false;
    private bool canFasterPaddle = false;

    // Start is called before the first frame update
    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        rig.velocity = speed;
    }

    // Update is called once per frame
    private void Update()
    {

    }
    public void ResetBall()
    {
        transform.position = new Vector3(resetPosition.x, resetPosition.y, 2);
        rig.velocity = speed;
        DeactivatePUDoubleSizePaddle();
        DeactivatePUFasterPaddle();
        ResetColor();
    }
    public void ActivatePUSpeedUp(float magnitude)
    {
        rig.velocity *= magnitude;
    }
    public void ActivatePUDoubleSizePaddle()
    {
        canExtendPaddle = true;
    }
    public void DeactivatePUDoubleSizePaddle()
    {
        canExtendPaddle = false;
        ResetColor();
    }

    public bool GetPUDoubleSize()
    {
        return canExtendPaddle;
    }

    public void ActivatePUFasterPaddle()
    {
        canFasterPaddle = true;
    }
    public void DeactivatePUFasterPaddle()
    {
        canFasterPaddle = false;
        ResetColor();
    }

    public bool GetPUFasterPaddle()
    {
        return canFasterPaddle;
    }
    public void ResetColor()
    {
        gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.white);
    }
}
