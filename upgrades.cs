using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upgrades : MonoBehaviour
{

    private string upgradeName;
    private int upgradeCost;
    public int upgradeType;
    resourceManager.ResourceType resource;

    public upgrades(string name, int cost, resourceManager.ResourceType resource)
    {
        upgradeName = name;
        upgradeCost = cost;
        this.resource = resource; 
    }

    public enum upgradeState
    {
        Locked,
        Available,
        Purchased,
    }
    
  

   

    // Update is called once per frame
    void Update()
    {
        
    }
}
