using UnityEngine;
using System.Collections;

public class Mob : LivingEntity {
	
	
	public float moveVel;
	
	protected void updateMove() {
		
		CharacterController controller = GetComponent<CharacterController>();
		isOnGround = updateGrouded();
		moveDirection.x = moveVel * facingDirection.x;
		if(isOnGround){
			moveDirection.y = -3f;
		}
		else{
			moveDirection.y -= gravity * Time.deltaTime;
		}
		moveDirection.z = stayOnZ();
		controller.Move(moveDirection * Time.deltaTime);
	}
	
	protected void avoidSides(){
		//check right side
		Vector3 right = transform.TransformDirection(Vector3.right);
		RaycastHit[] hits = Physics.RaycastAll(transform.position, right, 1f);
		if(hits.Length>0){
			foreach(RaycastHit hit in hits){
				//we want to aim for the Player
				if(hit.transform.tag == "Player" || hit.transform.tag == "Projectile"){
					facingDirection = Vector3.right;
					return;
				}
			}
			facingDirection = -1*Vector3.right; //turn around
		}
		
		//check left side
		Vector3 left = transform.TransformDirection(-1*Vector3.right);
		hits = Physics.RaycastAll(transform.position, left, 1f);
		if(hits.Length>0){
			foreach(RaycastHit hit in hits){
				//we want to aim for the Player
				if(hit.transform.tag == "Player" || hit.transform.tag == "Projectile"){
					facingDirection = -1*Vector3.right;
					return;
				}
			}
			facingDirection = Vector3.right; //turn around
		}
	}
}
