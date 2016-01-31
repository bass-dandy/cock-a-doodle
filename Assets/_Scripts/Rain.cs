using UnityEngine;
using System.Collections;

public class Rain :MonoBehaviour{

	public ParticleEmitter rain;
	public bool raining = false;
	public float secs = 0.0f;


	void Start(){
		rain.emit = false;
		float percent = Random.value;
             	if (percent >= 0.99995f){
			rain.emit = true;
			Clock(120.0f);
			rain.emit = false;
       		 }	
	}

	void Update(){
		if(!(raining)){
			float percent = Random.value;
			if(percent >= 0.99995f){
				secs = 120.0f;
				rain.emit = true;
				raining = true;
			}
		}
		else{
			if(secs > 0.0f){
				secs -= Time.deltaTime;
			}
			else{
				raining = false;
				rain.emit = false;
			}
		}
		
	}


	void Clock(float time){
		while(time > 1.0f){
			time -= Time.deltaTime;
		}
	}

		
}


