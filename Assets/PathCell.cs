using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathCell : MonoBehaviour
{
    public float rtpcPercentage;

    void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.CompareTag("Player"))
        {
            AkSoundEngine.SetRTPCValue("FinishLineProximity", rtpcPercentage);
        }
    }
}