using UnityEngine;
using System.Collections;
[RequireComponent(typeof(AudioSource))]

public class PlayerStatus : MonoBehaviour {
	public int maxHP = 2;
	public int hp;
	public AudioClip ouch;
	
	bool invLayerOn;
	ParticleSystem blood;
	float invTimer;
	float invTime = 2f;
	
	// Use this for initialization
	void Start () {
		hp = maxHP;
		blood = gameObject.transform.FindChild("Blood").GetComponent<ParticleSystem>();
		bleed (false);
		invLayerOn = false;

	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<InjuredScript>().Damage = invLayerOn;
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
		if(collision.transform.tag == "Mob" || collision.transform.tag == "Projectile"){
			changeOpacity(.5f);
			invLayerOn = true;
			Debug.Log ("ouch");
			audio.PlayOneShot(ouch, 1F);
			
			invTimer = invTime;
			hp-=1; //variable damage here
			
			
			if(hp<=maxHP/2)
				bleed (true);
			
			if(hp<=0)
				die();
		}
		else if(collision.transform.tag == "Projectile"){
		}
		else if(collision.transform.tag == "PowerUp"){
			collision.gameObject.GetComponent<Powerup>().getPwer (this.gameObject);
			Destroy (collision.gameObject);
		}
	}
	void die(){
		Application.LoadLevel (Application.loadedLevelName);
	}
	
	void changeOpacity(float val){
		/*Renderer[] rends = gameObject.GetComponentsInChildren<Renderer>();
		
		foreach(Renderer rend in rends){
			Color color = rend.material.color;
			color.b = val;
			renderer.material.SetColor("_Color",color);
		}*/
	}
	
	public void bleed(bool b){
		
		if(b){
			blood.Play();
		}
		else{
			blood.Stop();
		}
	}
}
