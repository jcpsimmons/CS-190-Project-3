using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YouWinTrigger : MonoBehaviour
{

    public BeaconController goalBeacon;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            goalBeacon.PlayWinTrack();
            this.gameObject.SetActive(false);
        }
    }
}

    
