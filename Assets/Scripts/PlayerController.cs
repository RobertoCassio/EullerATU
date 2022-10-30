using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public Rigidbody2D PlayerRigidbody;
	public int forceJump;
	public Animator Anime;

	public bool slide;

	//Verificador de chao
	public Transform GroundCheck;	
	public bool grounded;
	public LayerMask whatIsGround;

	//Slider
	public float slideTemp;
	public float timeTemp;

	//Colider
	public Transform colisor;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Jump")&& grounded == true ){
			PlayerRigidbody.AddForce(new Vector2(0,forceJump));
			if (slide == true){
				colisor.position = new Vector3(colisor.position.x,colisor.position.y + 0.221f,colisor.position.z);
			}
			slide = false;
		}

		if (Input.GetButtonDown ("Slide")&& grounded == true) {
			if (slide==false){
			colisor.position = new Vector3(colisor.position.x,colisor.position.y - 0.221f,colisor.position.z);
			}slide = true;
			timeTemp = 0;

		}

		grounded = Physics2D.OverlapCircle (GroundCheck.position, 0.2f, whatIsGround);

		if (slide == true) {
			timeTemp += Time.deltaTime;
			if (timeTemp >= slideTemp) 
			{
				slide = false;
				colisor.position = new Vector3(colisor.position.x,colisor.position.y + 0.221f,colisor.position.z);
			}
		}

		Anime.SetBool ("jump", !grounded);
		Anime.SetBool ("slide", slide);
		
	}
	void OnTriggerEnter2D(){
		Application.LoadLevel ("GameOver");
	}
}