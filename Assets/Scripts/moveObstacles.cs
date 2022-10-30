using UnityEngine;
using System.Collections;

public class moveObstacles : MonoBehaviour {

	public float speed;
	private float x;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		x = transform.position.x;
		x += speed * Time.deltaTime;

		transform.position = new Vector3 (x, transform.position.y, transform.position.z);

		if (x <= -7){
			Destroy(transform.gameObject);
		}
}
}