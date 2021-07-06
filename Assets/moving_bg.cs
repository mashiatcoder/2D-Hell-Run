using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class moving_bg : MonoBehaviour {
	public Rigidbody2D rbs;
	public BoxCollider2D bc;
	public Transform player;
	public float numberofP;
	public float bgspeed;
	public float deltaX;
	public string playertag;
	// Use this for initialization
	void Start () {
		rbs = GetComponent<Rigidbody2D> ();
		bc = GetComponent<BoxCollider2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		rbs.velocity = new Vector3 (0, 0, 0);
		if (transform.position.x < (player.position.x - 14f)) {
			Vector3 temp = new Vector3 (player.position.x - 1.5f + (numberofP * bc.size.x),0, 0);
			
			transform.position = temp;
			//Debug.Log(Vector3.position(player.position - transform.position));
			
		}
		
	}
	private void OnTriggerExit2D(Collider2D other) {
		/*if(other.gameObject.tag == "Player"){
			transform.position = new Vector2(transform.position.x + 5*bc.size.x,0);
		}*/
	}
}
