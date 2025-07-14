using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 3;
    public float leftRightSpeed = 4;
    static public bool canMove = false;
    public bool isJumping = false;
    public bool comingDown = false;
    public GameObject playerObject;
    //public bool isSliding = false;
    //public bool ComingDown = false;



    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
        if (canMove == true)
        {

            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                if (this.gameObject.transform.position.x > LevelBounadry.leftSide)
                {
                    transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed);
                }
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                if (this.gameObject.transform.position.x < LevelBounadry.rightSide)
                {
                    transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed * -1);
                }
            }
        
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                if (isJumping == false)
                {
                    isJumping = true;
                    //playerObject.GetComponent<Animator>().Play("Standard Run@Jump Backward");
                    StartCoroutine(JumpSequence());
                }
            }
           /* if (Input.GetKey(KeyCode.R) || Input.GetKey(KeyCode.DownArrow))
            {
                if (isSliding == false)
                {
                    isSliding = true;
                    playerObject.GetComponent<Animator>().Play("Running Slide (1)");
                    StartCoroutine(SlideSequence());
                }
            }*/

        }
        if (isJumping == true)
        {
            if (comingDown == false)
            {
                transform.Translate(Vector3.up * Time.deltaTime * 3, Space.World);
            }
            if (comingDown == true)
            {
                transform.Translate(Vector3.up * Time.deltaTime * -3, Space.World);
            }
        }
           
        /*if (isSliding == true)
        {
            if (ComingDown == false)
            {
                transform.Translate(Vector3.up * Time.deltaTime * 3, Space.World);
            }
            if (ComingDown == true)
            {
                transform.Translate(Vector3.up * Time.deltaTime * -3, Space.World);
            }
        }*/
    }
    IEnumerator JumpSequence()
    {
        yield return new WaitForSeconds(0.45f);
        comingDown = true;
        yield return new WaitForSeconds(0.45f);
        isJumping = false;
        comingDown = false;
        playerObject.GetComponent<Animator>().Play("Running");
    }
    /*IEnumerator SlideSequence()
    {
        yield return new WaitForSeconds(0.45f);
        // ComingDown = true;
        yield return new WaitForSeconds(0.45f);
        isSliding = false;
        //ComingDown = false;
        playerObject.GetComponent<Animator>().Play("Running");
    }*/
    }
