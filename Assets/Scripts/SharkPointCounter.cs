using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SharkPointCounter : MonoBehaviour
{

    public int winCount;
    public Text UI;
    public Slider fillBelly;
    public SceneChange s;

    private int pointCoint;

    private int ateWrong;

    // Start is called before the first frame update
    void Start()
    {
        ateWrong = pointCoint = 0;
        fillBelly.maxValue = winCount;
        UpdateUI();
    }

    public void DetermineFishQuality(bool isGood, bool isSpecial)
    {
        if (isGood)
        {
            IncreaseCount(isSpecial);
        }
        else
        {
            DecreaseCount();
        }

        UpdateUI();
    }

    private void IncreaseCount(bool isSpecial)
    {
        if (isSpecial)
        {
            pointCoint = Mathf.Min(pointCoint + 1, winCount);
        }

        pointCoint = Mathf.Min(pointCoint + 1, winCount);

        // Game won
        if (pointCoint >= winCount)
        {
            GeneralProperties.propertiesInstance.SetResults(true, s);
        }
    }

    private void DecreaseCount()
    {
        pointCoint--;
        ateWrong++;

        // Game Over
        if (pointCoint < 0 || ateWrong >= 3)
        {
            GeneralProperties.propertiesInstance.SetResults(false, s);
        }
    }

    private void UpdateUI()
    {
        UI.text = "       " + pointCoint + "/" + winCount;
        fillBelly.value = pointCoint;
    }

}
