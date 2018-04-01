using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zigzag : MonoBehaviour {

	

	public static double D0 = Diffusion_Constant(300, 8.90e-4, 2e-7);
	public static float D = (float)D0;
	public static int count = 0;
	public static int No_Frames =30;
	Vector2 Old_Vel = new Vector2(0.0f,0.0f);
	Rigidbody2D Particle;
	
	

	// Use this for initialization
	void Start () {
		Particle = GetComponent<Rigidbody2D>();
		Particle.velocity = Old_Vel;
	}

//Method to Produce Random Distributed Gaussian Variables
	public static float NextGaussian() {
    float v1, v2, s;
    do {
        v1 = 2.0f * Random.Range(0f,1f) - 1.0f;
        v2 = 2.0f * Random.Range(0f,1f) - 1.0f;
        s = v1 * v1 + v2 * v2;
    } while (s >= 1.0f || s == 0f);	
    s = Mathf.Sqrt((-2.0f * Mathf.Log(s)) / s);	
    return v1 * s;
}

//Method to calculate diffusion_constant
public static double Diffusion_Constant(double Abs_Temp,double viscosity,double radius)
		{
			double pi = Mathf.PI;
			double boltzmann_constant = 1.380648e-23;
			return (boltzmann_constant * Abs_Temp) / (6 * pi * viscosity * radius);
		}

//Method to calculate sigma
public static float Sigma(float Diff_Const)
		{
			float pi = Mathf.PI;
			return Mathf.Sqrt(4 * Diff_Const / pi);

		}

	//size of dna is 1/10 size of e.coli
	
	// Update is called once per frame
	void FixedUpdate () {
		float increment_factor_1 = (Mathf.Sqrt(Time.deltaTime) * NextGaussian()* Sigma(D))/Time.deltaTime;
		float increment_factor_2 = (Mathf.Sqrt(Time.deltaTime) * NextGaussian()* Sigma(D))/Time.deltaTime;		
		count++;
		if(count == No_Frames){
			//assumed that 1m in unity is 10e-5m
			float New_Increment_factor_1 = (float)10e4*increment_factor_1/Mathf.Sqrt(No_Frames);
			float New_Increment_factor_2 = (float)10e4*increment_factor_2/Mathf.Sqrt(No_Frames);			
			Vector2 Increment_Vel = new Vector2(New_Increment_factor_1,New_Increment_factor_2);
			Vector2 New_Vel = Old_Vel + Increment_Vel;
			Particle.velocity = New_Vel;
			print(New_Vel);
			Old_Vel = New_Vel;
			count = 0;
						
		}
	}
}