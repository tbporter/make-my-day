using UnityEngine;
using System.Collections;

public class HairSnake : MonoBehaviour {

	int spinDir = 1;
	float spinSpeed = 20;
	void Start(){
		randomize ();
	}
	void Update(){
		Vector3 loc = collider.bounds.center +(transform.up*-2);
		transform.RotateAround(loc,spinDir*Vector3.forward,spinSpeed*Time.deltaTime);
	}
    void FixedUpdate()
    {
	
	}
	void randomize(){
		if(randBool())
			spinDir = 1;
		else
			spinDir = -1;
		spinSpeed = Random.Range(10,80);
	}
	
	bool randBool(){
		return (Random.value>.5f);
	}

}
