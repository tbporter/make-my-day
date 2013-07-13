using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
    public float speed = 6.0F;
    public float jumpSpeed = 20F;
    public float gravity = 25.0F;
    private Vector3 moveDirection = Vector3.zero;
    void Update() {
        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded) {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetButtonDown("Jump"))
                moveDirection.y = jumpSpeed;
            
        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
		
		
		if(Input.GetAxis ("Vertical") == -1){
			gameObject.layer = 9;
		}
		else{
			gameObject.layer = 0;
		}
		
    }
}