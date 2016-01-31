# play on start up
var myClip : AudioClip

function Start() {

    audio.PlayOneShot(<clip>);
}
                      
                      
                     

function Start() {

    audio.PlayClipAtPoint(myClip, transform.position);
}
                      
      
/** create sound trigger
make empty game object
component physics box collider
audio component, audio source
create script
*/
    var audioClip:AudioClip;
    var variable = false;
    
    
    
    function OnTriggerEnter(o:Collider){
        Debug.log("The trigger fired enter");
        variable = true;
        
        
    }
    
    function OnTriggerExit(o:Collider){
        Debug.Log("The trigger fired");
        
        if(variable){
            playFlush();
            variable = false;
        }
        
    }
    
    #tell collider is trigger
   
    function playFlush(){
        audio.playOneShot(myClip);
    }
    
    var soundClip: AudioClip;
    var trigger = false;
    
    /**
    * Notifies that the region has been entered
    */
    function OnTriggerEnter(o:Collider){
        Debug.log("sound is triggered");
        trigger = true;
    }
    
    /**
    * Notifies that the region has been exited
    */
    function OnTriggerExit
    
    
    # Idea for sounds is to have a huge region with the awake animals. entering the region will cause for the sound to be triggered. As you get near the center, the sound gets louder. Best practice here is a sphere collider
    
    # for music, we should use another collider, where once you enter a certain point, the script will trigger containing a map of area to number. Depending on the area, you trigger a certain instrument to take over the main theme.
    
    
    http://answers.unity3d.com/questions/240257/adjust-audio-playback-rate-with-timetimescale.html
    
    
        
    var current_track : AudioClip;
    var replace_track : AudioClip;
    
    audio.clip = current_track;
    audio.Play();
    
    var current_track_vol : float = 1.0;
    var replace_track_vol : float = 0.0;
    var replace_playing : boolean = false;
    
    
    #trigger what the replacement 
    
    /**
    * Update consistently where you change the track depending on your location
    * Ex. enter dog region, dog instrument fades in and main instrument fades out
    * trigger a loop. My idea is to have an OnTriggerEnter for each location
    * with the Update and other functions being there overall
    */
    
    function OnTriggerEnter ( Collider zone){
        switch(zone.tag){
            case 'cow':
                Debug.log("entered the cowzone")
                replace_track : AudioClip;
            case 'hen':
                Debug.log("entered the henzone")
                replace_track : AudioClip;
            case 'sheep':
                Debug.log("entered the sheepzone")
                replace_track : AudioClip;
            case 'duck':
                Debug.log("entered the duckzone")
                replace_track : AudioClip;
            case 'horses':
                Debug.log("entered the horsezone")
                replace_track : AudioClip;
            case 'dog':
                Debug.log("entered the dogzone")
                replace_track : AudioClip;
            case 'pig':
                Debug.log("entered the pigzone")
                replace_track : AudioClip
            case 'cat':
                Debug.log("entered the catzone")
                replace_track : AudioClip
            default:
                Debug.log("entered the defaultzone")
                replace_track : AudioClip
            
        }
        replace_playing = false;
        current_track_vol = audio.volume;
        replace_track_vol = 0.0;                                  
    }
                                  
                                  
    
                                  
   #TODO: when you hit a trigger zone. make replace_track = track_animal
   # replace_playing = false
   # current_track_vol = audio.volume
   # replace_track_vol = 0.0
                                  
                                  
                                  
    /**
    * Fade in replacement track and fade out other track
    */
                                  
    function Update(){
        fadeOut();
        
        if (current_track_vol <= 0.1) {
            if(replace_playing == false){
                replace_playing = true;
                audio.clip = replace_track;
                audio.Play();
            }
            fadeIn();
        }
    }
    
    function OnGUI(){
        GUI.Label(new Rect(10, 10, 200, 100), "Audio 1: " + current_track_vol.ToString());
        GUI.Label(new Rect(10, 30, 200, 100), "Audio 2: " + replace_track_vol.ToString());
    }
    
    function fadeOut(){
        if(current_track_vol > 0.1){
            current_track_vol -= 0.1 * Time.deltaTime;
            audio.volume = current_track_vol;
        }
    }
    
    function fadeIn(){
        if(replace_track_vol < 1){
            replace_track_vol += 0.1 * Time.deltaTime;
            audio.volume = replace_track_vol;
        }
    }
    