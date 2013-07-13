using UnityEngine;
using System.Collections;

public class MobStatus : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnCollisionEnter(Collision collision ) {
		
		if(collision.transform.tag == "Projectile"){
			Destroy(collision.gameObject);
			die();
		}
		
	}
	void die(){
		
		
		Vector3 middle = transform.position;
		float width = transform.localScale.x/3f;
		float height = transform.localScale.z/3f;
		
		GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
		plane.transform.Rotate(new Vector3(-90,0,0));
		plane.transform.localScale = new Vector3(width,0,height);
		plane.transform.position = middle + new Vector3(-1*width,-1*height,0);
		
		
		Destroy(gameObject);
	}
}
