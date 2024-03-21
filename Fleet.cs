using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WorldOfWarships2
{
    class Ship
    {
        Player owner;
        byte length;    
        public Ship(Player owner, int row, int column)
        {
            owner.displayBoard.Displayed[column, row] = "[#]";
            owner.amountOfShips++;
        }
        public Ship(Player owner, int row, int column, int row2, int column2)
        {
            owner.displayBoard.board[column, row] = "[#]";
            owner.displayBoard.board[column2, row2] = "[#]";
            owner.amountOfShips++;
        }
        public Ship(Player owner, int row, int column, int row2, int column2, int row3, int column3)
        {
            owner.displayBoard.board[column, row] = "[#]";
            owner.displayBoard.board[column2, row2] = "[#]";
            owner.displayBoard.board[column3, row3] = "[#]";
            owner.amountOfShips++;
        }
        public Ship(Player owner, int row, int column, int row2, int column2, int row3, int column3, int row4, int column4)
        {
            owner.displayBoard.board[column, row] = "[#]";
            owner.displayBoard.board[column2, row2] = "[#]";
            owner.displayBoard.board[column3, row3] = "[#]";
            owner.displayBoard.board[column4, row4] = "[#]";
            owner.amountOfShips++;  
    
            void PlaceShips()
            {
                int counter = 0;
                while (counter < 4)
                {
                    currentPlayer.displayBoard.DisplayBoard();
                    Console.WriteLine("Player " + currentPlayer.id + " Deploy Your Fiskebat (Single Tile Long Ship, As Provided In An Example: A2, J5):";
                    selectedField = GetPlayerField();
                    if (CheckIfFieldOcupated((byte)selectedField[1] - 48, (byte)selectedField[0] - 48, currentPlayer, "[#]") > 0)
                    {
                        Console.WriteLine("Unable To Deploy A Ship: Tile Doesn't Exist Or Is Already Occupied.");
                    }
                    else
                    {
                        Ship ship = new Ship(currentPlayer, (byte)selectedField[0] - 48, (byte)selectedField[1] - 48);
                        counter++;
                        Console.Clear();
                    }
                }
                string field1, field2;
                counter = 0;
                while (counter < 3)
                {
                    currentPlayer.displayBoard.DisplayBoard();
                    Console.WriteLine("Player " + currentPlayer.id + " Select Where To Start The Deployment Of Your Byrding (Two Tiles Long Ship, As Provided In An Example: A2, J5):");
                    field1 = GetPlayerField();
                    Console.WriteLine("Player " + currentPlayer.id + " Select Where To End The Deployment Of Your Byrding (Two Tiles Long Ship, As Provided In An Example: B2, J4):");
                    field2 = GetPlayerField();
                    if (CheckIfFieldOcupated((byte)field1[1] - 48, (byte)field1[0] - 48, currentPlayer, "[#]") == 0 && CheckIfFieldOcupated((byte)field2[1] - 48, (byte)field2[0] - 48, currentPlayer, "[#]") == 0)
                    {
                        if ((field1[0] - 0) == (field2[0] - 0) && ((field1[1] - 0) == (field2[1] - 1) || (field1[1] - 0) == (field2[1] + 1)))
                        {
                            Ship ship = new Ship(currentPlayer, field1[0] - 48, field1[1] - 48, field2[0] - 48, field2[1] - 48);
                            counter++;
                            Console.Clear();
                        }
                        else if ((field1[1] - 0) == (field2[1] - 0) && ((field1[0] - 0) == (field2[0] - 1) || (field1[0] - 0) == (field2[0] + 1)))
                        {
                            Ship ship = new Ship(currentPlayer, field1[0] - 48, field1[1] - 48, field2[0] - 48, field2[1] - 48);
                            counter++;
                            Console.Clear();
                        }
                        else
                        {
                            Console.Clear(); Console.WriteLine("Unable To Deploy A Ship: Tile Doesn't Exist Or Is Already Occupied.");
                        }
                    }
                    else { Console.Clear(); Console.WriteLine("Unable To Deploy A Ship: Tile Doesn't Exist Or Is Already Occupied."); }
                }
                counter = 0;
                while (counter < 2)
                {
                    currentPlayer.displayBoard.DisplayBoard();
                    Console.WriteLine("Player " + currentPlayer.id + " Select Where To Start The Deployment Of Your Knarr (Three Tiles Long Ship, As Provided In An Example: A2, J5):");
                    field1 = GetPlayerField();
                    Console.WriteLine("Player " + currentPlayer.id + " Select Where To Start The Deployment Of Your Knarr (Three Tiles Long Ship, As Provided In An Example: C2, J7):");
                    field2 = GetPlayerField();
                    if (CheckIfFieldOcupated((byte)field1[1] - 48, (byte)field1[0] - 48, currentPlayer, "[#]") == 0 && CheckIfFieldOcupated((byte)field2[1] - 48, (byte)field2[0] - 48, currentPlayer, "[#]") == 0)
                    {
                        if ((field1[0] - 0) == (field2[0] - 0) && (field1[1] - 0) == (field2[1] + 2))
                        {
                            Ship ship = new Ship(currentPlayer, field1[0] - 48, field1[1] - 48, field2[0] - 48, field2[1] - 48, field1[0] - 48, field1[1] - 49);
                            counter++;
                            Console.Clear();
                        }
                        else if ((field1[0] - 0) == (field2[0] - 0) && (field1[1] - 0) == (field2[1] - 2))
                        {
                            Ship ship = new Ship(currentPlayer, field1[0] - 48, field1[1] - 48, field2[0] - 48, field2[1] - 48, field1[0] - 48, field1[1] - 47);
                            counter++;
                            Console.Clear();
                        }
                        else if ((field1[1] - 0) == (field2[1] - 0) && ((field1[0] - 0) == (field2[0] + 2)))
                        {
                            Ship ship = new Ship(currentPlayer, field1[0] - 48, field1[1] - 48, field2[0] - 48, field2[1] - 48, field1[0] - 49, field1[1] - 48);
                            counter++;
                            Console.Clear();
                        }
                        else if ((field1[1] - 0) == (field2[1] - 0) && ((field1[0] - 0) == (field2[0] - 2)))
                        {
                            Ship ship = new Ship(currentPlayer, field1[0] - 48, field1[1] - 48, field2[0] - 48, field2[1] - 48, field1[0] - 47, field1[1] - 48);
                            counter++;
                            Console.Clear();
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Unable To Deploy A Ship: Tile Doesn't Exist Or Is Already Occupied.");
                        }
                    }
                    else { Console.Clear(); Console.WriteLine("Unable To Deploy A Ship: Tile Doesn't Exist Or Is Already Occupied."); }
                }
                counter = 0;
                while (counter < 1)
                {
                    currentPlayer.displayBoard.DisplayBoard();
                    Console.WriteLine("Player " + currentPlayer.id + " Select Where To Start The Deployment Of Your Drakkar (Four Tiles Long Ship, As Provided In An Example: A2, J5):");
                    field1 = GetPlayerField();
                    Console.WriteLine("Player " + currentPlayer.id + " Select Where To Start The Deployment Of Your Drakkar (Four Tiles Long Ship, As Provided In An Example: D2, J8):");
                    field2 = GetPlayerField();
                    if (CheckIfFieldOcupated((byte)field1[1] - 48, (byte)field1[0] - 48, currentPlayer, "[#]") == 0 && CheckIfFieldOcupated((byte)field2[1] - 48, (byte)field2[0] - 48, currentPlayer, "[#]") == 0)
                    {
                        if ((field1[0] - 0) == (field2[0] - 0) && (field1[1] - 0) == (field2[1] + 3))
                        {
                            Ship ship = new Ship(currentPlayer, field1[0] - 48, field1[1] - 48, field2[0] - 48, field2[1] - 48, field1[0] - 48, field1[1] - 49, field1[0] - 48, field1[1] - 50);
                            Console.Clear();
                            counter++;
                        }
                        else if ((field1[0] - 0) == (field2[0] - 0) && (field1[1] - 0) == (field2[1] - 3))
                        {
                            Ship ship = new Ship(currentPlayer, field1[0] - 48, field1[1] - 48, field2[0] - 48, field2[1] - 48, field1[0] - 48, field1[1] - 47, field1[0] - 48, field1[1] - 46);
                            Console.Clear();
                            counter++;
                        }
                        else if ((field1[1] - 0) == (field2[1] - 0) && ((field1[0] - 0) == (field2[0] + 3)))
                        {
                            Ship ship = new Ship(currentPlayer, field1[0] - 48, field1[1] - 48, field2[0] - 48, field2[1] - 48, field1[0] - 49, field1[1] - 48, field1[0] - 50, field1[1] - 48);
                            Console.Clear();
                            counter++;
                        }
                        else if ((field1[1] - 0) == (field2[1] - 0) && ((field1[0] - 0) == (field2[0] - 3)))
                        {
                            Ship ship = new Ship(currentPlayer, field1[0] - 48, field1[1] - 48, field2[0] - 48, field2[1] - 48, field1[0] - 47, field1[1] - 48, field1[0] - 46, field1[1] - 48);
                            Console.Clear();
                            counter++;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Unable To Deploy A Ship: Tile Doesn't Exist Or Is Already Occupied.");
                        }
                    }
                    else { Console.Clear(); Console.WriteLine("Unable To Deploy A Ship: Tile Doesn't Exist Or Is Already Occupied."); }
                }
                currentPlayer.displayBoard.DisplayBoard();
            }
        }
    }  
}