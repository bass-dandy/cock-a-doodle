using UnityEngine;
using System.Collections;




public class Noisefade : MonoBehaviour{

	public AudioClip sound;


	void OnTriggerEnter(){
    		GetComponent<AudioSource>().clip = sound;
    		GetComponent<AudioSource>().PlayDelayed(0.47f);
	}

	void SoundVolume(Collider zone){
    		GameObject rooster = GameObject.Find("Rooster");
    		Vector3 center = zone.center;
    		float distance = Distance(rooster.transform.position, center);
    		switch(distance){
        		case distance <= 0.3f:
            		GetComponent<AudioSource>().volume = 1.0f;
            		break;
        		case distance <= 0.6f:
            		GetComponent<AudioSource>().volume = 0.75f;
            		break;
        		case distance <= 0.9f:
            		GetComponent<AudioSource>().volume = 0.5f;
            		break;
        		case distance <= 1.2f:
            		GetComponent<AudioSource>().volume = 0.25f;
            		break;
        		default:
            		GetComponent<AudioSource>().volume = 0.1f;
            		break;
    		}
	}	

	void OnTriggerExit(){
    	GetComponent<AudioSource>().stop();
	}
}
    
 
  
