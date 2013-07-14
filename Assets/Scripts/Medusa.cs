using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
[RequireComponent(typeof(AudioSource))]

public class Medusa : MonoBehaviour {
	public AudioClip belch;

	//public enum attacks {snake,hair,ground, sweep};
	
	Waypoint[] waypoints;
	List<SnakeHead> heads;
	int wpIndex;
	Waypoint targetwp;
	Vector3 startPos;
	
	string[] attacks = new string[]{"hair","snake"};
	
	float speed = 7;
	float startTime;
	float journeyLength;
	
	string curAttack;
	private GameObject snake;
	
	Random rnd = new Random();
	bool finishedAction = false;
	bool actionInProgress = false;
	// Use this for initialization
	void Start () {
		snake = (GameObject)Resources.Load ("dumbMob");
		FindWayPoints();
		
		curAttack = "snake";
		wpIndex = -1;
		wpIndex = getNextWayPoint(wpIndex,curAttack);
		setNextWayPoint();
		
	}
	
	// Update is called once per frame
	void Update () {
		float distCovered = (Time.time - startTime) * speed;
        float fracJourney = distCovered / journeyLength;
        transform.position = Vector3.Lerp(startPos, targetwp.transform.position, fracJourney);
		if(transform.position == targetwp.transform.position){
			if(!actionInProgress)
				doSubRoutine();
			if(finishedAction){
				wpIndex = getNextWayPoint(wpIndex, curAttack);
				setNextWayPoint();
				finishedAction = false;
			}
		}
			
	}
	
	void FindWayPoints()
    {
		waypoints = FindObjectsOfType(typeof(Waypoint)) as Waypoint[];
    	//waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
		System.Array.Sort(waypoints, delegate(Waypoint wp1, Waypoint wp2) { return wp1.step.CompareTo(wp2.step); });
    	
	}
	
	int getNextWayPoint(int start, string type){
		for(int i = ++start; i<waypoints.Length; i++){
			if(waypoints[i].type == type)
				return i;
		}
		return -1;
	}
	
	void setNextWayPoint(){
		targetwp = waypoints[wpIndex];
		startPos = transform.position;
		journeyLength = Vector3.Distance(startPos,targetwp.transform.position);
		startTime = Time.time;
	}
	
	
	void doSubRoutine() {
		actionInProgress = true;
		switch(targetwp.action){
			case "spawnSnake":
				StartCoroutine("spawnSnake");
				break;
			case "end":
				setNextAttack();
				endAction();
				break;
			
			case "attack":
				StartCoroutine("hairAttack");
				break;
			default:
				endAction();
				break;
		}
	}
	
	IEnumerator spawnSnake(){
		audio.PlayOneShot(belch, 3f);
		
		Instantiate(snake,transform.position,snake.transform.rotation);
		yield return new WaitForSeconds(.5f);
		yield return new WaitForSeconds(.5f);
		endAction();
	}
	
	IEnumerator hairAttack(){
		yield return new WaitForSeconds(.5f);
		heads = new List<SnakeHead>();
		foreach(Transform child in transform){
				Transform go = child.FindChild("SnakeHead");
				if(go){
					heads.Add(go.gameObject.GetComponent<SnakeHead>());
				}
		}
		if(heads.Count>0){
			int i = Random.Range(0,heads.Count);
			if(heads[i])
				heads[i].attackPlayer();
		}
		endAction();
	}
	
	void setNextAttack(){
		wpIndex = -1;
		curAttack = attacks[Random.Range(0,2)];
	}
	
	void endAction(){
		finishedAction = true;
		actionInProgress = false;
	}
}
