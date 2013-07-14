using UnityEngine;
using System.Collections;

public class LivingEntity : MonoBehaviour {
	
	public Vector3 facingDirection;
	public Vector3 startingDirection;
	protected Vector3 moveDirection = Vector3.zero;
	
	public float gravity = 20.0f;
	// Use this for initialization
	void Start () {
		
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	
	protected float lastOnGround = 0;
	protected bool isOnGround = false;
	protected float lastOnBuffer = .05f;
	
	protected bool updateGrouded(){
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
	protected float stayOnZ(){
		if(transform.position.z>0)
			return -.2f;
		else if(transform.position.z<0)
			return .2f;
		
		return 0f;
	}
}
