using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	public GameObject prefab;
	public string prefabS;
	// Use this for initialization
	void Start () {
		if(prefab == null)
			prefab = (GameObject) Resources.Load(prefabS);
			
		Instantiate(prefab,transform.position,transform.rotation);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
