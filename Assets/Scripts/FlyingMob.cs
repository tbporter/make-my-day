using UnityEngine;
using System.Collections;

public class FlyingMob : MonoBehaviour {
	
	GameObject player;
	
	public float detectRange = 30;
	public float flightForce = 1000f;
	private bool idle = true;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void FixedUpdate(){
		if(Vector3.Distance (transform.position,player.transform.position)<detectRange){
			idle = false;
			Vector3 dir = player.transform.position - transform.position;
			print (dir.normalized*flightForce);
			rigidbody.AddForce(dir.normalized*flightForce);
		}
		else{
			idle = true;
		}
	}
}
