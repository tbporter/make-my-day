using UnityEngine;
using System.Collections;

public class HealthPowerup : Powerup {

	override public void getPwer(GameObject pickUper){
		PlayerStatus ps = pickUper.GetComponent<PlayerStatus>();
		ps.hp = ps.maxHP;
		ps.bleed(false);
	}
	
}
