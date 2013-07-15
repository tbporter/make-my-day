using UnityEngine;
using System.Collections;

public class MobStatus : MonoBehaviour {
	public GameObject shard;
	public int hp = 1;
	private float indicatorTimer;
	public float indicatorTime = .15f;
	private InjuredScript injured;
	// Use this for initialization
	void Start () {
		injured = GetComponent<InjuredScript>();
	}
	
	// Update is called once per frame
	void Update () {
			indicatorTimer -= Time.deltaTime;
		if(indicatorTimer<=0){
			if(injured!=null){
				injured.Damage = false;
			}
		}
		
	}
	
	public void OnCollisionEnter(Collision collision ) {
		print ("collided");
		if(collision.transform.tag == "Projectile"){
			Destroy(collision.gameObject);
			hp-=1;
			if(injured!=null){
				injured.Damage = true;
			}
			indicatorTimer= indicatorTime;
			if(hp<=0)
				die(collision.contacts[0].point);
		}
		
	}
	
	public void die(){
		die (transform.position);
	}
	public void die(Vector3 hitLoc){
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
