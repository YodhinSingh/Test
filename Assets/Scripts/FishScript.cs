using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishScript : MonoBehaviour
{
    private bool isGoodForShark;
    private bool isAlive = true;
    private float speed = 1;
    private bool comingFromLeft;
    private bool isSpecial;

    Rigidbody2D rb;

    // Screen properties
    private float screenL, screenR;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        screenR = GeneralProperties.propertiesInstance.GetScreenBoundary().x;
        screenL = -screenR;
    }

    private void Update()
    {
        rb.velocity = new Vector2(speed, 0);
        CheckBounds();
    }


    // have fish disappear if they went too far left or right
    private void CheckBounds()
    {
        
        if (rb.position.x > screenR && comingFromLeft)
        {
            FishGone();
        }

        else if (rb.position.x < screenL && !comingFromLeft)
        {
            FishGone();
        }
    }


    public void AssignProperties(Sprite icon, bool isGoodForShark, bool comingFromLeft, bool isSpecial)
    {
        GetComponent<SpriteRenderer>().sprite = icon;
        this.isGoodForShark = isGoodForShark;
        this.comingFromLeft = comingFromLeft;
        if (comingFromLeft)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            speed *= -1;
        }
        this.isSpecial = isSpecial;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && isAlive)
        {
            collision.GetComponent<SharkPointCounter>().DetermineFishQuality(isGoodForShark, isSpecial);
            FishGone();
        }
    }

    private void FishGone()
    {
        isAlive = false;
        Destroy(gameObject, 0.1f);
    }

}
