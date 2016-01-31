using UnityEngine;
using System.Collections;

public class Moving : MonoBehaviour {
	public Transform player;
	public bool moving = false;
	public Vector3 current_pos;
	public float secs = 0.0f;
	public AudioClip sound;

	void Start(){
		current_pos = player.position;
		GetComponent<AudioSource>().clip = sound;
		//GetComponent<AudioSource>().playOnWake = false;
	}

	void Update(){
		GetComponent<AudioSource>().clip = sound;
		if(GetComponent<AudioSource>().isPlaying){
			secs = 40000.0f;
			while(secs > 0.0f){
				secs -= Time.deltaTime;
				//Debug.Log("");
				
			}
		}
		if(current_pos != player.position){
			//Debug.Log("moving");
			current_pos = player.position;
			moving = true;
		}
		else{
			//Debug.Log("Stopped moving");
			if(secs > 0.0f){
				secs -= Time.deltaTime;
			}
			GetComponent<AudioSource>().Stop();
			moving = false;
		}
		if(!GetComponent<AudioSource>().isPlaying && moving){
			//Debug.Log("whut");
			//GetComponent<AudioSource>().loop = true;		
    			GetComponent<AudioSource>().Play();
		}
		else{
			if(secs > 0.0f){
				secs -= Time.deltaTime;
			}
		}
	}	
}			
		
	
