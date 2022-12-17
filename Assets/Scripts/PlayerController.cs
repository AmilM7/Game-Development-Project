using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction;
    public float forwardSpeed;
    public float maxSpeed;

    private int desiredLane = 1;
    public float laneDistance = 4;

    public Animator animator;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(forwardSpeed<maxSpeed) forwardSpeed += 0.2f * Time.deltaTime;

        direction.z = forwardSpeed;
        
        if(Input.GetKeyDown(KeyCode.RightArrow) || SwipeManager.swipeRight)
        {
            if(desiredLane == 0 || desiredLane == 1) animator.SetTrigger("RightTurn");
            desiredLane++;
            if(desiredLane == 3) desiredLane = 2;
            
        }

        if(Input.GetKeyDown(KeyCode.LeftArrow) || SwipeManager.swipeLeft)
        {
            if(desiredLane == 1 || desiredLane == 2) animator.SetTrigger("LeftTurn");
            desiredLane--;
            if(desiredLane == -1) desiredLane = 0;
            
        }

        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
    
        if(desiredLane == 0)
        {
            targetPosition += Vector3.left * laneDistance;
            animator.SetTrigger("ToIdle");
        }else if(desiredLane == 2)
        {
            targetPosition += Vector3.right * laneDistance;
            animator.SetTrigger("ToIdle");
        }


        if (transform.position == targetPosition) return;
        Vector3 diff = targetPosition - transform.position;
        Vector3 moveDir = diff.normalized * 25 * Time.deltaTime;
        if(moveDir.sqrMagnitude < diff.sqrMagnitude) controller.Move(moveDir);
        else controller.Move(diff);
        
    }

    private void FixedUpdate(){
        controller.Move(direction * Time.fixedDeltaTime); 
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.transform.tag=="Obstacle")
        {
            PlayerManager.gameOver=true;
            FindObjectOfType<AudioManager>().PlaySound("GameOver");
        }
    }

    

}
