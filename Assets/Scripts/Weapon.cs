using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {
	
	public GameObject bullet;
	
	private bool isShooting = false;
	private float lastFired = 0;
	
	public float bulletForce;
	public float fireRate;
	public float bulletLife = 4;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
;
		if(Input.GetButton("Fire1")){
			isShooting = true;
		}else{
			isShooting = false;
		}
		transform.parent.GetComponent<AnimeState>().isShooting = isShooting;
	}
	
	void FixedUpdate () {
		if(isShooting && lastFired>fireRate){
			lastFired = 0;
			float face = gameObject.transform.parent.GetComponent<AnimeState>().Facing;
			//GameObject firedBullet = (GameObject) Instantiate(bullet,transform.position,bullet.transform.rotation);
			GameObject firedBullet = (GameObject) Instantiate(bullet,transform.position,bullet.transform.rotation);
			Collider[] colliders = transform.parent.GetComponents<Collider>();
			foreach(Collider col in colliders){
				Physics.IgnoreCollision(col,firedBullet.collider);
			}
			firedBullet.rigidbody.AddForce (new Vector3(bulletForce*face,0,0));
			Destroy (firedBullet, bulletLife);
			//firedBullet.rigidbody.AddForce (transform.forward*bulletForce);
		}
		lastFired += Time.deltaTime;
	}
}
