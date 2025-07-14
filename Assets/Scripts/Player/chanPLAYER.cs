using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chanPLAYER : MonoBehaviour
{
    public float speed = 10;
    public float moveSpeed;
    public CharacterController player;
    private Vector3 movement;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("jump");
        }
    }

    void FixedUpdate()
    {
        movement.z=1*moveSpeed*Time.deltaTime;
        movement.x=Input.GetAxis("Horizontal")*Time.deltaTime*moveSpeed;
        movement.y = 0;
        player.Move(movement);
    }
}
