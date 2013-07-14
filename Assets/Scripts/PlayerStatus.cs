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
			changeOpacity(1f);
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
		transform.position = new Vector3(transform.position.x, transform.position.y, 0);
		if(collision.transform.tag == "Mob"){
			changeOpacity(.5f);
			invLayerOn = true;
			invTimer = invTime;
			hp-=1; //variable damage here
			
			
			if(hp<=maxHP/2)
				blood.Play ();
			
			if(hp<=0)
				die();
		}
		if(collision.transform.tag == "Projectile"){
		}
	}
	void die(){
		print ("lolyouded");
	}
	
	void changeOpacity(float val){
		Renderer[] rends = gameObject.GetComponentsInChildren<Renderer>();
		
		foreach(Renderer rend in rends){
			Color color = rend.material.color;
			color.b = val;
			renderer.material.SetColor("_Color",color);
		}
	}
}
