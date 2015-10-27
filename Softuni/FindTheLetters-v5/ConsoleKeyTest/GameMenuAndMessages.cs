﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace CollectTheLettersTestVersion
{
    class GameMenuAndMessages
    {
        //MENU METHODS

        static void Instructions()
        {
            ClearText();
            printFrame();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition((Console.WindowWidth / 2) - 8, 9);
            Console.WriteLine("| INSTRUCTIONS |");
            Console.SetCursorPosition((Console.WindowWidth / 2) - 26, (Console.WindowHeight / 2) - 6);
            Console.WriteLine("1. Your aim is to collect all the letters on the");
            Console.SetCursorPosition((Console.WindowWidth / 2) - 26, (Console.WindowHeight / 2) - 5);
            Console.WriteLine("board in the order they are shown over the board.");
            Console.SetCursorPosition((Console.WindowWidth / 2) - 26, (Console.WindowHeight / 2) - 3);
            Console.WriteLine("2.Use your [W](up) [A](left) [S](down) [D](right)");
            Console.SetCursorPosition((Console.WindowWidth / 2) - 26, (Console.WindowHeight / 2) - 2);
            Console.WriteLine("keys or arrow keys to navigate the player on the");
            Console.SetCursorPosition((Console.WindowWidth / 2) - 26, (Console.WindowHeight / 2) - 1);
            Console.WriteLine("board up, down, left or right.");
            Console.SetCursorPosition((Console.WindowWidth / 2) - 13, 26);
            Console.WriteLine("PRESS [BACKSPACE] TO BACK");

            //ConsoleKey pressedKey = Console.ReadKey(true).Key;
            //while (pressedKey != ConsoleKey.Backspace) {
            //    pressedKey = Console.ReadKey(true).Key;
            //}
        }
        public static void PrintMainMenu(string[] wholeField) //printing method
        {

            ClearText();
            printingTheTitle();
            Console.SetCursorPosition(0, 13);
            centerText("MENU ");
            Console.SetCursorPosition(0, 15);
            centerText(wholeField[0] + " Play ");
            centerText(wholeField[1] + " Instructions ");
            centerText(wholeField[2] + " High Scores ");
            centerText(wholeField[3] + " Quit ");
            //drawing lines
            printFrame();
        }
        static void PrintSubmenu(string[] wholeField)
        {
            ClearText();
            printingTheTitle();
            printFrame();
            Console.SetCursorPosition(0, 13);
            centerText("Select LEVEL");
            Console.SetCursorPosition(0, 15);
            centerText(wholeField[0] + " Level 1 ");
            centerText(wholeField[1] + " Level 2 ");
            centerText(wholeField[2] + " Level 3 ");
            Console.WriteLine();
            centerText(wholeField[3] + " Back to main menu ");
        }
        public static void printFrame()
        {
            Console.SetCursorPosition((MainClass.width / 2) - 34, 7);
            Console.WriteLine("===================================================================");
            Console.SetCursorPosition((MainClass.width / 2) - 34, (MainClass.height / 2) + 9);
            Console.WriteLine("===================================================================");
        }
        public static void ClearText()
        {
            for (int i = 8; i <= 27; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.WriteLine(new string(' ', Console.WindowWidth));
            }
            for (int i = 28; i < 34; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.WriteLine(new string(' ', Console.WindowWidth));
            }
        }
        public static void ClearFrame()
        {
            Console.SetCursorPosition(0, 7);
            Console.WriteLine(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, (MainClass.height / 2) + 9);
            Console.WriteLine(new string(' ', Console.WindowWidth));
        }
        public static void ClearAction()
        {
            for (int i = 8; i < Console.WindowHeight; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.WriteLine(new string(' ', Console.WindowWidth));
            }
        }
        private static void centerText(String text)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(new string(' ', (Console.WindowWidth - text.Length) / 2));
            Console.WriteLine(text);
            Console.ResetColor();
        }
        public static void printingTheTitle()
        {

            //drawing game name
            Console.ForegroundColor=ConsoleColor.Cyan;
            Console.SetCursorPosition((MainClass.width / 2) - 36, 0);
            Console.Write(@"______ _           _   _   _            _          _   _                 ");
            Console.SetCursorPosition((MainClass.width / 2) - 36, 1);
            Console.Write(@"|  ___(_)         | | | | | |          | |        | | | |                ");
            Console.SetCursorPosition((MainClass.width / 2) - 36, 2);
            Console.Write(@"| |_   _ _ __   __| | | |_| |__   ___  | |     ___| |_| |_ ___ _ __ ___  ");
            Console.SetCursorPosition((MainClass.width / 2) - 36, 3);
            Console.Write(@"|  _| | | '_ \ / _` | | __| '_ \ / _ \ | |    / _ \ __| __/ _ \ '__/ __| ");
            Console.SetCursorPosition((MainClass.width / 2) - 36, 4);
            Console.Write(@"| |   | | | | | (_| | | |_| | | |  __/ | |___|  __/ |_| ||  __/ |  \__ \ ");
            Console.SetCursorPosition((MainClass.width / 2) - 36, 5);
            Console.Write(@"\_|   |_|_| |_|\__,_|  \__|_| |_|\___| \_____/\___|\__|\__\___|_|  |___/ ");
            Console.ResetColor();
        }
        //remove scrollbars of the console
        public static void RemoveScrollBars()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BufferHeight = Console.WindowHeight = 37;
            Console.BufferWidth = Console.WindowWidth = 100;
        }

        public static void ModifyMainMenu(ConsoleKeyInfo keyInfo, string[] field, int index = 0)
        {
            while ((keyInfo = Console.ReadKey(true)).Key != ConsoleKey.Escape)
            {
                switch (keyInfo.Key)
                {
                    case ConsoleKey.Enter:
                        {
                            if (index == 0)
                            {
                                string wholeUncheckedString = new string(MainClass.uncheckedField, 1); //creating the unchecked field /w tabulation
                                string wholeCheckedString = new string(MainClass.checkedField, 1); //creating the checked field /w tabulation
                                string[] wholeField = new[] // init the menu /w 4 fields
                                {wholeUncheckedString, wholeUncheckedString, wholeUncheckedString, wholeUncheckedString};
                                wholeField[0] = wholeCheckedString;
                                ClearText();
                                PrintSubmenu(wholeField);
                                ModifySubmenu(keyInfo, MainClass.subMenuField, 0);
                                return;
                            }
                            if (index == 1)
                            {
                                Instructions();
                                break;
                            }
                            if (index == 2)
                            {
                                Highscore.GetHighScore();
                                break;
                            }
                            if (index == 3)
                            {
                                ClearText();
                                printFrame();
                                Console.SetCursorPosition(0, Console.WindowHeight / 2);
                                centerText("Thank you for playing!\n");
                                Console.SetCursorPosition(Console.WindowWidth / 2 - 16, Console.WindowHeight / 2 + 2);
                                Environment.Exit(0);
                            }
                            break;
                        }
                    case ConsoleKey.UpArrow:
                    case ConsoleKey.W:
                        if (index != 0)
                        {
                            field[index] = new string(MainClass.uncheckedField, 1);
                            index--;
                            field[index] = new string(MainClass.checkedField, 1);
                            PrintMainMenu(field);
                        }
                        break;
                    case ConsoleKey.DownArrow:
                    case ConsoleKey.S:
                        if (index != field.Length - 1)
                        {
                            field[index] = new string(MainClass.uncheckedField, 1);
                            index++;
                            field[index] = new string(MainClass.checkedField, 1);
                            PrintMainMenu(field);
                        }
                        break;
                    case ConsoleKey.Backspace:
                        string wholeUncheckedString2 = new string(MainClass.uncheckedField, 1); //creating the unchecked field /w tabulation
                        string wholeCheckedString2 = new string(MainClass.checkedField, 1); //creating the checked field /w tabulation
                        string[] wholeField2 = new[] // init the menu /w 4 fields
                        {wholeUncheckedString2, wholeUncheckedString2, wholeUncheckedString2, wholeUncheckedString2};
                        wholeField2[index] = wholeCheckedString2;
                        PrintMainMenu(wholeField2);
                        break;
                }
            }
        }

        public static void ModifySubmenu(ConsoleKeyInfo keyInfo, string[] field, int index = 0)
        {
            string wholeUncheckedString = new string(MainClass.uncheckedField, 1); //creating the unchecked field /w tabulation
            string wholeCheckedString = new string(MainClass.checkedField, 1); //creating the checked field /w tabulation
            string[] wholeField = new[] // init the menu /w 4 fields
            {wholeUncheckedString, wholeUncheckedString, wholeUncheckedString, wholeUncheckedString};
            wholeField[0] = wholeCheckedString;
            while ((keyInfo = Console.ReadKey(true)).Key != ConsoleKey.Escape)
            {
                switch (keyInfo.Key)
                {
                    case ConsoleKey.Enter:
                        {
                            if (index == 0)
                            {
                                MainClass.levelChoice = 1;
                                MainClass.menu = false;
                                MainClass.Main();
                                //open level 1
                                break;
                            }
                            if(index == 1)
                            {
                                MainClass.levelChoice = 2;
                                MainClass.menu = false;
                                MainClass.Main();
                            }
                            if(index == 2)
                            {
                                MainClass.levelChoice = 3;
                                MainClass.menu = false;
                                MainClass.Main();
                            }
                            if (index == 3)
                            {
                                MainClass.subMenuField = new[] // reset the fields
                                {MainClass.wholeUncheckedString, MainClass.wholeUncheckedString, MainClass.wholeUncheckedString, MainClass.wholeUncheckedString};
                                //Console.Clear();
                                wholeField[0] = wholeCheckedString;
                                PrintMainMenu(wholeField);
                                ModifyMainMenu(keyInfo, MainClass.mainMenuField, 0);
                            }
                            break;
                        }
                    case ConsoleKey.UpArrow:
                    case ConsoleKey.W:
                        if (index != 0)
                        {
                            field[index] = new string(MainClass.uncheckedField, 1);
                            index--;
                            field[index] = new string(MainClass.checkedField, 1);
                            PrintSubmenu(field);
                        }
                        break;
                    case ConsoleKey.DownArrow:
                    case ConsoleKey.S:
                        if (index != field.Length - 1)
                        {
                            field[index] = new string(MainClass.uncheckedField, 1);
                            index++;
                            field[index] = new string(MainClass.checkedField, 1);

                            PrintSubmenu(field);
                        }
                        break;
                }
            }
        }

        public static string EnterName()
        {

            //name validation
            ClearText();
            //drawing game name

            printingTheTitle();

            //drawing lines
            printFrame();
            //drawing text
            Console.SetCursorPosition((MainClass.width / 2) - 13, (MainClass.height / 2) - 5);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("Please enter a valid name:");
            Console.SetCursorPosition((MainClass.width / 2) - 18, (MainClass.height / 2) + 4);
            Console.Write("[between 3 and 10 characters long]");
            Console.SetCursorPosition((MainClass.width / 2) - 27, (MainClass.height / 2) + 6);
            Console.Write("[containing only letters (A to Z) and numbers (0 to 9]");
            StringBuilder name = new StringBuilder();
            //validate player name
            Console.ForegroundColor = ConsoleColor.White;
            while (true)
            {
                Console.CursorVisible = true;
                name = new StringBuilder();
                Console.SetCursorPosition((MainClass.width / 2) - 4, (MainClass.height / 2) - 1);
                name.Append(Console.ReadLine());
                if (Regex.Match(name.ToString(), @"[-!$%^&*()_+|~=`{}\[\]:; '<>?,.\/]").Success || name.Length < 3 || name.Length > 10)
                {
                    Console.SetCursorPosition((MainClass.width / 2) - 12, (MainClass.height / 2) - 3);
                    Console.WriteLine("Invalid name, try again!");
                    Console.SetCursorPosition(0, (MainClass.height / 2) - 1);
                    Console.WriteLine(new string(' ', Console.WindowWidth));
                    Console.SetCursorPosition(0, (MainClass.height / 2));
                    Console.WriteLine(new string(' ', Console.WindowWidth));
                }
                else
                {
                    ClearText();
                    Console.CursorVisible = false;
                    return name.ToString();
                }
            }
        }
    }
}
