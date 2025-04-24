 using UnityEngine;
 using UnityEngine.UI;
 using System.Collections;
 using UnityEditor;

public class CrescentPathScript : MonoBehaviour
{
    public string correctColor;
    public string currentColor;
    public MonoScript balalala;
    public Button crescButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        correctColor = "Blue";
        currentColor = "None";
        Button btn = crescButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        Debug.Log("You have clicked the button!");
        currentColor = GameObject.Find("ColorChanger").GetComponent<ColorPicker>().CurrentColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
