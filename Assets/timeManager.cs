using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class timeManager : MonoBehaviour {

	public Text running;
	public Text endTime;

	public static timeManager instance;

	private void Awake() {
		if(instance == null)
		instance = this;

		if(this != instance){
			Destroy(this.gameObject);
		}
	}
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(this);
	}
	
	// Update is called once per frame
	void Update () {
		running.text = "Running Time : " + Time.timeSinceLevelLoad.ToString();
		
	}
}
