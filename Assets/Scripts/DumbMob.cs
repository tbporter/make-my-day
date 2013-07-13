using UnityEngine;
using System.Collections;
   using System.Collections.Generic;
public class DumbMob : Mob {

	// Use this for initialization
	void Start () {
		facingDirection = startingDirection;
	}
	
	// Update is called once per frame
	void Update () {
		updateMove();
		
	}
	
	void FixedUpdate() {
		avoidSides ();
	}
	
}
