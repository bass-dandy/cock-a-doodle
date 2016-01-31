public class Fading extends MonoBehavior{


    public AudioClip current_track;
    public AudioClip replace_track;
  
    audio.clip = current_track;
    audio.play()
            
   
    public float current_track_vol = 1.0f;
    public float replace_track_vol = 0.0f;
    public replace_track_vol = 0.0f;
    private bool replace_playing = false;
    
    
      
    /**
    * Update consistently where you change the track depending on your location
    * Ex. enter dog region, dog instrument fades in and main instrument fades out
    * trigger a loop. My idea is to have an OnTriggerEnter for each location
    * with the Update and other functions being there overall
    */
         
    void OnTriggerEnter ( Collider zone){
        switch(zone.tag){
            case 'cow':
                Debug.log("entered the cowzone")
                replace_track : AudioClip;
                break;
            case 'hen':
                Debug.log("entered the henzone")
                replace_track : AudioClip;
                break;
            case 'sheep':
                Debug.log("entered the sheepzone")
                replace_track : AudioClip;
                break;
            case 'duck':
                Debug.log("entered the duckzone")
                replace_track : AudioClip;
                break;
            case 'horses':
                Debug.log("entered the horsezone")
                replace_track : AudioClip;
                break;
            case 'dog':
                Debug.log("entered the dogzone")
                replace_track : AudioClip;
                break;
            case 'pig':
                Debug.log("entered the pigzone")
                replace_track : AudioClip
                break;
            case 'cat':
                Debug.log("entered the catzone")
                replace_track : AudioClip
                break;
            default:
                Debug.log("entered the defaultzone")
                replace_track : AudioClip
                break;
            
        }
        replace_playing = false;
        current_track_vol = audio.volume;
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
                audio.clip = replace_track;
                audio.Play();
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
            audio.volume = current_track_vol;
        }
    }
    
    /**
    * Fades the track in
    */
    void fadeIn(){
        if(replace_track_vol < 1.0f){
            replace_track_vol += 0.1f * Time.deltaTime;
            audio.volume = replace_track_vol;
        }
    }
    
    

}
   
   