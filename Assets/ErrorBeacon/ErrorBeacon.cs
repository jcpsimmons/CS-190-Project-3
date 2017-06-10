using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErrorBeacon : MonoBehaviour {

    public Transform startTrigger;
    bool isPlaying = false;
    float maxDistance;
    Transform player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Start()
    {
        maxDistance = Vector3.Distance(this.transform.position, startTrigger.position);
    }

    private void Update()
    {
        if (isPlaying)
        {
            float rtpcPercentage = Mathf.Lerp(0, 100, (maxDistance - PlayerDistance()) / maxDistance);
            AkSoundEngine.SetRTPCValue("ErrorBeaconDistance", rtpcPercentage);
        }
    }

    float PlayerDistance()
    {
        return Vector3.Distance(this.transform.position, player.position);
    }

    public void StartErrorSound()
    {
        isPlaying = true;
        AkSoundEngine.PostEvent("Play_ErrorBeacon", this.gameObject);
    }

    public void StopErrorSound()
    {
        isPlaying = false;
        AkSoundEngine.PostEvent("Stop_ErrorBeacon", this.gameObject);
    }
}
