using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransportScript : MonoBehaviour
{

    public GameObject player;

    public void TeleportRoom1(){
        player.transform.position = new Vector3(0, 0, 0);
    }

    public void TeleportRoom2(){
        player.transform.position = new Vector3(-250, 0, 0);
    }
}
