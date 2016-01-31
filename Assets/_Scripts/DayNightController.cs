using UnityEngine;
using System.Collections;

public class DayNightController : MonoBehaviour {
    public Light sun;
    public Light moon;
    public float secondsPerDay = 120f;
    [Range(0, 1)]
    public float currentTime = 0f;
    [HideInInspector]
    public float timeMultiplier = 1f;

    private float sunInitialIntensity;
    private float moonInitialIntensity;

	// Use this for initialization
	void Start () {
        sunInitialIntensity = sun.intensity;
        moonInitialIntensity = sun.intensity;
	}
	
	// Update is called once per frame
	void Update () {
        sun.transform.rotation = Quaternion.Euler((currentTime * 360f) - 90, 180, 0);    // Rotates the sun and moon

        updateIntensity();

        currentTime += (Time.deltaTime / secondsPerDay) * timeMultiplier;                // Updates the currentTime
        currentTime %= 1;
	}

    void updateIntensity () {
        float sunMultiplier = 1f;
        float moonMultiplier = 1f;

        // Night time
        if (timeOfDay() == 0) {
            sunMultiplier = 0;
            moonMultiplier = 1;
        // Sunrise
        } else if (timeOfDay() == 1) {
            sunMultiplier = Mathf.Clamp01((currentTime - 0.23f) * (1 / 0.02f));
            moonMultiplier = Mathf.Clamp01(1 - ((currentTime - 0.23f) * (1 / 0.02f)));
        // Sunset
        } else if (timeOfDay() == 2) {
            sunMultiplier = Mathf.Clamp01(1 - ((currentTime - 0.73f) * (1 / 0.02f)));
            moonMultiplier = Mathf.Clamp01((currentTime - 0.73f) * (1 / 0.02f));
        }

        sun.intensity = sunInitialIntensity * sunMultiplier;
        moon.intensity = moonInitialIntensity * moonMultiplier;
    }

    int timeOfDay() {
        if (currentTime <= 0.23f || currentTime >= 0.75f) {
            return 0;           // Night time
        } else if (currentTime <= 0.25f) {
            return 1;           // Sunrise
        } else if (currentTime >= 0.73f) {
            return 2;           // Sunset
        } else {
            return 3;           // Day time
        }
    }
}
