using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Attractor : MonoBehaviour {

	public Rigidbody2D Ball;

	private void Awake() {
		Ball = GetComponent<Rigidbody2D>();
	}

	private void Start() {
		GetComponent<SpriteRenderer>().color = new Color(Random.Range(0.5f,1f),Random.Range(0.5f,1f),Random.Range(0.5f,1f));
		GetComponent<TrailRenderer>().material.color = GetComponent<SpriteRenderer>().color;
	}
	void FixedUpdate(){
		Attractor[] attractors = FindObjectsOfType<Attractor>();
		foreach(Attractor attractor in attractors){
			if(attractor != this)
				Attract(attractor);
		}
	}

	// Use this for initialization
	void Attract(Attractor objToAttract){
		Rigidbody2D rbToAttract = objToAttract.Ball;
		Vector2 direction = Ball.position - rbToAttract.position;
		float distance = direction.magnitude;
		float forceMagnitude  = 1.0f;
		Vector2 force = direction.normalized * forceMagnitude;
		rbToAttract.AddForce(force);
	}
}