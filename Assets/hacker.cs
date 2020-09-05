using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hacker : MonoBehaviour
{
    string[] level1passwords = { "books", "aisle", "shelf", "password", "font", "borrow" };
    string[] level2passwords = { "prisoner", "handcuffs", "holster", "uniform", "arrest" };
    int level;
    enum screen { mainmenu,password,win};
    screen currentscreen;
    string password;
    
    void Start()
    {
       
        ShowMainMenu();
        

    }
    
   void ShowMainMenu()
    {
        currentscreen = screen.mainmenu;
        Terminal.ClearScreen();
        
        
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("Press 1 for the local library");
        Terminal.WriteLine("Press 2 for the local police station");
        Terminal.WriteLine("you can type menu to return back to the main menu at any point in the game");
        Terminal.WriteLine("Enter your selection:");
    }
    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            ShowMainMenu();
        }
        else if (currentscreen == screen.mainmenu)
            NewMethod(input);
        else if (currentscreen == screen.password)
            checkpassword(input);

    }

    private void NewMethod(string input)
    {
        bool isvalidnumber = (input == "1" || input == "2");
        if(isvalidnumber)
        {
            level = int.Parse(input);
            askforpassword();
        }
       
        else if (input == "007")
        {
            Terminal.WriteLine("Please select a level Mr. Bond");
        }
        else
            Terminal.WriteLine("Please choose a valid level");
    }

    void Update()
    {
        
    }
    void askforpassword()
    {
        currentscreen = screen.password;
        Terminal.ClearScreen();
        setrandompassword();
        Terminal.WriteLine("enter your password, hint:" + password.Anagram());
    }

     void setrandompassword()
    {
        switch (level)
        {

            case 1:

                password = level1passwords[Random.Range(0, level1passwords.Length)];
                break;
            case 2:

                password = level2passwords[Random.Range(0, level2passwords.Length)];
                break;
            default:
                Debug.LogError("invalid number");
                break;

        }
    }

    void checkpassword(string input)
    {
        if (input == password)
        {
            displaywinscreen();
        }
        else
            askforpassword();
    }

     void displaywinscreen()
    {
        currentscreen = screen.win;
        Terminal.ClearScreen();
        showlevelreward();
    }

     void showlevelreward()
    {
        switch(level)
        {
            case 1:
                
                Terminal.WriteLine(@"have a book....
     ________
    /        / /
   /        / /
  /        / /
 /________/ /       
(________( /       
         


                ");
                break;
            case 2:
                Terminal.WriteLine(@"have a very bad diagram of a prison key
   _____
  /     \__________________
 |       ______   _   _    |
  \_____/      | | |_| |   |
               |_|     |   |
                       |___|  


                    ");
                    break;

        }
        
    }
}
