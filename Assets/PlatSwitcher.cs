using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlatSwitcher : MonoBehaviour
{
    public Light2D dayNight;
    public SpriteRenderer sprite;
    public BoxCollider2D collide;
    bool platformVisible;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dayNight = FindFirstObjectByType<Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!tag.Equals(dayNight.tag) && sprite.enabled)
        {
            Invoke("hideObject", 0.5f);
        }
        else if(tag.Equals(dayNight.tag) && !sprite.enabled)
        {
            sprite.enabled = true;
            collide.enabled = true;
        }
    }

    void hideObject()
    {
        sprite.enabled = false;
        collide.enabled = false;
    }
}
