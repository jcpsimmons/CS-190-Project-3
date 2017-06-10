using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YouWinTrigger : MonoBehaviour
{
    public BeaconController goalBeacon;
    public GameObject gameOverUI;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            goalBeacon.PlayWinTrack();
            this.gameObject.SetActive(false);
            Invoke("EnableGameOverUI", 10f);
        }
    }

    void EnableGameOverUI()
    {
        gameOverUI.SetActive(true);
        Cursor.visible = true;
    }
}

    
