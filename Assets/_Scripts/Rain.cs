using UnityEngine;
using System.Collections;

public class Rain :MonoBehaviour{

	public ParticleEmitter rain;

	public bool raining = false;


	void Start(){
        	while(true){
             		float percent = Random.value;
                	if (percent >= 0.93f){
                    		Debug.Log("It will rain for 2 minutes");
							rain.emit = true;
                    		//WaitForSeconds(Random.Range(120, 180));
							rain.emit = false;  
                	}
       		 }	
	}
}
 
