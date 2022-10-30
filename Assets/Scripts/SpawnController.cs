using UnityEngine;
using System.Collections;

public class SpawnController : MonoBehaviour {

	public GameObject obstaclePreFab;
	public float spawnRate;
	private float currentTime;
	private int position;
	private float y;
	public float posA;
	public float posB;


	// Use this for initialization
	void Start () {
		currentTime = 0; 
	
	}
	
	// Update is called once per frame
	void Update () {
		currentTime += Time.deltaTime;
		if (currentTime >= spawnRate) {
			position = Random.Range(1,100);
			Debug.Log(position);
			if(position > 50){
				y = posA;
			}else
				y = posB;

			currentTime = 0;
			GameObject tempPrefab = Instantiate(obstaclePreFab) as GameObject;
			tempPrefab.transform.position = new Vector3(transform.position.x,y, transform.position.z);
		}
	}
}
