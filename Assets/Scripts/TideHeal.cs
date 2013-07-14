using UnityEngine;
using System.Collections;

public class TideHeal : MonoBehaviour {
	public PlayerStatus health;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider player) {
		Debug.Log ("tide");
		if (player.CompareTag ("Player")){
			Destroy(gameObject);
			if (health.hp < health.maxHP) {
				health.hp++;
			}
		}
	}
}
