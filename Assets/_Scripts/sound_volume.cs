public AudioClip sound;


void OnTriggerEnter(){
    audio.clip = sound;
    audio.PlayDelayed(0.47f);
}

void SoundVolume(Collider zone){
    GameObject rooster = GameObject.Find("Rooster");
    public Vector3 center = zone.center;
    public float distance = Distance(rooster.transform.position, center);
    switch(distance){
        case distance <= 0.3f:
            audio.volume = 1.0f;
            break;
        case distance <= 0.6f:
            audio.volume = 0.75f;
            break;
        case distance <= 0.9f:
            audio.volume = 0.5f;
            break;
        case distance <= 1.2f:
            audio.volume = 0.25f;
            break;
        default:
            audio.volume = 0.1f;
            break;
    }
}

void OnTriggerExit(){
    audio.stop();
}
    
 
  