using UnityEngine;
using System.Collections;

public class PlayerStatus : MonoBehaviour {
	public int maxHP = 2;
	public int hp;
	bool invLayerOn;
	ParticleSystem blood;
	float invTimer;
	float invTime = 2f;
	
	// Use this for initialization
	void Start () {
		hp = maxHP;
		blood = gameObject.transform.FindChild("Blood").GetComponent<ParticleSystem>();
		blood.Stop();
		invLayerOn = false;
	}
	
	// Update is called once per frame
	void Update () {
		
		if(invTimer<=0){
			gameObject.layer = 0;
			invLayerOn = false;
		}else{
			invTimer -= Time.deltaTime;
		}
		
		bool ignoreLayer=gameObject.GetComponent<PlayerEntity>().ignoreLayerOn;
		if(ignoreLayer&&invLayerOn)
			gameObject.layer = 13;
		else if(ignoreLayer)
			gameObject.layer = 9;
		else if(invLayerOn)
			gameObject.layer = 12;
		else
			gameObject.layer = 0;
					
	}
	
	void OnTriggerEnter(Collider collision ) {
		if(collision.transform.tag == "Mob"){
			print ("derp");
			invLayerOn = true;
			invTimer = invTime;
			hp-=1; //variable damage here
			
			
			if(hp<=maxHP/2)
				blood.Play ();
			
			if(hp<=0)
				die();
		}
		
	}
	void die(){
		print ("lolyouded");
	}
	
}
