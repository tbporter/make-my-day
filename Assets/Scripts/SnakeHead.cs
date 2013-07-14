using UnityEngine;
using System.Collections;

public class SnakeHead : MonoBehaviour {
	public GameObject bullet;
	// Use this for initialization
	void Start () {
		bullet=(GameObject)Resources.Load("FireBall");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void attackPlayer() {
		Transform player = GameObject.FindGameObjectWithTag("Player").transform;
		transform.LookAt(player.position);
		transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);
		GameObject firedBullet = (GameObject) Instantiate(bullet,transform.position,transform.rotation);
		Vector3 dir = new Vector3(player.position.x - transform.position.x,player.position.y - transform.position.y,0).normalized;
		firedBullet.rigidbody.AddForce (dir * 1000f);
		Destroy (firedBullet,4);
	}
}
