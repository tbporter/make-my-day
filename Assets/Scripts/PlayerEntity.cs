using UnityEngine;
using System.Collections;


public class PlayerEntity : LivingEntity {
	
	
	
    private float walkVel = 6.0f;
	private float runVel = 15f;
	private float runAccel = 15f;
	private float curHoriVel; //velocity between walk and run
	private float curHoriDir; //horizontal dir before jump
    private float jumpVel = 10f; //vel you start jump
	private float jumpFloat = 5f; //acceleration after initial jump, allows for variable jumps
	
	private float jumpHoriVel = 6.0f;
	
	private bool extendedJump;
	
	private float vertSpeed = 0;

	
	void OnStart() {
		GetComponent<AnimeState>().Facing = 1;
	}
    void Update() {
		CharacterController controller = GetComponent<CharacterController>();
		AnimeState animeState = GetComponent<AnimeState>();
		isOnGround = updateGrouded(); 
        
        if (isOnGround) {
			
			//running
			if(Input.GetButton("Sprint")){
				animeState.isRunning = true;
				curHoriVel += runAccel * Time.deltaTime;
				if(curHoriVel>runVel) curHoriVel=runVel;
			}
			else{
				animeState.isRunning = false;
				curHoriVel -= runAccel * Time.deltaTime;
				if(curHoriVel<walkVel) curHoriVel=walkVel;
			}
			curHoriDir = Input.GetAxis("Horizontal");
			facingDirection.x = curHoriDir;
        	moveDirection.x = curHoriDir*curHoriVel;
			
			
            if (Input.GetButton("Jump")){
                moveDirection.y = jumpVel;
				extendedJump = true;
				
			}
			else{
				moveDirection.y = -3f; //magic number to balance high speed ledge falls and not bouncing on floor
			}
			
        }
		else {
			//make sure we are giong the same direction
			if((curHoriDir>0&&Input.GetAxis("Horizontal")>0)||(
				(curHoriDir)<0&&Input.GetAxis("Horizontal")<0)){
				//don't do anything going the same direction
			}
			else{ //you changed direction mid air, revert to jumping speed
				curHoriVel = jumpHoriVel;
			}
			moveDirection.x = curHoriVel * Input.GetAxis("Horizontal");
			facingDirection.x = Input.GetAxis("Horizontal");
			moveDirection.y -= gravity * Time.deltaTime;
			
			//So if we never let go of jump, and we are still going up, we can control how much higher we go
        	if (moveDirection.y>0 && extendedJump && Input.GetButton("Jump"))
                moveDirection.y += jumpFloat * Time.deltaTime;
			else //ok, jump over
				extendedJump = false;
		}
		
		
		moveDirection.z = stayOnZ();
		controller.Move(moveDirection * Time.deltaTime);
		
		updatePlatformLogic();
		
		
		//Animation stuff
		animeState.isGrounded = isOnGround;
		if(facingDirection.x<0)
			animeState.Facing = -1;
		else if(facingDirection.x>0)
			animeState.Facing = 1;
			
		
    }
	
	void updatePlatformLogic(){
		if(Input.GetAxis ("Vertical") == -1){
			gameObject.layer = 9;
		}
		else{
			gameObject.layer = 0;
		}
	}
	

	
	
	
}