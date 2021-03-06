using UnityEngine;
using System.Collections;
[RequireComponent(typeof(AudioSource))]

public class FlyingMob : LivingEntity {
	public AudioClip cackle;
	GameObject player;
	
	public float detectRange = 30;
	public float flightForce = 1000f;
	private bool idle = true;
	private bool cackled = false;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void FixedUpdate(){
		if(Vector3.Distance (transform.position,player.transform.position)<detectRange){
			AnimeState animeState = GetComponent<AnimeState>();
			idle = false;
			if (!cackled && !idle) audio.PlayOneShot (cackle); cackled = true;
			cackled = true;
			Vector3 dir = player.transform.position - transform.position;
			if(dir.x>=0)
				animeState.Facing = 1;
			else
				animeState.Facing = -1;
			rigidbody.AddForce(dir.normalized*flightForce);
		}
		else{
			idle = true;
		}
		stayOnZ();
	}
}
