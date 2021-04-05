using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float speed = 1;
    public float jump = 1;

    private Rigidbody2D _rigidbody;

    private Animator anim;


    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

   
    private void Update()
    {
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * speed;

        if (movement == 0)
        {

            anim.SetBool("isRunning", false);
        }
        else {
            anim.SetBool("isRunning", true);

        }

        if (Input.GetButtonDown("Jump") && Mathf.Abs(_rigidbody.velocity.y) < 0.001f ) {

            _rigidbody.AddForce(new Vector2(0, jump),ForceMode2D.Impulse);
        }
    }
}
