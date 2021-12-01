using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishGenerator : MonoBehaviour
{
    public Sprite[] icons;

    public GameObject FishPrefab;

    private bool isOnLeftSide;

    // Start is called before the first frame update
    void Start()
    {
        isOnLeftSide = transform.position.x < 0;
        int rand = Random.Range(3, 6);
        InvokeRepeating("SummonFish", rand, rand);
    }


    private void SummonFish()
    {
        int rand = Random.Range(0, icons.Length);

        GameObject Fish = Instantiate(FishPrefab, transform.position, Quaternion.identity);

        bool isFishGoodForShark;

        if (rand < 6 || rand > 9)
        {
            isFishGoodForShark = true;
        }
        else
        {
            isFishGoodForShark = false;
        }

        Fish.GetComponent<FishScript>().AssignProperties(icons[rand], isFishGoodForShark, isOnLeftSide, rand > 9);
    }
}
