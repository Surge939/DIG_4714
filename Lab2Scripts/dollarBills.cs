using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class dollarBills : MonoBehaviour
{
    // Start is called before the first frame update
    // Start will execute all necessary methods
    public int amount = 0;
    void Start()
    {
        print("Please enter the amount you must be paid: ");
        DollarBills(amount);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //This function take in an integer to determine the amount of money it will
    //divide into certain dollar bill denominations
    void DollarBills(int amount) 
    {
        int hundreds;
        int fifties;
        int twenties;
        int tens;
        int fives;
        int ones;

        
        
        print("You will be paid " + amount + " in the following bills");

       //This while loop keeps the function running so it can
       //continuosly check if more bills need to be given out
        while (amount!=0)
        {
            //This determines whether the user will need bills of the
            //denomination the amount is compared to
            if (amount >= 100)
            {
                for (hundreds = 0; amount >= 100; hundreds++)
                {
                    amount -= 100;

                }
                print(hundreds + " x $100 bills ");
            }
            //This determines whether the user will need bills of the
            //denomination the amount is compared to
            if (amount >= 50)
            {
                for (fifties = 0; amount >= 50; fifties++)
                {
                    amount -= 50;

                }
                print(fifties + " x $50 bills ");
            }
            //This determines whether the user will need bills of the
            //denomination the amount is compared to
            if (amount >= 20)
            {
                for (twenties = 0; amount >= 20; twenties++)
                {
                    amount -= 20;

                }
                print(twenties + " x $20 bills ");
            }
            //This determines whether the user will need bills of the
            //denomination the amount is compared to
            if (amount >= 10)
            {
                for (tens = 0; amount >= 10; tens++)
                {
                    amount -= 10;

                }
                print(tens + " x $10 bills ");
            }
            //This determines whether the user will need bills of the
            //denomination the amount is compared to
            if (amount >= 5)
            {
                for (fives = 0; amount >= 5; fives++)
                {
                    amount -= 5;

                }
                print(fives + " x $5 bills ");
            }
            //This determines whether the user will need bills of the
            //denomination the amount is compared to
            if (amount >= 1)
            {
                for (ones = 0; amount >= 1; ones++)
                {
                    amount -= 1;

                }
                print(ones + " x $1 bills ");
            }
        }

        
        
    }
}
