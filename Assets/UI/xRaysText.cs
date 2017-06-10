using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class xRaysText : MonoBehaviour {

    private PlayerMovement player;
    private Text textComp;

	void Awake () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        textComp = this.GetComponent<Text>();
	}
	
	void Update () {
        textComp.text = string.Format("X-Rays: {0}", player.limit);
	}
}
