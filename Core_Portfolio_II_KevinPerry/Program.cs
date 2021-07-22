using System;

namespace Core_Portfolio_II_KevinPerry
{
    class Program
    {
        static void Main(string[] args)
        {
            //NAME: Kevin Perry 
            //DATE: July 08/2021
            //PURPOSE: To code a program which creates an invoice for a bicycle sale and error proof the input and not allow the program to crash.
            //Declare Variables
            string userName = "";
            string brandName = "";
            double tireSizeCost = 0;
            double userDonationAmount = 0;
            double compositePrice = 0;
            int menuChoice = 0;

            do
            {//Do while statement that keeps the user inside switch until they enter 8. 8 to exit.
                switch (getMenuChoice())
                {//Switch case user choice to call method of selection
                    case 1:
                        userName = enterName();
                        break;
                    case 2:
                        brandName = chooseBrand();
                        break;
                    case 3:
                        tireSizeCost = getTireCost();
                        break;
                    case 4:
                        compositePrice = chooseCompositeValue();
                        break;
                    case 5:
                        userDonationAmount = getDonation();
                        break;
                    case 6:
                        displayInvoice(userName, brandName, tireSizeCost, compositePrice, userDonationAmount);
                        Console.WriteLine("Press any key to continue.. \n");
                        Console.ReadKey(true); //allows the user to enter a key with out it printing to screen
                        break;
                    case 7:
                        userName = "";
                        brandName = "";
                        tireSizeCost = 0;
                        compositePrice = 0;
                        userDonationAmount = 0;
                        Console.WriteLine("All Cleared");
                        break;
                    case 8:
                        menuChoice = 8;
                        break;
                    default:
                        break;
                }//eoSwitchCaseMethodSelection

            } while (menuChoice != 8);//eoDoWhileNotEqualTo8
        }//eoMain

        //Enter name method. When called the user can enter name. No error checking because nowadays peoples names are anything
        static public string enterName()
        {
            Console.Write("\nEnter your name >> ");
            string name = Console.ReadLine();
            return name;
        }//eoEnterNameMethod

        //Get tire cost method. When called the user can enter tire size. With error checking. 
        static public double getTireCost()
        {
            //Get safe int used to ensure only a int is entered. No letters or character  or decimals allowed
            int tireSize = getSafeInt("Choose a tire size [20-26] @ 17.50 per inch >> ");
            //While tire size used to display error message if tire size greater than 26 and less than 20
            while (tireSize > 26 || tireSize < 20)
            {
                Console.WriteLine("\n**** Invalid input... try again *******\n");
                tireSize = getSafeInt("Choose a tire size [20-26] @ 17.50 per inch >> ");
            }//eoWhile

            //If the tire size is true then the error is bypassed and the tire size is multiplied by 17.50
            return tireSize * 17.50;
        }//eoGetTireCost

        //Get donation method. When called it will ask for donation amount
        static public double getDonation()
        {
            //Get safe double used to ensure the input of a double is entered. No letters or character allowed
            double donation = getSafeDouble("Please enter the amount >> ");
            //While is used to ensure that no negative number can be entered. If a neg numbered is entered the error message is displayed with another chance to enter correct info
            while (donation < 0)
            {
                Console.WriteLine("\n**** Invalid input... try again ****\n");
                donation = getSafeDouble("Please enter the amount >> ");
            }//eoWhile
            
            //returns value to where its called from
            return donation;
        }//eoGetDonationMethod

        //Choose brand method.When called it will display menu and ask for selection. Get safe char used
        static public string chooseBrand()
        {

            //Declare variables
            string brandName = "";
            char bikeChoice;

            //Brand Menu to display choices to user. Get safe char used to ensure only a letter is entered. No numbers or strings allowed
            Console.WriteLine("Brand");
            Console.WriteLine("       a) Trek");
            Console.WriteLine("       b) Giant");
            Console.WriteLine("       c) Specialized");
            Console.WriteLine("       d) Raleigh\n");
            bikeChoice = getSafeChar("Make a selection [a,b,c,d] >> ");

            //While is used to check for a,b,c,d. If not equal to one of the 4 letters it will display the error and ask the question again. 
            while (bikeChoice != 'a' && bikeChoice != 'b' && bikeChoice != 'c' && bikeChoice != 'd')
            {
                Console.WriteLine("\n*** Invalid input... try again *****\n");
                bikeChoice = getSafeChar("Make a selection [a,b,c,d] >> ");
            }//eoWhile

            // Switch case to allow the user a choice of a-d and then sore the corresponding information i the variable. 
            switch (bikeChoice)
            {
                case 'a':
                    brandName = "Trek";
                    break;
                case 'b':
                    brandName = "Giant";
                    break;
                case 'c':
                    brandName = "Specialized";
                    break;
                case 'd':
                    brandName = "Raleigh";
                    break;
            }//eoSwitch

            //Returns the stored brand name
            return brandName;
        }//eoChooseBrand

        //Get menu choice displays options to user
        static public int getMenuChoice()
        {
            //declare variables
            int menuChoice = 0;

            //Title
            Console.WriteLine("\n\n     The Right Speed Bike Shop");
            Console.WriteLine("     *************************\n");
            //Menu
            Console.WriteLine("        1) Enter Name");
            Console.WriteLine("        2) Enter Brand");
            Console.WriteLine("        3) Select Tire Size");
            Console.WriteLine("        4) Select Metal Composite");
            Console.WriteLine("        5) Add Donation");
            Console.WriteLine("        6) Display Invoice");
            Console.WriteLine("        7) Clear");
            Console.WriteLine("        8) Exit\n");
            //Get safe int used to ensure only a int is entered. No letters or character or decimals allowed
            menuChoice = getSafeInt("Make a selection [1-8] >> ");
            //While used to check for greater than 8 less than 1. If it is the error is displayed as well as another chance to enter the correct information
            while (menuChoice > 8 || menuChoice < 1)
            {
                Console.WriteLine("\n****** Invalid input... try again *******\n");
                menuChoice = getSafeInt("Make a selection [1-8] >>");
            }//eoWhile

            //Returns value in variable to where method was called
            return menuChoice;
        }//eoMenuChoiceMethod

        //Get safe int ensures only a valid int is entered. No letters, decimals or words
        static public int getSafeInt(string prompt)
        {
            //Declare variables
            int input = 0;
            //Bool is for the loop
            bool isValid = false;
            //Do while is to run loop if data is false. 
            do
            {
                try
                {//Try is parsing the input. If it parses the isvalid is true and it returns the value to where method is called
                    Console.Write(prompt);
                    input = int.Parse(Console.ReadLine());
                    isValid = true;
                }//eoTry
                //Catch is if isValid is false. It will display exception message and run the method again
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    isValid = false;
                }//eoCatch
            }//eoWhile
            while (isValid == false);
            //Returns input variable to where method was called
            return input;
        }//eoGetSafeInt

        //Get safe char method. Ensures only a valid char is returned where called. No numbers or words.
        static char getSafeChar(string prompt)
        {
            //Declare variables
            char input = 'a';
            //Bool is for the loop
            bool isValid = false;
            //Do while is to run loop if data is false.
            do
            {
                try
                {//Try is parsing the input. If it parses the isvalid is true and it returns the value to where method is called
                    Console.Write(prompt);
                    input = char.Parse(Console.ReadLine());
                    isValid = true;
                }//eoTry
                //Catch is if isValid is false. It will display exception message and run the method again
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    isValid = false;
                }//eoCatch
            }//eoWhile
            while (isValid == false);
            //Returns input variable to where method was called
            return input;
        }//eoGetSafeChar

        static public double getSafeDouble(string prompt)
        {
            //Declare variables
            double input = 0;
            //Bool is for the loop
            bool isValid = false;
            //Do while is to run loop if data is false.
            do
            {
                try
                {//Try is parsing the input. If it parses the isvalid is true and it returns the value to where method is called

                    Console.Write(prompt);
                    input = double.Parse(Console.ReadLine());
                    isValid = true;
                }//eoTry
                //Catch is if isValid is false. It will display exception message and run the method again
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    isValid = false;
                }//eoCatch
            }//eoWhile
            while (isValid == false);
            //Returns input variable to where method was called
            return input;
        }//eoGetSafeDouble

        //Choose composite value method displays menu and takes in user choice
        static public double chooseCompositeValue()
        {
            //Declare variables 
            int userInputMetalSelection;
            double tempMetalSelection = 0;
            const double STEEL = 0.00, ALUMINUM = 175.00, TITANIUM = 425.00, CARBONFIBER = 615.00;

            //User menu to select metal alloy choice
            Console.Write("Enter the number of your corresponding choice of metal. ");
            Console.Write("\n       1. Steel [$0]");
            Console.Write("\n       2. Aluminum [$175]");
            Console.Write("\n       3. Titanium [$425]");
            Console.Write("\n       4. Carbon Fiber [$615]\n");
            userInputMetalSelection = getSafeInt("Choice [1-4} >> ");
            //While to ensure user choice is between 1 and 4. If it is not it will display error and offer selection again
            while (userInputMetalSelection < 1 || userInputMetalSelection > 4)
            {
                Console.WriteLine("\n*** Invalid input... try again *****\n");
                userInputMetalSelection = getSafeInt("Choice [1-4} >> ");
            }//eoWhile

            // If is to allow the user a choice of 1-4 and stores the appropriate value in corresponding variables
            if(userInputMetalSelection ==1)
            { 
                tempMetalSelection = STEEL;
            }
            else if (userInputMetalSelection == 2)
            {
                tempMetalSelection = ALUMINUM;
            }
            else if (userInputMetalSelection == 3)
            {
                tempMetalSelection = TITANIUM;
            }
            else if (userInputMetalSelection == 4)
            {
                tempMetalSelection = CARBONFIBER;
            }
            //Returns input variable to where method was called
            return tempMetalSelection;
        }//eoIf

        //Display invoice method. Displays invoice with all the user input and calculations back to the user
        static public void displayInvoice(string userName, string brandName, double tireSizeCost, double compositePrice, double userDonationAmount)
        {
            const double BASEPRICE = 500.00, GST = 0.05;
            double subTotal, gst, total;
            //Display to user of the invoice with all of their selections and calculated balance total.
            Console.WriteLine("\n\n         The Right Speed Bike Shop");
            Console.WriteLine("      *******************************");
            Console.WriteLine("         Invoice and Packing Slip");
            Console.WriteLine("\n{0,-20} {1,7}", "  Customer: ", userName);
            Console.WriteLine("{0,-20} {1,7}", "  Brand: ", brandName);
            Console.WriteLine("{0,-20}{1,22:0.00}", "  Base Price: ", BASEPRICE);
            Console.WriteLine("{0,-20}{1,21:0.00}", "  Tire Size Premium: ", tireSizeCost);
            Console.WriteLine("{0,-25}{1,15:0.00}", "  Metal Selection Premium: ", compositePrice);
            Console.WriteLine("{0,42}", "---------");
            subTotal = BASEPRICE + tireSizeCost + compositePrice;
            Console.WriteLine("{0,-20}{1,22:0.00}", "  Sub Total: ", subTotal);
            gst = subTotal * GST;
            Console.WriteLine("{0,-20}{1,22}", "  GST: ", gst);
            Console.WriteLine("{0,42}", "=========");
            Console.WriteLine("{0,-25}{1,16:0.00}", "  Donation to Green Earth ", userDonationAmount);
            total = subTotal + gst + userDonationAmount;
            Console.WriteLine("{0,-20}{1,22:0.00}", "  Total: ", total);
            Console.WriteLine("**************************************************** \n");  
        }//eoDisplayInvoice
    }//eoc  
}//eon
