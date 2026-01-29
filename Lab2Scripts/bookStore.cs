using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bookStore : MonoBehaviour
{
    // Start is called before the first frame update
    public float price;
    public int bookAmount;
    void Start()
    {
        print("Please enter cost of book and amount within the component");
        BookStore(price, bookAmount);
        print("Thank you");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   //This function take in a float for the retail price of books and
   // an integer for the amount of books being sold/have been ordered
   //it will then calculate the profit and print out the result
   //within the console
    void BookStore(float price, int amount)
    {
        //This variable calculates the amount the book
        //store pays for the books from the distributor
        float discountedPrice = price*(float).40;
        float wholesaleCost= CostCalc(discountedPrice, amount);
        float profit = price * amount - wholesaleCost;

        print("The wholesale cost is "+wholesaleCost+" and the profit is "+profit);

    }

   //This function takes in the retail price of books and the
   //integer amount of books that have been sold/ordered
   //The function will then calculate the shipping costs
   //that the book store pays when ordering books
    float CostCalc(float price, int amount)
    {
        float cost=price;
        
        for(int i=0; i<amount; i++)
        {
            //The book store is charged 3 dollars upon the first book
            //ordered and charge 75 cents for the subsequent books
            if(i==0)
            {
                cost += 3;
                continue;
            }
            cost += (float).75;
        }
        //returns cost of books after shipping costs
        return cost;
    }
}
