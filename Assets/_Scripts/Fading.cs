using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class Fading :MonoBehaviour{


    public AudioClip current_track;
    public AudioClip replace_track;
    public AudioClip default_track;
    public AudioClip cow_track;
    public AudioClip hen_track;
    public AudioClip sheep_track;
    public AudioClip duck_track;
    public AudioClip horse_track;
    public AudioClip dog_track;
    public AudioClip pig_track;
    public AudioClip cat_track;    



    IEnumerator Start(){
	GetComponent<AudioSource>().clip = current_track;
    	GetComponent<AudioSource>().Play();
	yield return null;
    }
            
   
    public float current_track_vol = 1.0f;
    public float replace_track_vol = 0.0f;
    private bool replace_playing = false;
    
    
      
    /**
    * Update consistently where you change the track depending on your location
    * Ex. enter dog region, dog instrument fades in and main instrument fades out
    * trigger a loop. My idea is to have an OnTriggerEnter for each location
    * with the Update and other functions being there overall
    */
         
    void OnTriggerEnter ( Collider zone){
        switch(zone.tag){
            case "cow":
                Debug.Log("cowzone");
                replace_track = cow_track;
                break;
            case "hen":
                Debug.Log("henzone");
                replace_track = hen_track;
                break;
            case "sheep":
                Debug.Log("sheepzone");
                replace_track = sheep_track;
                break;
            case "duck":
                Debug.Log("duckzone");
                replace_track = duck_track;
                break;
            case "horses":
                Debug.Log("horsezone");
                replace_track = horse_track;
                break;
            case "dog":
                Debug.Log("dogzone");
                replace_track = dog_track;
                break;
            case "pig":
                Debug.Log("pigzone");
                replace_track = pig_track;
                break;
            case "cat":
                Debug.Log("catzone");
                replace_track = cat_track;
                break;
            default:
                Debug.Log("defaultzone");
                replace_track = default_track;
                break;
            
        }
        replace_playing = false;
        current_track_vol = GetComponent<AudioSource>().volume;
        replace_track_vol = 0.0f;                                  
    }
    
    
    /**
    * Fade in replacement track and fade out other track
    */
                                  
    void Update(){
        fadeOut();
        
        if (current_track_vol <= 0.1f) {
            if(replace_playing == false){
                replace_playing = true;
                GetComponent<AudioSource>().clip = replace_track;
                GetComponent<AudioSource>().Play();
            }
            fadeIn();
        }
    }

    /**
    * GUI display to track volume changes for current and replacement tracks
    */
    void OnGUI(){
        GUI.Label(new Rect(10, 10, 200, 100), "Audio 1: " + current_track_vol.ToString());
        GUI.Label(new Rect(10, 30, 200, 100), "Audio 2: " + replace_track_vol.ToString());
    }
    
    
    /**
    * Fades the track out
    */
    void fadeOut(){
        if(current_track_vol > 0.1f){
            current_track_vol -= 0.1f * Time.deltaTime;
            GetComponent<AudioSource>().volume = current_track_vol;
        }
    }
    
    /**
    * Fades the track in
    */
    void fadeIn(){
        if(replace_track_vol < 1.0f){
            replace_track_vol += 0.1f * Time.deltaTime;
            GetComponent<AudioSource>().volume = replace_track_vol;
        }
    }
    
    

}
   
   
