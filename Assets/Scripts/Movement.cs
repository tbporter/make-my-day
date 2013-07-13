using UnityEngine;
using System.Collections;


enum AnimationMovementStates {
	Idle,
	Walking,
	Running,
	Jumping
};

public class Movement : MonoBehaviour {
    private float walkVel = 6.0f;
	private float runVel = 15f;
	private float runAccel = 15f;
	private float curHoriVel; //velocity between walk and run
	private float curHoriDir; //horizontal dir before jump
    private float jumpVel = 10f; //vel you start jump
	private float jumpFloat = 5f; //acceleration after initial jump, allows for variable jumps
	
	private float jumpHoriVel = 6.0f;
	
	private bool extendedJump;
    private float gravity = 20.0f;
	
	private float vertSpeed = 0;
	
	private float lastOnGround = 0;
	private bool isOnGround;
	private float lastOnBuffer = .05f;
	
	void OnStart() {
		isOnGround = false;
	}
    private Vector3 moveDirection = Vector3.zero;
    void Update() {
		CharacterController controller = GetComponent<CharacterController>();
		isOnGround = updateGrouded();
		print (controller.isGrounded);
		
       
        
        if (isOnGround) {
			
			//running
			if(Input.GetButton("Sprint")){
				print (curHoriVel);
				curHoriVel += runAccel * Time.deltaTime;
				if(curHoriVel>runVel) curHoriVel=runVel;
			}
			else{
				curHoriVel -= runAccel * Time.deltaTime;
				if(curHoriVel<walkVel) curHoriVel=walkVel;
			}
			
        	moveDirection.x = Input.GetAxis("Horizontal")*curHoriVel;
			moveDirection.y = -3f; //magic number to balance high speed ledge falls and not bouncing on floor
			
			
            if (Input.GetButton("Jump")){
                moveDirection.y = jumpVel;
				extendedJump = true;
				
				//get the direction we jumped in
				curHoriDir = Input.GetAxis("Horizontal");
			}
			
        }
		else {
			//moveDirection.x = jumpHoriVel*Input.GetAxis("Horizontal");
			
			//make sure we are giong the same direction
			if((curHoriDir>=0&&Input.GetAxis("Horizontal")>=0)||(
				(curHoriDir)<=0&&Input.GetAxis("Horizontal")<=0)){
				//don't do anything going the same direction
			}
			else{ //you changed direction mid air, revert to jumping speed
				curHoriVel = jumpHoriVel;
			}
			moveDirection.x = curHoriVel * Input.GetAxis("Horizontal");
			
			moveDirection.y -= gravity * Time.deltaTime;
        	if (moveDirection.y>0 && extendedJump && Input.GetButton("Jump"))
                moveDirection.y += jumpFloat * Time.deltaTime;
			else
				extendedJump = false;
		}
		controller.Move(moveDirection * Time.deltaTime);
		if(Input.GetAxis ("Vertical") == -1){
			gameObject.layer = 9;
		}
		else{
			gameObject.layer = 0;
		}
		
		
		
    }
	
	bool updateGrouded(){
		CharacterController controller = GetComponent<CharacterController>();
		if(controller.isGrounded == true){
			lastOnGround = 0;
			return true;
		}
		
		lastOnGround += Time.deltaTime;
		
		if(lastOnGround>lastOnBuffer)
			return false;
		
		return isOnGround;
	}
	
	
	
}