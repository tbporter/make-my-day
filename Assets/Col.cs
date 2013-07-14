using UnityEngine;
using System.Collections;

public class Col : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	
	public void OnTriggerEnter(Collider collision ) {
		print ("trigger");
		if(collision.transform.tag == "Projectile"){
			Destroy(collision.gameObject);
			//Destroy(transform.parent.gameObject);
			MobStatus st = transform.parent.GetComponent<MobStatus>();
			st.die ();
		}
	}
}
