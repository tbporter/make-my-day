using UnityEngine;
using System.Collections;

public class HealthPowerup : Powerup {
	ParticleSystem bubbles;
	override public void getPwer(GameObject pickUper){
		
		bubbles = gameObject.transform.FindChild("Bubbles").GetComponent<ParticleSystem>();
		bubbles.Play();
		
		PlayerStatus ps = pickUper.GetComponent<PlayerStatus>();
		ps.hp = ps.maxHP;
		ps.bleed(false);
		
		
	}
	
}
