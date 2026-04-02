using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class resourceManager : MonoBehaviour
{

    public TextMeshProUGUI cheeseText; 
    public TextMeshProUGUI RubbleText;
    public float totalClicks;
    public float clicksPerSec;
    public float minCheeseClicks_1;
    public float minCheeseClicks_2;
    bool hasCheeseUpgrade;
    bool hasRubbleUpgrade;

    Dictionary<string, float> currency = new Dictionary<string, float>()
    {
        {"Cheese Bits", 0 },
        {"Rubble", 0 },
        {"Science", 0 }

    };

    

    public void AddCheese()
    {
        currency["Cheese Bits"]++;

        cheeseText.SetText("Cheese Bits: {0}", currency["Cheese Bits"]);
    }

    public void AutoCheese()
    {
        if(!hasCheeseUpgrade && currency["Cheese Bits"] >=minCheeseClicks_1)
        {
            currency["Cheese Bits"] -= minCheeseClicks_1;
            hasCheeseUpgrade = true;
        }
    }

    /*public void AddRubble()
    {
        currency["Rubble"]++;

        RubbleText.SetText("Rubble: {0}", currency["Rubble"]);
    }*/

    public void AutoRubble()
    {
        if (!hasRubbleUpgrade && currency["Cheese Bits"] >= minCheeseClicks_2)
        {
            currency["Cheese Bits"] -= minCheeseClicks_2;
            hasRubbleUpgrade = true;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(hasCheeseUpgrade)
        {
            currency["Cheese Bits"] += clicksPerSec * Time.deltaTime;

            cheeseText.SetText("Cheese Bits: {0:0}", currency["Cheese Bits"]);
        }

        if (hasRubbleUpgrade)
        {
            currency["Rubble"] += clicksPerSec * Time.deltaTime;

            RubbleText.SetText("Rubble: {0:0}", currency["Rubble"]);
        }
    }

}
