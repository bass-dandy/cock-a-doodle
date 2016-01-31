using UnityEngine;
using System.Collections;

public class Rain :MonoBehavior{

	public ParticleEmitter rain;

	public boolean raining = false;


	funtion Start(){
        	while(true){
             		float percent = Random.value();
                	if (percent >= 0.93f){
                    		Debug.Log("It will rain for 2 minutes");
                    		rain.active = true;
                    		WaitForSeconds(Random.Range(120.0f, 180.0f));
            	        	rain.active = false;  
                	}
       		 }	
	}
}
 
