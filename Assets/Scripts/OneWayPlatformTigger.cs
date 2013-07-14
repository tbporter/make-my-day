using UnityEngine;
using System.Collections;

public class OneWayPlatformTigger : MonoBehaviour {

	void OnTriggerEnter(Collider jumper){
		Collider platform = transform.parent.collider;
		Physics.IgnoreCollision (jumper.GetComponent<CharacterController>(),platform);
	}
	void OnTriggerExit (Collider jumper){
		jumper.gameObject.layer = 0;
		Collider platform = transform.parent.collider;
		Physics.IgnoreCollision (jumper.GetComponent<CharacterController>(),platform,false);
	}
}
