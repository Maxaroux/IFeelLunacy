using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ColorPicker : MonoBehaviour
{
    public string CurrentColor = "Green";
    public Button colorButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CurrentColor = "Green";
        Button btn = colorButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }
    void TaskOnClick()
    {
        if (CurrentColor == "Green")
        {
            CurrentColor = "Blue";
        }
        else if(CurrentColor == "Blue")
        {
            CurrentColor = "Yellow";
        }
        else if(CurrentColor == "Yellow")
        {
            CurrentColor = "Gray";
        }
        else if(CurrentColor == "Gray")
        {
            CurrentColor = "Green";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
