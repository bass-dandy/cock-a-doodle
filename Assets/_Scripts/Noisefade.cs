using UnityEngine;
using System.Collections;




public class Noisefade : MonoBehaviour{

	public AudioClip sound;


	void OnTriggerEnter(){
    		GetComponent<AudioSource>().clip = sound;
    		GetComponent<AudioSource>().PlayDelayed(0.47f);
	}

	void SoundVolume(SphereCollider zone){
    		GameObject rooster = GameObject.Find("Rooster");
    		Vector3 center = zone.center;
    		float distance = Vector3.Distance(rooster.transform.position, center);
    		if(distance <= 0.3f){
			GetComponent<AudioSource>().volume = 1.0f;
           	}
        	else if(distance <= 0.6f){
            		GetComponent<AudioSource>().volume = 0.75f;
            	}
                else if(distance <= 0.9f){
            		GetComponent<AudioSource>().volume = 0.5f;
            	}
        	else if(distance <= 1.2f){
			GetComponent<AudioSource>().volume = 0.25f;
		}
		else{
            		GetComponent<AudioSource>().volume = 0.1f;
    		}
	}	

	void OnTriggerExit(){
    		GetComponent<AudioSource>().Stop();
	}
}
    
 
  
