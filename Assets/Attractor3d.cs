using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(Rigidbody))]
public class Attractor3d : MonoBehaviour {

	public Rigidbody Ball;

	private void OnCollisionEnter(Collision other) {
		if(other.transform.CompareTag("particle"))
		{
		timeManager.instance.endTime.text = "Collision From Previous Simulation :" + Time.timeSinceLevelLoad.ToString();
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}
	private void Awake() {
		Ball = GetComponent<Rigidbody>();
	}

	private void Start() {
		GetComponent<MeshRenderer>().material.color = new Color(Random.Range(0.5f,1f),Random.Range(0.5f,1f),Random.Range(0.5f,1f));
		transform.position = new Vector3(Random.Range(-20f,20f),Random.Range(-20f,20f),Random.Range(-20f,20f));
		//GetComponent<TrailRenderer>().material.color = GetComponent<M().color;
	}
	void FixedUpdate(){
		Attractor3d[] Attractor3ds = FindObjectsOfType<Attractor3d>();
		foreach(Attractor3d Attractor3d in Attractor3ds){
			if(Attractor3d != this)
				Attract(Attractor3d);
		}
	}

	// Use this for initialization
	void Attract(Attractor3d objToAttract){
		Rigidbody rbToAttract = objToAttract.Ball;
		Vector3 direction = Ball.position - rbToAttract.position;
		float distance = direction.magnitude;
		float forceMagnitude  = 1.0f;
		Vector3 force = direction.normalized * forceMagnitude;
		rbToAttract.AddForce(force);
	}
}