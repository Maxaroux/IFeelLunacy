using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class PlatformEntranceScript : MonoBehaviour
{

    public GameObject Player;
    public Light2D light2D;
    void Start()
    {
        Player = GameObject.Find("Player");
        light2D = Player.GetComponentInChildren<Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player.tag = "Top-Down";
        light2D.tag = "Day";
        if(SceneManager.GetActiveScene().name.Equals("NewMoon"))
        {
            Player.GetComponent<Rigidbody2D>().position = new Vector2(0,-4.5f);
            //SceneManager.LoadScene("WaxingCrescent");
        }
        else if(SceneManager.GetActiveScene().name.Equals("FullMoon"))
        {
            Player.tag = "Top-Down";
            Player.GetComponent<Rigidbody2D>().position = new Vector2(9, 0);
            SceneManager.LoadSceneAsync("WaxingGibbous", LoadSceneMode.Single);
        }   
        light2D.tag = "Day";
    }
}
