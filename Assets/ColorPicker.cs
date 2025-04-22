using UnityEngine;

public class ColorPicker : MonoBehaviour
{
    public string CurrentColor = "hell";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tag = "Triangle/Green";
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void changeColor()
    {
        if(tag == "Triangle/Green")
        {
            tag = "Crescent/Blue";
        }
        else if (tag == "Crescent/Blue")
        {
            tag = "Star/Yellow";
        }
        else if (tag == "Star/Yellow")
        {
            tag = "YinYang";
        }
        else if (tag == "YingYang")
        {
            tag = "Triangle/Green";
        }
    }
}
