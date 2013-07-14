using UnityEngine;
using System.Collections;

public class MobStatus : MonoBehaviour {
	public GameObject shard;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnCollisionEnter(Collision collision ) {
		
		if(collision.transform.tag == "Projectile"){
			Destroy(collision.gameObject);
			die(collision.contacts[1].point);
		}
		
	}
	void die(Vector3 hitLoc){
		
		int[,] positions = new int[,] { { -1,-1},{-1,0},{-1,1},{0,-1},{0,0},{0,1},{1,-1},{1,0},{1,1}};
		
		
		Vector3 middle = transform.position;
		float width = transform.localScale.x/3f;
		float height = transform.localScale.z/3f;
		Destroy(gameObject);
		
		GameObject plane;
		for(int i=0;i<positions.GetLength(0);i++){;
			Vector3 pos = new Vector3((positions[i,0]*width*10)+middle.x,(positions[i,1]*height*10)+middle.y,0);	
			
			plane = (GameObject) Instantiate(shard,pos,shard.transform.rotation);
			plane.transform.localScale = new Vector3(width,0,height);
			
			plane.rigidbody.AddExplosionForce(700f,hitLoc,10f,0f);
			Destroy (plane,3);
		}

		
		
	}
}
