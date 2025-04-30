using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class ThirdQuarterSelectionScript : MonoBehaviour
{
    public Light2D light2D;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        light2D = GameObject.Find("Player").GetComponentInChildren<Light2D>();
        light2D.tag = "Day";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene("PreDashThirdQuarter", LoadSceneMode.Single);
        light2D.tag = "Day";
    }
}
