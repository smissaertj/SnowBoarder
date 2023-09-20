using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    [SerializeField] float torqueAmount = 5f;
    [SerializeField] private float boostSpeed = 30f;
    [SerializeField] private float baseSpeed = 12.5f;
    [SerializeField] private float slowSpeed = 6f;
    private SurfaceEffector2D surfaceEffector2D;
    private bool canMove = true;
    
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            RotatePlayer();
            RespondToBoost();
        }

    }

    public void DisableControls()
    {
        canMove = false;
    }

    private void RespondToBoost()
    {
        // if we push up then speed up, otherwise stay at normal speed
        if (Input.GetKey(KeyCode.UpArrow))
        {
            surfaceEffector2D.speed = boostSpeed;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            surfaceEffector2D.speed = slowSpeed;
        }
        else
        {
            surfaceEffector2D.speed = baseSpeed;
        }
    }
    
    private void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.AddTorque(torqueAmount);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.AddTorque(-torqueAmount);
        }
    }
}
