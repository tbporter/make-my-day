using UnityEngine;
using System.Collections;

public class DieCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider collision){
		print ("death");
		collision.transform.GetComponent<PlayerStatus>().die ();
	}
}
