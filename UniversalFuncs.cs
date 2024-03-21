using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldOfWarships2
{
    class Board    
    {
        Player owner;
        bool whetherTarget;    
        public string[,] Displayed =
            {
                {"[~]", "[~]", "[~]", "[~]", "[~]", "[~]", "[~]", "[~]", "[~]", "[~]"},
                {"[~]", "[~]", "[~]", "[~]", "[~]", "[~]", "[~]", "[~]", "[~]", "[~]"},//2    
                {"[~]", "[~]", "[~]", "[~]", "[~]", "[~]", "[~]", "[~]", "[~]", "[~]"},
                {"[~]", "[~]", "[~]", "[~]", "[~]", "[~]", "[~]", "[~]", "[~]", "[~]"},//4    
                {"[~]", "[~]", "[~]", "[~]", "[~]", "[~]", "[~]", "[~]", "[~]", "[~]"},
                {"[~]", "[~]", "[~]", "[~]", "[~]", "[~]", "[~]", "[~]", "[~]", "[~]"},//6     
                {"[~]", "[~]", "[~]", "[~]", "[~]", "[~]", "[~]", "[~]", "[~]", "[~]"},
                {"[~]", "[~]", "[~]", "[~]", "[~]", "[~]", "[~]", "[~]", "[~]", "[~]"},//8
                {"[~]", "[~]", "[~]", "[~]", "[~]", "[~]", "[~]", "[~]", "[~]", "[~]"},
                {"[~]", "[~]", "[~]", "[~]", "[~]", "[~]", "[~]", "[~]", "[~]", "[~]"}
            };
        public Board(Player owner, bool whetherTarget)    
        {
            this.owner = owner;
            this.whetherTarget = whetherTarget;
        }

        public void Display()
        {
            Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" [ ][A][B][C][D][E][F][G][H][I][J]");
            for (int i = 0; i < 10; i++)
            {
                if (i == 9)
                {
                    Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("\n[" + (i + 1) + "]");
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("\n [" + (i + 1) + "]");
                }


                for (int j = 0; j < 10; j++)
                {
                    if (Displayed[i, j] == "[#]")
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGray; Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write(Displayed[i, j]);
                    }
                    if (Displayed[i, j] == "[~]")
                    {
                        Console.BackgroundColor = ConsoleColor.DarkBlue; Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(Displayed[i, j]);
                    }
                    if (Displayed[i, j] == "[x]")
                    {
                        Console.BackgroundColor = ConsoleColor.DarkRed; Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(Displayed[i, j]);
                    }
                    if (Displayed[i, j] == "[*]")
                    {
                        Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write(Displayed[i, j]);
                    }
                    if (Displayed[i, j] == "[o]")
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGreen; Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(Displayed[i, j]);
                    }
                }

            }
            Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.White;
        }
    }    

    internal class Player
    {
        public Board displayBoard;
        public Board shootingBoard;
        public int amountOfShips = 0;
        public byte id;
        public int win;
        public Player(byte id)
        {
            this.id = id;
            displayBoard = new Board(this, false);
            shootingBoard = new Board(this, true);
        }

    }
    class Ship
    {
        byte length, owner;
        public Ship(Player owner, int rowA, int colA)
        {
            owner.displayBoard.Displayed[colA, rowA] = "[#]";
            owner.amountOfShips++;
        }
        public Ship(Player owner, int rowA, int colA, int rowB, int colB)
        {
            owner.displayBoard.Displayed[colA, rowA] = "[#]";
            owner.displayBoard.Displayed[colB, rowB] = "[#]";
            owner.amountOfShips++;
        }
        public Ship(Player owner, int rowA, int colA, int rowB, int colB, int rowC, int colC)
        {
            owner.displayBoard.Displayed[colA, rowA] = "[#]";
            owner.displayBoard.Displayed[colB, rowB] = "[#]";
            owner.displayBoard.Displayed[colC, rowC] = "[#]";
            owner.amountOfShips++;
        }
        public Ship(Player owner, int rowA, int colA, int rowB, int colB, int rowC, int colC, int rowD, int colD)
        {
            owner.displayBoard.Displayed[colA, rowA] = "[#]";
            owner.displayBoard.Displayed[colB, rowB] = "[#]";
            owner.displayBoard.Displayed[colC, rowC] = "[#]";
            owner.displayBoard.Displayed[colD, rowD] = "[#]";
            owner.amountOfShips++;
        }
    }
    class Game
    {
        string TargetTile;
        bool TileAvailable = false;
        Player Attacker, Defender;
        public void SetCurrentPlayer(Player A, Player D)
        {
            this.Attacker = A;
            this.Defender = D;
        }
        public void DeployShips()
        {
            int counter = 0;
            while (counter < 4)
            {
                Attacker.displayBoard.Display();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nPlayer " + Attacker.id + " To Deploy A Fiskebat (A Single Tile Long Ship, As Provided In The Following Examples: A5, c6):");
                TargetTile = InputTile();
                if (WhetherTileOccupied((byte)TargetTile[1] - 48, (byte)TargetTile[0] - 48, Attacker, "[#]") > 0)
                {  
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("\nTile Is Non~Existent Or Already Occupied.");
                        Console.ForegroundColor = ConsoleColor.White;    
                }
                else
                {
                    Ship ship = new Ship(Attacker, (byte)TargetTile[0] - 48, (byte)TargetTile[1] - 48);
                    counter++;
                    Console.Clear();
                }
            }
            string TileA, TileB;
            counter = 0;
            while (counter < 3)
            {
                Attacker.displayBoard.Display();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nPlayer " + Attacker.id + " To Begin Deploying A Byrding (2 Tiles Long Ship, As Provided In The Following Examples: B3, j5):");
                TileA = InputTile();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nPlayer " + Attacker.id + " To Finish Deploying A Byrding (2 Tiles Long Ship, As Provided In The Following Examples: C3, j6):");
                TileB = InputTile();
                if (WhetherTileOccupied((byte)TileA[1] - 48, (byte)TileA[0] - 48, Attacker, "[#]") == 0 && WhetherTileOccupied((byte)TileB[1] - 48, (byte)TileB[0] - 48, Attacker, "[#]") == 0)
                {
                    if ((TileA[0] - 0) == (TileB[0] - 0) && ((TileA[1] - 0) == (TileB[1] - 1) || (TileA[1] - 0) == (TileB[1] + 1)))
                    {
                        Ship ship = new Ship(Attacker, TileA[0] - 48, TileA[1] - 48, TileB[0] - 48, TileB[1] - 48);
                        counter++;
                        Console.Clear();
                    }
                    else if ((TileA[1] - 0) == (TileB[1] - 0) && ((TileA[0] - 0) == (TileB[0] - 1) || (TileA[0] - 0) == (TileB[0] + 1)))
                    {
                        Ship ship = new Ship(Attacker, TileA[0] - 48, TileA[1] - 48, TileB[0] - 48, TileB[1] - 48);
                        counter++;
                        Console.Clear();
                    }
                    else
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("\nTile Is Non~Existent Or Already Occupied.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                else
                {
                    Console.Clear();    
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("\nTile Non~Existent Or Already Occupied.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            counter = 0;
            while (counter < 2)
            {
                Attacker.displayBoard.Display();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nPlayer " + Attacker.id + " To Begin Deploying A Knarr (3 Tiles Long Ship, As Provided In The Following Examples: A5, c6):");
                TileA = InputTile();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nPlayer " + Attacker.id + " To Finish Deploying A Knarr (3 Tiles Long Ship, As Provided In The Following Examples: A7, e6):");
                Console.ForegroundColor = ConsoleColor.White;
                TileB = InputTile();
                if (WhetherTileOccupied((byte)TileA[1] - 48, (byte)TileA[0] - 48, Attacker, "[#]") == 0 && WhetherTileOccupied((byte)TileB[1] - 48, (byte)TileB[0] - 48, Attacker, "[#]") == 0)
                {
                    if ((TileA[0] - 0) == (TileB[0] - 0) && (TileA[1] - 0) == (TileB[1] + 2))
                    {
                        Ship ship = new Ship(Attacker, TileA[0] - 48, TileA[1] - 48, TileB[0] - 48, TileB[1] - 48, TileA[0] - 48, TileA[1] - 49);
                        counter++;
                        Console.Clear();
                    }
                    else if ((TileA[0] - 0) == (TileB[0] - 0) && (TileA[1] - 0) == (TileB[1] - 2))
                    {
                        Ship ship = new Ship(Attacker, TileA[0] - 48, TileA[1] - 48, TileB[0] - 48, TileB[1] - 48, TileA[0] - 48, TileA[1] - 47);
                        counter++;
                        Console.Clear();
                    }
                    else if ((TileA[1] - 0) == (TileB[1] - 0) && ((TileA[0] - 0) == (TileB[0] + 2)))
                    {
                        Ship ship = new Ship(Attacker, TileA[0] - 48, TileA[1] - 48, TileB[0] - 48, TileB[1] - 48, TileA[0] - 49, TileA[1] - 48);
                        counter++;
                        Console.Clear();
                    }
                    else if ((TileA[1] - 0) == (TileB[1] - 0) && ((TileA[0] - 0) == (TileB[0] - 2)))
                    {
                        Ship ship = new Ship(Attacker, TileA[0] - 48, TileA[1] - 48, TileB[0] - 48, TileB[1] - 48, TileA[0] - 47, TileA[1] - 48);
                        counter++;
                        Console.Clear();
                    }
                    else
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("\nTile Is Non~Existent Or Already Occupied.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                else 
                { 
                    Console.Clear();    
                    Console.ForegroundColor = ConsoleColor.DarkRed;    
                    Console.WriteLine("\nTile Non~Existent Or Already Occupied.");    
                    Console.ForegroundColor = ConsoleColor.White;    
                }
            }
            counter = 0;
            while (counter < 1)
            {
                Attacker.displayBoard.Display();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nPlayer " + Attacker.id + " To Begin Deploying A Drakkar (4 Tiles Long Ship, As Provided In The Following Examples: A5, c6):");
                TileA = InputTile();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nPlayer " + Attacker.id + " To Finish Deploying A Drakkar (4 Tiles Long Ship, As Provided In The Following Examples: A8, f6):");
                TileB = InputTile();
                if (WhetherTileOccupied((byte)TileA[1] - 48, (byte)TileA[0] - 48, Attacker, "[#]") == 0 && WhetherTileOccupied((byte)TileB[1] - 48, (byte)TileB[0] - 48, Attacker, "[#]") == 0)
                {
                    if ((TileA[0] - 0) == (TileB[0] - 0) && (TileA[1] - 0) == (TileB[1] + 3))
                    {
                        Ship ship = new Ship(Attacker, TileA[0] - 48, TileA[1] - 48, TileB[0] - 48, TileB[1] - 48, TileA[0] - 48, TileA[1] - 49, TileA[0] - 48, TileA[1] - 50);
                        Console.Clear();
                        counter++;
                    }
                    else if ((TileA[0] - 0) == (TileB[0] - 0) && (TileA[1] - 0) == (TileB[1] - 3))
                    {
                        Ship ship = new Ship(Attacker, TileA[0] - 48, TileA[1] - 48, TileB[0] - 48, TileB[1] - 48, TileA[0] - 48, TileA[1] - 47, TileA[0] - 48, TileA[1] - 46);
                        Console.Clear();
                        counter++;
                    }
                    else if ((TileA[1] - 0) == (TileB[1] - 0) && ((TileA[0] - 0) == (TileB[0] + 3)))
                    {
                        Ship ship = new Ship(Attacker, TileA[0] - 48, TileA[1] - 48, TileB[0] - 48, TileB[1] - 48, TileA[0] - 49, TileA[1] - 48, TileA[0] - 50, TileA[1] - 48);
                        Console.Clear();
                        counter++;
                    }
                    else if ((TileA[1] - 0) == (TileB[1] - 0) && ((TileA[0] - 0) == (TileB[0] - 3)))
                    {
                        Ship ship = new Ship(Attacker, TileA[0] - 48, TileA[1] - 48, TileB[0] - 48, TileB[1] - 48, TileA[0] - 47, TileA[1] - 48, TileA[0] - 46, TileA[1] - 48);
                        Console.Clear();
                        counter++;
                    }
                    else
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("\nTile Is Non~Existent Or Already Occupied.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                else 
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("\nTile Is Non~Existent Or Already Occupied.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

            Attacker.displayBoard.Display();
        }
        string InputTile()
        {
            string TileData = Console.ReadLine().ToUpper();
            if (TileData.Length == 3)
            {
                if (TileData[1] == '1' && TileData[2] == '0')
                {
                    TileData = TileData[0] + "9";
                    TileAvailable = IsTileAvailable(TileData);
                }
                else
                {
                    TileAvailable = false;
                }
            }
            else if (TileData.Length == 2)
            {
                TileData = "" + TileData[0] + (char)(TileData[1] - 1);
                TileAvailable = IsTileAvailable(TileData);
            }
            else
            {
                TileAvailable = false;
            }
            if (TileAvailable)
            {
                char temp = TileData[0];
                int a = (int)temp - 65;

                return "" + a + TileData[1];
            }
            else
            {  
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\nTile Is Non~Existent Or Already Occupied.");
                Console.ForegroundColor = ConsoleColor.White;  
                return InputTile();
            }
        }
        bool IsTileAvailable(string text)
        {
            if (text[0] <= 74 && text[0] >= 65 && text[1] >= 48 && text[1] <= 57)
            {
                return true;
            }
            return false;

        }
        int WhetherTileOccupied(int column, int row, Player p, string target)
        {
            int temp = 0;
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    try
                    {
                        if (p.displayBoard.Displayed[column + i, row + j] == target)
                        {
                            temp++;
                        }
                    }
                    catch (Exception e)
                    {
                    }
                }
            }
            return temp;
        }
        void ClearArea(Player p, Player p2)
        {
            for (int row = 0; row < 10; row++)
            {
                for (int column = 0; column < 10; column++)
                {
                    if (p.displayBoard.Displayed[column, row] == "[*]")
                    {
                        for (int i = -1; i <= 1; i++)
                        {
                            for (int j = -1; j <= 1; j++)
                            {
                                try
                                {
                                    if (p.displayBoard.Displayed[column + i, row + j] == "[~]")
                                    {
                                        p2.shootingBoard.Displayed[column + i, row + j] = "[o]";
                                        p.displayBoard.Displayed[column + i, row + j] = "[o]";
                                    }
                                }
                                catch (Exception e)
                                {
                                }
                            }
                        }
                    }
                }
            }

        }
        bool IsSunk(Player p, Player p2, int column, int row)
        {
            int[] arr = { 0, 0, 0, 0 };
            int temp = 0;
            p2.displayBoard.Displayed[column, row] = "[T]";
            if (WhetherTileOccupied(column, row, p2, "[#]") > 0)
            {
                return false;
            }
            else if (WhetherTileOccupied(column, row, p2, "[x]") == 1)
            {
                for (int i = -1; i <= 1; i++)
                {
                    for (int j = -1; j <= 1; j++)
                    {
                        try
                        {
                            if (p2.displayBoard.Displayed[column + i, row + j] == "[x]")
                            {
                                return IsSunk(p, p2, column + i, row + j);
                            }
                        }
                        catch (Exception e)
                        {
                        }
                    }
                }

            }
            else if (WhetherTileOccupied(column, row, p2, "[x]") == 2)
            {

                for (int i = -1; i <= 1; i++)
                {
                    for (int j = -1; j <= 1; j++)
                    {
                        try
                        {
                            if (p2.displayBoard.Displayed[column + i, row + j] == "[~]")
                            {
                                arr[temp] = column + i;
                                arr[temp + 1] = row + j;
                                temp = 2;
                            }
                        }
                        catch (Exception e)
                        {
                        }
                    }
                }
                if (IsSunk(p, p2, arr[0], arr[1]) && IsSunk(p, p2, arr[2], arr[3]))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }

            return false;
        }
        void TempChanger(Player p, Player p2, string toChange)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (p.displayBoard.Displayed[j, i] == "[T]")
                    {
                        p.displayBoard.Displayed[j, i] = toChange;
                        p2.shootingBoard.Displayed[j, i] = toChange;
                    }
                }
            }

        }
        public void Fire()
        {
            if (Defender.amountOfShips > 0)
            {
                Console.Clear();
                Attacker.shootingBoard.Display();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nSelect A Tile To Open Fire At:\n");
                TargetTile = InputTile();
                if (Defender.displayBoard.Displayed[TargetTile[1] - 48, TargetTile[0] - 48] != "[#]" && Defender.displayBoard.Displayed[TargetTile[1] - 48, TargetTile[0] - 48] != "[~]")
                {    
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("\nYou Have Already Struck That Position.\n");    
                    Console.ForegroundColor = ConsoleColor.White;    
                    ContinueOnEnter();
                    Fire();
                }
                else
                {

                    if (Defender.displayBoard.Displayed[TargetTile[1] - 48, TargetTile[0] - 48] == "[#]")
                    {
                        if (IsSunk(Attacker, Defender, TargetTile[1] - 48, TargetTile[0] - 48))
                        {      
                            RandomSinkMessage();    
                            TempChanger(Defender, Attacker, "[*]");
                            ClearArea(Defender, Attacker);
                            Defender.amountOfShips--;
                        }
                        else
                        {
                            Console.WriteLine("Chaos Envokes On Enemies' Decks As Our Cannons Masterfully Pierce Their Hulls!");
                            TempChanger(Defender, Attacker, "[x]");
                        }
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nEnemies Breaking Their Lines Gave Us The Time Needed To Reload Our Cannons, Earning Us Yet Another Volley Of Cannonballs.");
                        Console.ForegroundColor= ConsoleColor.White;
                        ContinueOnEnter();
                        Fire();
                    }
                    else
                    {
                        Console.WriteLine("Empty");
                        Attacker.shootingBoard.Displayed[TargetTile[1] - 48, TargetTile[0] - 48] = "[o]";
                        Defender.displayBoard.Displayed[TargetTile[1] - 48, TargetTile[0] - 48] = "[o]";
                    }
                }
            }

        }
        public void ContinueOnEnter()
        {
            Console.WriteLine("Press ENTER key to continue: ");
            Console.ReadLine();
        }
        public bool IsWon(Player p1, Player p2)
        {
            if (p1.amountOfShips == 0 || p2.amountOfShips == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void PlayersSwitch()
        {
            Console.Clear();
            Console.WriteLine("Change the player and click ENTER: ");
            Console.ReadLine();
        }
        public void TeamChange()
        {
            Player temp = Attacker;
            Attacker = Defender;
            Defender = temp;
        }
        public void RandomSinkMessage()
        {
            Random rng = new Random();    
            Console.ForegroundColor = ConsoleColor.DarkRed;
            switch(rng.Next(8))
            {
                case 0:      
                    Console.WriteLine("\nEnemy Ship Was Captured In Boarding.");  
                    break;
                case 1:
                    Console.WriteLine("\nEnemy Knarrs Burnt To Crisp When Exposed To Our Greek Fire.");
                    break;
                case 2:
                    Console.WriteLine("\nWe've Surrounded And Succesfuly Boarded Enemy Drakkar With A Fleet Of Our Seven Trusty Fishing Vessels.");
                    break;
                case 3:
                    Console.WriteLine("\nThe Hulls Of Enemy Ships Fill With Water After Being Pierced By Our Trebuchets Firing From Inland.");    
                    break;
                case 4:
                    Console.WriteLine("\nProbably Due To A Carpenter's Mistake, Enemy Ship's Mast Snapped In Half After A Sail Collapsed On Itself.");
                    break;
                case 5:
                    Console.WriteLine("\nEnemy Ship Sunk After Being Hit By An Enormous Wave.");
                    break;
                case 6:
                    Console.WriteLine("\nEnemy Crew Fled Onto Another Ship After Failing At Salvaging This One From Sinking.");
                    break;
                case 7:
                    Console.WriteLine("\nA Blow To Enemy Stern Forced Their Captain To Retreat.");
                    break;
                default:
                    Console.WriteLine("\nSuperior Firepower Of Our Longbowmen Overwhelmed Enemy Sailors.");
                    break;
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        //AI Functions//

        string AIInput()
        {
            Random random = new Random();      
            char randomLetter = (char)random.Next('A', 'K');    
            int randomNumber = random.Next(1, 11);  
            string TileData = $"{randomLetter}{randomNumber}";    
                
            if (TileData.Length == 3)
            {
                if (TileData[1] == '1' && TileData[2] == '0')
                {
                    TileData = TileData[0] + "9";
                    TileAvailable = IsTileAvailable(TileData);
                }
                else
                {
                    TileAvailable = false;
                }
            }
            else if (TileData.Length == 2)
            {
                TileData = "" + TileData[0] + (char)(TileData[1] - 1);
                TileAvailable = IsTileAvailable(TileData);
            }
            else
            {
                TileAvailable = false;
            }
            if (TileAvailable)
            {
                char temp = TileData[0];
                int a = (int)temp - 65;

                return "" + a + TileData[1];
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\nTile Is Non~Existent Or Already Occupied.");
                Console.ForegroundColor = ConsoleColor.White;
                return AIInput();
            }  
        }    
            
        public void AIFire()
        {
            TargetTile = AIInput();
            if (Defender.amountOfShips > 0)
            {    
                if (Defender.displayBoard.Displayed[TargetTile[1] - 48, TargetTile[0] - 48] != "[#]" && Defender.displayBoard.Displayed[TargetTile[1] - 48, TargetTile[0] - 48] != "[~]")
                {  
                    AIFire();
                }
                else
                {

                    if (Defender.displayBoard.Displayed[TargetTile[1] - 48, TargetTile[0] - 48] == "[#]")
                    {
                        if (IsSunk(Attacker, Defender, TargetTile[1] - 48, TargetTile[0] - 48))
                        {
                            RandomSinkMessage();
                            TempChanger(Defender, Attacker, "[*]");
                            ClearArea(Defender, Attacker);
                            Defender.amountOfShips--;
                        }
                        else
                        {
                            Console.WriteLine("Chaos Envokes On Our' Decks As Enemy Cannons Masterfully Pierce Their Hulls!");
                            TempChanger(Defender, Attacker, "[x]");
                        }
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nAs We Broke Lines, We Gave The Enemies The Time Needed To Reload Their Cannons, Earning Them Yet Another Volley Of Cannonballs.");
                        Console.ForegroundColor = ConsoleColor.White;
                        ContinueOnEnter();
                        AIFire();
                    }
                    else
                    {
                        Console.WriteLine("Empty");
                        Attacker.shootingBoard.Displayed[TargetTile[1] - 48, TargetTile[0] - 48] = "[o]";
                        Defender.displayBoard.Displayed[TargetTile[1] - 48, TargetTile[0] - 48] = "[o]";
                    }
                }
            }
        }

        public void ShipsForAI()
        {

            Console.ForegroundColor = ConsoleColor.Yellow;    
            Console.WriteLine("\n The Enemy Admiral Is Currently Deploying Their Fleet.");      
            int counter = 0;
            while (counter < 4)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n The Enemy Admiral Is Currently Deploying Their Fleet.");
                TargetTile = AIInput();
                if (WhetherTileOccupied((byte)TargetTile[1] - 48, (byte)TargetTile[0] - 48, Attacker, "[#]") > 0)
                {
                    Console.Clear();
                    Attacker.displayBoard.Display();
                }
                else
                {
                    Ship ship = new Ship(Attacker, (byte)TargetTile[0] - 48, (byte)TargetTile[1] - 48);
                    counter++;
                    Console.Clear();
                }
            }
            string TileA, TileB;
            counter = 0;
            while (counter < 3)
            {

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n The Enemy Admiral Is Currently Deploying Their Fleet.");
                TileA = AIInput();    
                TileB = AIInput();
                if (WhetherTileOccupied((byte)TileA[1] - 48, (byte)TileA[0] - 48, Attacker, "[#]") == 0 && WhetherTileOccupied((byte)TileB[1] - 48, (byte)TileB[0] - 48, Attacker, "[#]") == 0)
                {
                    if ((TileA[0] - 0) == (TileB[0] - 0) && ((TileA[1] - 0) == (TileB[1] - 1) || (TileA[1] - 0) == (TileB[1] + 1)))
                    {
                        Ship ship = new Ship(Attacker, TileA[0] - 48, TileA[1] - 48, TileB[0] - 48, TileB[1] - 48);
                        counter++;
                        Console.Clear();
                    }
                    else if ((TileA[1] - 0) == (TileB[1] - 0) && ((TileA[0] - 0) == (TileB[0] - 1) || (TileA[0] - 0) == (TileB[0] + 1)))
                    {
                        Ship ship = new Ship(Attacker, TileA[0] - 48, TileA[1] - 48, TileB[0] - 48, TileB[1] - 48);
                        counter++;
                        Console.Clear();
                    }
                    else
                    {
                        Console.Clear();
                    }
                }
                else
                {
                    Console.Clear();
                    Attacker.displayBoard.Display();
                }
            }
            counter = 0;
            while (counter < 2)
            {

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n The Enemy Admiral Is Currently Deploying Their Fleet.");
                TileA = AIInput();    
                Console.ForegroundColor = ConsoleColor.White;      
                TileB = AIInput();      
                if (WhetherTileOccupied((byte)TileA[1] - 48, (byte)TileA[0] - 48, Attacker, "[#]") == 0 && WhetherTileOccupied((byte)TileB[1] - 48, (byte)TileB[0] - 48, Attacker, "[#]") == 0)
                {
                    if ((TileA[0] - 0) == (TileB[0] - 0) && (TileA[1] - 0) == (TileB[1] + 2))
                    {
                        Ship ship = new Ship(Attacker, TileA[0] - 48, TileA[1] - 48, TileB[0] - 48, TileB[1] - 48, TileA[0] - 48, TileA[1] - 49);
                        counter++;
                        Console.Clear();
                    }
                    else if ((TileA[0] - 0) == (TileB[0] - 0) && (TileA[1] - 0) == (TileB[1] - 2))
                    {
                        Ship ship = new Ship(Attacker, TileA[0] - 48, TileA[1] - 48, TileB[0] - 48, TileB[1] - 48, TileA[0] - 48, TileA[1] - 47);
                        counter++;
                        Console.Clear();
                    }
                    else if ((TileA[1] - 0) == (TileB[1] - 0) && ((TileA[0] - 0) == (TileB[0] + 2)))
                    {
                        Ship ship = new Ship(Attacker, TileA[0] - 48, TileA[1] - 48, TileB[0] - 48, TileB[1] - 48, TileA[0] - 49, TileA[1] - 48);
                        counter++;
                        Console.Clear();
                    }
                    else if ((TileA[1] - 0) == (TileB[1] - 0) && ((TileA[0] - 0) == (TileB[0] - 2)))
                    {
                        Ship ship = new Ship(Attacker, TileA[0] - 48, TileA[1] - 48, TileB[0] - 48, TileB[1] - 48, TileA[0] - 47, TileA[1] - 48);
                        counter++;
                        Console.Clear();
                    }
                    else
                    {
                        Console.Clear();
                        Attacker.displayBoard.Display();
                    }
                }
                else
                {
                    Console.Clear();
                    Attacker.displayBoard.Display();
                }
            }
            counter = 0;
            while (counter < 1)
            {

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n The Enemy Admiral Is Currently Deploying Their Fleet.");
                TileA = AIInput();  
                TileB = AIInput();
                if (WhetherTileOccupied((byte)TileA[1] - 48, (byte)TileA[0] - 48, Attacker, "[#]") == 0 && WhetherTileOccupied((byte)TileB[1] - 48, (byte)TileB[0] - 48, Attacker, "[#]") == 0)
                {
                    if ((TileA[0] - 0) == (TileB[0] - 0) && (TileA[1] - 0) == (TileB[1] + 3))
                    {
                        Ship ship = new Ship(Attacker, TileA[0] - 48, TileA[1] - 48, TileB[0] - 48, TileB[1] - 48, TileA[0] - 48, TileA[1] - 49, TileA[0] - 48, TileA[1] - 50);
                        Console.Clear();
                        counter++;
                    }
                    else if ((TileA[0] - 0) == (TileB[0] - 0) && (TileA[1] - 0) == (TileB[1] - 3))
                    {
                        Ship ship = new Ship(Attacker, TileA[0] - 48, TileA[1] - 48, TileB[0] - 48, TileB[1] - 48, TileA[0] - 48, TileA[1] - 47, TileA[0] - 48, TileA[1] - 46);
                        Console.Clear();
                        counter++;
                    }
                    else if ((TileA[1] - 0) == (TileB[1] - 0) && ((TileA[0] - 0) == (TileB[0] + 3)))
                    {
                        Ship ship = new Ship(Attacker, TileA[0] - 48, TileA[1] - 48, TileB[0] - 48, TileB[1] - 48, TileA[0] - 49, TileA[1] - 48, TileA[0] - 50, TileA[1] - 48);
                        Console.Clear();
                        counter++;
                    }
                    else if ((TileA[1] - 0) == (TileB[1] - 0) && ((TileA[0] - 0) == (TileB[0] - 3)))
                    {
                        Ship ship = new Ship(Attacker, TileA[0] - 48, TileA[1] - 48, TileB[0] - 48, TileB[1] - 48, TileA[0] - 47, TileA[1] - 48, TileA[0] - 46, TileA[1] - 48);
                        Console.Clear();
                        counter++;
                    }
                    else
                    {
                        Console.Clear();
                        Attacker.displayBoard.Display();
                    }
                }
                else
                {
                    Console.Clear();
                    Attacker.displayBoard.Display();
                }
            }

            Attacker.displayBoard.Display();
        }
    }     
}
