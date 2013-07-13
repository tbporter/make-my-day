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
		if(Input.GetButton("Fire1")){
			isShooting = true;
		}else{
			isShooting = false;
		}
		//transform.LookAt(Camera.main.ScreenToWorldPoint(Input.mousePosition));
	}
	
	void FixedUpdate () {
		if(isShooting && lastFired>fireRate){
			lastFired = 0;
			//GameObject firedBullet = (GameObject) Instantiate(bullet,transform.position,bullet.transform.rotation);
			GameObject firedBullet = (GameObject) Instantiate(bullet,transform.position,bullet.transform.rotation);
			Physics.IgnoreCollision(transform.parent.collider,firedBullet.collider);
			firedBullet.rigidbody.AddForce (new Vector3(bulletForce,0,0));
			Destroy (firedBullet, bulletLife);
			//firedBullet.rigidbody.AddForce (transform.forward*bulletForce);
		}
		lastFired += Time.deltaTime;
	}
}
