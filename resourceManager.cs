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

    public enum ResourceType
    {
        CheeseBits,
        Rubble,
        Science,
    }

    Dictionary<ResourceType, float> currency = new Dictionary<ResourceType, float>()
    {
        {ResourceType.CheeseBits, 0 },
        {ResourceType.Rubble, 0 },
        {ResourceType.Science, 0 }

    };

    

    public void AddCheese()
    {
        currency[ResourceType.CheeseBits]++;

        cheeseText.SetText("Cheese Bits: {0}", currency[ResourceType.CheeseBits]);
    }

    public void AutoCheese()
    {
        if(!hasCheeseUpgrade && currency[ResourceType.CheeseBits] >=minCheeseClicks_1)
        {
            currency[ResourceType.CheeseBits] -= minCheeseClicks_1;
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
        if (!hasRubbleUpgrade && currency[ResourceType.CheeseBits] >= minCheeseClicks_2)
        {
            currency[ResourceType.CheeseBits] -= minCheeseClicks_2;
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
            currency[ResourceType.CheeseBits] += clicksPerSec * Time.deltaTime;

            cheeseText.SetText("Cheese Bits: {0:0}", currency[ResourceType.CheeseBits]);
        }

        if (hasRubbleUpgrade)
        {
            currency[ResourceType.Rubble] += clicksPerSec * Time.deltaTime;

            RubbleText.SetText("Rubble: {0:0}", currency[ResourceType.Rubble]);
        }
    }

}
