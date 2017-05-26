using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffErrorTrigger : MonoBehaviour {

    public ErrorBeacon errorBeacon;

    private void OnTriggerEnter(Collider other)
    {
        errorBeacon.StopErrorSound();
    }
}
