using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeaconController : MonoBehaviour
{
    public List<PathCell> pathCellList;
    public ParticleSystem fireworks;

    void Awake()
    {
        for (int i = 0; i < pathCellList.Count; i++)
        {
            pathCellList[i].rtpcPercentage = (i/(float)pathCellList.Count)*100;
        }
    }
    
    public void PlayWinTrack()
    {
        AkSoundEngine.PostEvent("YouWin", this.gameObject);
        StartCoroutine(StopMainTrack());
    }

    IEnumerator StopMainTrack()
    {
        yield return new WaitForSeconds(4f);
        ToggleFireworks(true);
        yield return new WaitForSeconds(0.6f);
        AkSoundEngine.PostEvent("Stop_Beacon", this.gameObject);
    }

    public void ToggleFireworks(bool active)
    {
        if (active)
        {
            fireworks.Play();
        }
        else
        {
            fireworks.Stop();
        }
    }
}