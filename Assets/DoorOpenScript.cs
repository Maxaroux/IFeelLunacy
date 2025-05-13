using System;
using UnityEditor;
using UnityEngine;

public class DoorOpenScript : MonoBehaviour
{
    public GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(player.GetComponent<gameConstants>().hasDoubleJump && name.Equals("ThirdQuarterDoor") || name.Equals("PreDashDoor"))
        {
            Destroy(GameObject.Find(this.name));
        }
    }
}
