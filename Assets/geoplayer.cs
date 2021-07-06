using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class geoplayer : MonoBehaviour {

	public Rigidbody2D rb;
	public float speed;
	public float Xspeed;
	public Animator anime;
	public Slider slider;
	public int score;
	public Text scoreT;
	public GameObject lantern;
	public Color[] colors;
	public Color blackcolor;
	public Material blackmaterial;
	public SpriteRenderer sr;
	public GameObject bloodp;
	public Transform pp;
	public BoxCollider2D bc;
	private float smallbc;
	private float bigbc;
	private moving_bg bg;
	public GameObject scoreupT;
	public Gradient gradient;
	public Image Fill;
	public Text Goscore;
	public GameObject GameOver;
	public SceneLoader sceneloader;
	public GameObject shoytan;
	private bool shoot = false;
	public GameObject blade;
	public float firespeed;
	public GameObject blast;
	public float rate;
	public float nextTime;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D > ();	
		anime = GetComponent<Animator> ();
		slider.value = slider.maxValue;
		sr = GetComponent<SpriteRenderer> ();
		bc = GetComponent<BoxCollider2D> ();
		bigbc = 3.958097f;
		smallbc = 2f;
		bg = FindObjectOfType<moving_bg> ();
		sceneloader = FindObjectOfType<SceneLoader> ();

		
	}
	
	// Update is called once per frame
	void Update () {
		Fill.color = gradient.Evaluate(1f);

		if(Input.GetMouseButtonDown(0)) {
			if(transform.position.y < 1.43f) {
				anime.SetBool("slide", false);
				rb.AddForce(Vector2.up * speed );

			} 

		} 
		transform.position+= new Vector3(Xspeed,0,0)* Time.deltaTime;
	   if(slider.value > 0){
			ParticleSystem.MainModule whatever = transform.GetChild (1).GetComponent<ParticleSystem> ().main;
			whatever.startColor = new ParticleSystem.MinMaxGradient(Color.yellow);

	   }
	if(transform.position.y < -5){
		slider.value = 0;
	}
		if(Time.time > nextTime) {

            ColorChange ();
            nextTime = Time.time + rate;
   		}  




		if((shoytan.transform.position.x - transform.position.x < 6) & (shoytan.transform.position.x - transform.position.x > 5)){
			shoot = true;
		}


		if((shoytan.transform.position.x - transform.position.x < 5.4) & (shoytan.transform.position.x - transform.position.x > 5) & shoot == true){
			GameObject firerb = Instantiate(blade,shoytan.transform.position,Quaternion.identity);
			firerb.GetComponent< Rigidbody2D> (). velocity = Vector3.right * (-firespeed)/2; 
			Destroy(firerb,3.5f);
			 shoot = false;

		}


		if (Input.GetAxis ("Vertical") < 0) {
			anime.SetBool("slide", true);
			bc.size = new Vector2 (bc.size.x, smallbc);
			//var ewe2 = bc.size.y;
			//ewe2 = smallbc;
			Invoke ("normalgeoanim", 2.5f);
		}

		if (Input.touchCount > 0) {
			rb.AddForce(Vector2.up * speed );
		}
		if (slider.value <= 0) {
			//Instantiate (bloodp, pp.position, Quaternion.identity);
			bloodp.SetActive(true);
			bloodp.transform.position = this.transform.position;
			sr.color = blackcolor;

			ParticleSystem.MainModule whatever = transform.GetChild (1).GetComponent<ParticleSystem> ().main;
			whatever.startColor = new ParticleSystem.MinMaxGradient(blackcolor);
			//var cc = whatever.main.startColor; 
			//cc	= blackcolor;
			Invoke ("sshit", 2f);
		}

	}
	void OnTriggerEnter2D (Collider2D col) {
		if(col.gameObject.tag == "coin") {
			IncrementScore ();
			scoreupT.transform.position = col.transform.position;
			Rigidbody2D scorerb = scoreupT.GetComponent<Rigidbody2D> ();
			scorerb.velocity = Vector2.up * 2f;
			scorerb.velocity = Vector2.up * 2f;
			//Invoke("coinActive", 3.5f);
			//Destroy(gameObject);
		}
		if (col.gameObject.tag == "edge") {
			Debug.Log (col.name);
			//ColorChange ();
			slider.value -= 10f;
			//gradient.Evaluate (1f);

		}
	if (col.gameObject.tag == "blade") {
			//ColorChange ();
			
			blast.transform.position= transform.position;
			slider.value -= 10f;
			blast.SetActive(true);
			//gradient.Evaluate (1f);
			Invoke("blastactive",3f);

		}


	}
	void OnCollisionEnter2D (Collision2D col) {
		if(col.gameObject.tag == "edge") {
			//Destroy(gameObject);
		}
	}
	public void normalgeoanim() {
		anime.SetBool("slide", false);
		//var ewe = bc.size.y;
		//ewe = bigbc;
		bc.size = new Vector2 (bc.size.x, bigbc);
	}

	public void IncrementScore () {

		score++;
		scoreT.text = score.ToString ();
	} 

	void ColorChange () {
		int colorindex = Random.Range (0, 5);
		Color Lcolor = colors [colorindex];
		lantern.GetComponent<SpriteRenderer> ().color = Lcolor;



	}
	public void sshit () {
		gameObject.SetActive (false);
		bg.bgspeed = 0f;
		bg.rbs.velocity = new Vector3 (-bg.bgspeed, 0, 0);
		Goscore.text = scoreT.text;
		GameOver.SetActive(true);
		



	}
	public void blastactive(){
		blast.SetActive(false);
		blast.transform.position = new Vector3(transform.position.x,transform.position.y + 20, transform.position.z);
	}



}
