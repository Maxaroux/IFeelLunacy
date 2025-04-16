using UnityEngine;
using UnityEngine.Rendering.Universal;

public class DayNightScript : MonoBehaviour
{
    public Light2D l;
    public GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(tag.Equals("Day"))
            l.intensity = 1;
        else
            l.intensity = 0.1f;
    }
}
