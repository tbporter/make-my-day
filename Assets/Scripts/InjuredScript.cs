using UnityEngine;
using System.Collections;

public class InjuredScript : MonoBehaviour {
	public bool Damage = false;
	public Component[] r;
	Color c;
	float EndTime;
	float interval = .2f;
	bool normalState = true;

	void Start () {
		c = Color.white;
	}
	
	void Update () {
		if (Damage == true) {
			normalState = false;
		/*
			
			EndTime = Time.time + 3;
			normalState = false;
			Damage = false;
		}	
		if (EndTime > Time.time) {
		*/
			r = GetComponentsInChildren<Renderer>();
			float blink = Time.time % interval;	
			
	        foreach (Renderer damage in r) {
				if (blink < (interval*.5)) damage.renderer.material.color = c;
				else damage.renderer.material.color = Color.red;
			}	
		}
		
		else if (normalState == false) {
			foreach (Renderer damage in r) {
				damage.renderer.material.color = c;
			}
			normalState = true;
		}
		// fix so it doesn't stay
	}
}
 