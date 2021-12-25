using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameController control;

    private Animator animator;

    public float strafeSpeed = 4f;

    private bool jumping = false;
    private static readonly int Jump = Animator.StringToHash("Jump");

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float xMove = Input.GetAxis("Horizontal") * Time.deltaTime * strafeSpeed;
        transform.Translate(xMove, 0f, 0f);

        if (transform.position.x > 3)
        {
            transform.position = new Vector3(3, transform.position.y, transform.position.z);
        } else if (transform.position.x < -3)
        {
            transform.position = new Vector3(-3, transform.position.y, transform.position.z);
        }

        if (Input.GetButtonDown("Jump"))
        {
            animator.SetTrigger(Jump);
        }

        jumping = !animator.GetCurrentAnimatorStateInfo(0).IsName("Run");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Power Up"))
        {
            control.PowerUpCollected();
            Destroy(other.gameObject);
        } else if (other.gameObject.CompareTag("Obstacle") && !jumping)
        {
            control.SlowWorldDown();
        }
    }
}
