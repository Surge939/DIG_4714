using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DND5eCalc : MonoBehaviour
{
    public string characterName;
    public string characterClass;
    public int playerLevel;
    public int conScore;
    public string characterRace;
    public string toughStoutFeat;
    public string averagedOrRolled;

    // Start is called before the first frame update
    void Start()
    {
        LowerCaseAll();

        int health = 0;
        
        //Dictionary compiles each class's hit die and corresponds them
        // to the correct class
        Dictionary<string,int>classHitDie= new Dictionary<string,int>()
        {
            {"artificer", 8},
            {"barbarian", 12 },
            {"bard", 8 },
            {"cleric", 8 },
            {"druid", 8 },
            {"fighter", 10 },
            {"monk", 8 },
            {"ranger", 10 },
            {"rogue", 8 },
            {"paladin", 10 },
            {"sorcerer", 6 },
            {"wizard", 6 },
            {"warlock", 8 }

        };

        int modifier =ConModifier(conScore);

        switch(averagedOrRolled)
        {
            case "averaged":
                health=HP_AverageCalculation(classHitDie, health,modifier);
                break;
            case "rolled":
                health=HP_RolledCalculation(classHitDie, health, modifier);
                break;
            default:
                Debug.Log("Invalid input. Please type either 'averaged' or 'rolled'.");
                break;
        }

        print("Your character's health is " + health);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //This funciton calculates HP if the user wants their hit die to be 
    // rolled, it will also take into account if the user's 
    //character is a dwarf, orc, or goliath and if they have the
    // tough or stout feats. It returns the calculated HP at the end
    int HP_RolledCalculation(Dictionary<string,int>dictionaryName, int hp, int modifier)
    {
        for (int i = 0; i < playerLevel; i++)
        {
            //accounts for how player hp is calculated at lvl 1
            if (i == 0)
            {
                hp = dictionaryName[characterClass] + modifier;

                if (characterRace == "dwarf")
                    hp += 2;
                if (characterRace == "orc" || characterRace == "goliath")
                    hp += 1;
                if (toughStoutFeat == "tough")
                    hp += 2;
                if (toughStoutFeat == "stout")
                    hp += 1;
                continue;
            }

            //Random.Range() is used to generate a random number within
            //the range of the hit die
            hp += Random.Range(1, dictionaryName[characterClass]) + modifier;

            if (characterRace == "dwarf")
                hp += 2;
            if (characterRace == "orc" || characterRace == "goliath")
                hp += 1;
            if (toughStoutFeat == "tough")
                hp += 2;
            if (toughStoutFeat == "stout")
                hp += 1;

        }
        return hp;
    }

    //This funciton calculates HP if the user wants their hit die to be 
    // averaged, it will also take into account if the user's 
    //character is a dwarf, orc, or goliath and if they have the
    // tough or stout feats. It returns the calculated HP at the end
    int HP_AverageCalculation(Dictionary<string, int> dictionaryName, int hp, int modifier)
    {
        int average = 0;
        //calculates the average of the given hit die
        for (int j = 1; j <= dictionaryName[characterClass]; j++)
        {
            average += j;
        }
        average= (average / dictionaryName[characterClass]);

        for (int i =0; i<playerLevel;i++)
        {
            //accounts for how player hp is calculated at lvl 1
            if (i==0)
            {
                hp = dictionaryName[characterClass] + modifier;

                if (characterRace == "dwarf")
                    hp += 2;
                if (characterRace == "orc" || characterRace == "goliath")
                    hp += 1;
                if (toughStoutFeat == "tough")
                    hp += 2;
                if (toughStoutFeat == "stout")
                    hp += 1;

                continue;
            }

            hp += average+ modifier;

            if (characterRace == "dwarf")
                hp += 2;
            if (characterRace == "orc" || characterRace == "goliath")
                hp += 1;
            if (toughStoutFeat == "tough")
                hp += 2;
            if (toughStoutFeat == "stout")
                hp += 1;

        }
        return hp;
    }

    //Turns given Con stat into its corresponding modifier
    //returns modifier
    int ConModifier(int score)
    {
        if (score == 1) return -5 ;
        if (score > 1 && score <= 3) return -4;
        if (score > 3 && score <= 5) return -3;
        if (score > 5 && score <= 7) return -2;
        if (score > 7 && score <= 9) return -1;
        if (score > 9 && score <= 11) return 0;
        if (score > 11 && score <= 13) return 1;
        if (score > 13 && score <= 15) return 2;
        if (score > 15 && score <= 17) return 3;
        if (score > 17 && score <= 19) return 4;
        if (score > 19 && score<=21) return 5;
        if (score >21 && score <= 23) return 6;
        if (score > 23 && score <= 25) return 7;
        if (score > 25 && score <= 27) return 8;
        if (score > 27 && score <= 29) return 9;
        if (score == 30) return 10;

        Debug.Log("Invalid input, will return 0 and funciton improperly");
        
        return 0;
    }

    //unifies all inputs and keeps them all at lower case to 
    // account for user quirks
    void LowerCaseAll()
    {
        characterName=characterName.ToLower();
        characterClass= characterClass.ToLower();
        characterRace = characterRace.ToLower();
        toughStoutFeat = toughStoutFeat.ToLower();
        averagedOrRolled= averagedOrRolled.ToLower();
        Debug.Log("I lowered them all/ran sucessfully");

    }

}
