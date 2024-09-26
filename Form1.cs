using System;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.CompilerServices;

/*Sprawdzanie czy moze byc dwojka, trojka, czworka - generowanie statkow bota
 * losowe generownaie statkow gracza lub mozliwosc wyboru polozenia
 */

namespace statki
{
    public partial class Form1 : Form
    {
        string[,] areasBot = new string[10, 10];
        string[,] areasPlayer = new string[10, 10];
        int areaX, areaY, direction;
        bool placed;
        Random shipPosition = new Random();
        Random shipDirection = new Random();


        Ship ship1 = new Ship();
        Ship ship2 = new Ship();
        Ship ship3 = new Ship();
        Ship ship4 = new Ship();
        Ship ship1Player = new Ship();
        Ship ship2Player = new Ship();
        Ship ship3Player = new Ship();
        Ship ship4Player = new Ship();
        public Form1()
        {
            InitializeComponent();
            TableImplementation();
            CreateBotButtons();
            PlayerButtons();
            GenerateBotShips();
            GeneratePlayerShips(); 
        }
          
        void TableImplementation()
        {
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    areasBot[x, y] = Condition.Empty.ToString();
                }
            }
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    areasPlayer[x, y] = Condition.Empty.ToString();
                }
            }
        }

        void GenerateBotShips()
        {
            for (int i = 0; i < ship1.ship1Count; i++)
            {
                placed = false;
                while (!placed)
                {
                    areaX = shipPosition.Next(0, 10);
                    areaY = shipPosition.Next(0, 10);
                    //CanPlaceShip(areaX, areaY, areas);
                    if (CanPlaceShip1(areaX, areaY, areasBot))
                    {
                        placed = true;
                        areasBot[areaX, areaY] = Condition.Ship.ToString();
                    }
                }
            }
            //dwojki bot
            for (int i = 0; i < ship2.ship2Count; i++)
            {
                placed = false;
                while (!placed)
                {
                    areaX = shipPosition.Next(0, 10);
                    areaY = shipPosition.Next(0, 10);
                    direction = shipDirection.Next(0, 2);
                    if (CanPlaceShip1(areaX, areaY, areasBot))
                    {
                        if (direction == 0)//poziom
                        {
                            if (CanPlaceShip1(areaX - 1, areaY, areasBot))
                            {
                                placed = true;
                                areasBot[areaX, areaY] = Condition.Ship.ToString();
                                areasBot[areaX - 1, areaY] = Condition.Ship.ToString();
                            }
                            else if (CanPlaceShip1(areaX + 1, areaY, areasBot))
                            {
                                placed = true;
                                areasBot[areaX, areaY] = Condition.Ship.ToString();
                                areasBot[areaX + 1, areaY] = Condition.Ship.ToString();
                            }
                        }
                        if (direction == 1) //pion
                        {
                            if (CanPlaceShip1(areaX, areaY - 1, areasBot))
                            {
                                placed = true;
                                areasBot[areaX, areaY] = Condition.Ship.ToString();
                                areasBot[areaX, areaY - 1] = Condition.Ship.ToString();
                            }
                            else if (CanPlaceShip1(areaX, areaY + 1, areasBot))
                            {
                                placed = true;
                                areasBot[areaX, areaY] = Condition.Ship.ToString();
                                areasBot[areaX, areaY + 1] = Condition.Ship.ToString();

                            }
                        }

                    }

                    //CanPlaceShip2(areaX - 1, areaY, areas);
                }
            }

            //trojki bot
            for (int i = 0; i < ship3.ship3Count; i++)
            {
                placed = false;
                while (!placed)
                {
                    areaX = shipPosition.Next(0, 10);
                    areaY = shipPosition.Next(0, 10);
                    direction = shipDirection.Next(0, 2);//kierunek
                    if (CanPlaceShip1(areaX, areaY, areasBot))
                    {
                        if (direction == 0)//poziom
                        {
                            if (CanPlaceShip1(areaX - 2, areaY, areasBot))
                            {
                                placed = true;
                                areasBot[areaX, areaY] = Condition.Ship.ToString();
                                areasBot[areaX - 1, areaY] = Condition.Ship.ToString();
                                areasBot[areaX - 2, areaY] = Condition.Ship.ToString();
                            }
                            else if (CanPlaceShip1(areaX + 2, areaY, areasBot))
                            {
                                placed = true;
                                areasBot[areaX, areaY] = Condition.Ship.ToString();
                                areasBot[areaX + 1, areaY] = Condition.Ship.ToString();
                                areasBot[areaX + 2, areaY] = Condition.Ship.ToString();
                            }
                        }
                        if (direction == 1)//pion
                        {
                            if (CanPlaceShip1(areaX, areaY - 2, areasBot))
                            {
                                placed = true;
                                areasBot[areaX, areaY] = Condition.Ship.ToString();
                                areasBot[areaX, areaY - 1] = Condition.Ship.ToString();
                                areasBot[areaX, areaY - 2] = Condition.Ship.ToString();
                            }
                            else if (CanPlaceShip1(areaX, areaY + 2, areasBot))
                            {
                                placed = true;
                                areasBot[areaX, areaY] = Condition.Ship.ToString();
                                areasBot[areaX, areaY + 1] = Condition.Ship.ToString();
                                areasBot[areaX, areaY + 2] = Condition.Ship.ToString();
                            }
                        }
                    }
                }
            }
            //czworki bot
            for (int i = 0; i < ship4.ship4Count; i++)
            {
                placed = false;
                while (!placed)
                {
                    areaX = shipPosition.Next(0, 10);
                    areaY = shipPosition.Next(0, 10);
                    direction = shipDirection.Next(0, 2);//kierunek
                    if (CanPlaceShip1(areaX, areaY, areasBot))
                    {
                        if (direction == 0)//poziom
                        {
                            if (CanPlaceShip1(areaX - 3, areaY, areasBot))
                            {
                                placed = true;
                                areasBot[areaX, areaY] = Condition.Ship.ToString();
                                areasBot[areaX - 1, areaY] = Condition.Ship.ToString();
                                areasBot[areaX - 2, areaY] = Condition.Ship.ToString();
                                areasBot[areaX - 3, areaY] = Condition.Ship.ToString();
                            }
                            else if (CanPlaceShip1(areaX + 3, areaY, areasBot))
                            {
                                placed = true;
                                areasBot[areaX, areaY] = Condition.Ship.ToString();
                                areasBot[areaX + 1, areaY] = Condition.Ship.ToString();
                                areasBot[areaX + 2, areaY] = Condition.Ship.ToString();
                                areasBot[areaX + 3, areaY] = Condition.Ship.ToString();
                            }
                        }
                        if (direction == 1)//pion
                        {
                            if (CanPlaceShip1(areaX, areaY - 3, areasBot))
                            {
                                placed = true;
                                areasBot[areaX, areaY] = Condition.Ship.ToString();
                                areasBot[areaX, areaY - 1] = Condition.Ship.ToString();
                                areasBot[areaX, areaY - 2] = Condition.Ship.ToString();
                                areasBot[areaX, areaY - 3] = Condition.Ship.ToString();
                            }
                            else if (CanPlaceShip1(areaX, areaY + 3, areasBot))
                            {
                                placed = true;
                                areasBot[areaX, areaY] = Condition.Ship.ToString();
                                areasBot[areaX, areaY + 1] = Condition.Ship.ToString();
                                areasBot[areaX, areaY + 2] = Condition.Ship.ToString();
                                areasBot[areaX, areaY + 3] = Condition.Ship.ToString();
                            }
                        }
                    }
                }
            }
        }


        void GeneratePlayerShips()
        {
            for (int i = 0; i < ship1Player.ship1Count; i++)
            {
                placed = false;
                while (!placed)
                {
                    areaX = shipPosition.Next(0, 10);
                    areaY = shipPosition.Next(0, 10);
                    //CanPlaceShip(areaX, areaY, areas);
                    if (CanPlaceShip1(areaX, areaY, areasPlayer))
                    {
                        placed = true;
                        int index = areaY * 10 + areaX + 100;
                        Button buttonToChange = (Button)this.Controls[index];
                        buttonToChange.BackColor = System.Drawing.Color.Green;
                        areasPlayer[areaX, areaY] = Condition.Ship.ToString();


                    }
                }
            }
            //dwojki Gracz
            for (int i = 0; i < ship2Player.ship2Count; i++)
            {
                placed = false;
                while (!placed)
                {
                    areaX = shipPosition.Next(0, 10);
                    areaY = shipPosition.Next(0, 10);
                    direction = shipDirection.Next(0, 2);
                    if (CanPlaceShip1(areaX, areaY, areasPlayer))
                    {
                        if (direction == 0)//poziom
                        {
                            if (CanPlaceShip1(areaX - 1, areaY, areasPlayer))
                            {
                                placed = true;
                                int index1 = areaY * 10 + areaX + 100;
                                int index2 = areaY * 10 + areaX - 1 + 100;
                                Button buttonToChange1 = (Button)this.Controls[index1];
                                Button buttonToChange2 = (Button)this.Controls[index2];
                                buttonToChange1.BackColor = System.Drawing.Color.Green;
                                buttonToChange2.BackColor = System.Drawing.Color.Green;
                                areasPlayer[areaX, areaY] = Condition.Ship.ToString();
                                areasPlayer[areaX - 1, areaY] = Condition.Ship.ToString();
                            }
                            else if (CanPlaceShip1(areaX + 1, areaY, areasPlayer))
                            {
                                placed = true;
                                int index1 = areaY * 10 + areaX + 100;
                                int index2 = areaY * 10 + areaX + 1 + 100;
                                Button buttonToChange1 = (Button)this.Controls[index1];
                                Button buttonToChange2 = (Button)this.Controls[index2];
                                buttonToChange1.BackColor = System.Drawing.Color.Green;
                                buttonToChange2.BackColor = System.Drawing.Color.Green;
                                areasPlayer[areaX, areaY] = Condition.Ship.ToString();
                                areasPlayer[areaX + 1, areaY] = Condition.Ship.ToString();
                            }
                        }
                        if (direction == 1) //pion
                        {
                            if (CanPlaceShip1(areaX, areaY - 1, areasPlayer))
                            {
                                placed = true;
                                int index1 = areaY * 10 + areaX + 100;
                                int index2 = (areaY - 1) * 10 + areaX + 100;
                                Button buttonToChange1 = (Button)this.Controls[index1];
                                Button buttonToChange2 = (Button)this.Controls[index2];
                                buttonToChange1.BackColor = System.Drawing.Color.Green;
                                buttonToChange2.BackColor = System.Drawing.Color.Green;
                                areasPlayer[areaX, areaY] = Condition.Ship.ToString();
                                areasPlayer[areaX, areaY - 1] = Condition.Ship.ToString();
                            }
                            else if (CanPlaceShip1(areaX, areaY + 1, areasPlayer))
                            {
                                placed = true;
                                int index1 = areaY * 10 + areaX + 100;
                                int index2 = (areaY + 1) * 10 + areaX + 100;
                                Button buttonToChange1 = (Button)this.Controls[index1];
                                Button buttonToChange2 = (Button)this.Controls[index2];
                                buttonToChange1.BackColor = System.Drawing.Color.Green;
                                buttonToChange2.BackColor = System.Drawing.Color.Green;
                                areasPlayer[areaX, areaY] = Condition.Ship.ToString();
                                areasPlayer[areaX, areaY + 1] = Condition.Ship.ToString();

                            }
                        }

                    }

                    //CanPlaceShip2(areaX - 1, areaY, areas);
                }
            }

            //trojki gracz
            for (int i = 0; i < ship3Player.ship3Count; i++)
            {
                placed = false;
                while (!placed)
                {
                    areaX = shipPosition.Next(0, 10);
                    areaY = shipPosition.Next(0, 10);
                    direction = shipDirection.Next(0, 2);//kierunek
                    if (CanPlaceShip1(areaX, areaY, areasPlayer))
                    {
                        if (direction == 0)//poziom
                        {
                            if (CanPlaceShip1(areaX - 2, areaY, areasPlayer))
                            {
                                placed = true;
                                int index1 = areaY * 10 + areaX + 100;
                                int index2 = areaY * 10 + areaX - 1 + 100;
                                int index3 = areaY * 10 + areaX - 2 + 100;
                                Button buttonToChange1 = (Button)this.Controls[index1];
                                Button buttonToChange2 = (Button)this.Controls[index2];
                                Button buttonToChange3 = (Button)this.Controls[index3];
                                buttonToChange1.BackColor = System.Drawing.Color.Green;
                                buttonToChange2.BackColor = System.Drawing.Color.Green;
                                buttonToChange3.BackColor = System.Drawing.Color.Green;
                                areasPlayer[areaX, areaY] = Condition.Ship.ToString();
                                areasPlayer[areaX - 1, areaY] = Condition.Ship.ToString();
                                areasPlayer[areaX - 2, areaY] = Condition.Ship.ToString();
                            }
                            else if (CanPlaceShip1(areaX + 2, areaY, areasPlayer))
                            {
                                placed = true;
                                int index1 = areaY * 10 + areaX + 100;
                                int index2 = areaY * 10 + areaX + 1 + 100;
                                int index3 = areaY * 10 + areaX + 2 + 100;
                                Button buttonToChange1 = (Button)this.Controls[index1];
                                Button buttonToChange2 = (Button)this.Controls[index2];
                                Button buttonToChange3 = (Button)this.Controls[index3];
                                buttonToChange1.BackColor = System.Drawing.Color.Green;
                                buttonToChange2.BackColor = System.Drawing.Color.Green;
                                buttonToChange3.BackColor = System.Drawing.Color.Green;
                                areasPlayer[areaX, areaY] = Condition.Ship.ToString();
                                areasPlayer[areaX + 1, areaY] = Condition.Ship.ToString();
                                areasPlayer[areaX + 2, areaY] = Condition.Ship.ToString();
                            }
                        }
                        if (direction == 1)//pion
                        {
                            if (CanPlaceShip1(areaX, areaY - 2, areasPlayer))
                            {
                                placed = true;
                                int index1 = areaY * 10 + areaX + 100;
                                int index2 = (areaY - 1) * 10 + areaX + 100;
                                int index3 = (areaY - 2) * 10 + areaX + 100;
                                Button buttonToChange1 = (Button)this.Controls[index1];
                                Button buttonToChange2 = (Button)this.Controls[index2];
                                Button buttonToChange3 = (Button)this.Controls[index3];
                                buttonToChange1.BackColor = System.Drawing.Color.Green;
                                buttonToChange2.BackColor = System.Drawing.Color.Green;
                                buttonToChange3.BackColor = System.Drawing.Color.Green;
                                areasPlayer[areaX, areaY] = Condition.Ship.ToString();
                                areasPlayer[areaX, areaY - 1] = Condition.Ship.ToString();
                                areasPlayer[areaX, areaY - 2] = Condition.Ship.ToString();
                            }
                            else if (CanPlaceShip1(areaX, areaY + 2, areasPlayer))
                            {
                                placed = true;
                                int index1 = areaY * 10 + areaX + 100;
                                int index2 = (areaY + 1) * 10 + areaX + 100;
                                int index3 = (areaY + 2) * 10 + areaX + 100;
                                Button buttonToChange1 = (Button)this.Controls[index1];
                                Button buttonToChange2 = (Button)this.Controls[index2];
                                Button buttonToChange3 = (Button)this.Controls[index3];
                                buttonToChange1.BackColor = System.Drawing.Color.Green;
                                buttonToChange2.BackColor = System.Drawing.Color.Green;
                                buttonToChange3.BackColor = System.Drawing.Color.Green;
                                areasPlayer[areaX, areaY] = Condition.Ship.ToString();
                                areasPlayer[areaX, areaY + 1] = Condition.Ship.ToString();
                                areasPlayer[areaX, areaY + 2] = Condition.Ship.ToString();
                            }
                        }
                    }
                }
            }
            //czworki gracz
            for (int i = 0; i < ship4Player.ship4Count; i++)
            {
                placed = false;
                while (!placed)
                {
                    areaX = shipPosition.Next(0, 10);
                    areaY = shipPosition.Next(0, 10);
                    direction = shipDirection.Next(0, 2);//kierunek
                    if (CanPlaceShip1(areaX, areaY, areasPlayer))
                    {
                        if (direction == 0)//poziom
                        {
                            if (CanPlaceShip1(areaX - 3, areaY, areasPlayer))
                            {
                                placed = true;
                                int index1 = areaY * 10 + areaX + 100;
                                int index2 = areaY * 10 + areaX - 1 + 100;
                                int index3 = areaY * 10 + areaX - 2 + 100;
                                int index4 = areaY * 10 + areaX - 3 + 100;
                                Button buttonToChange1 = (Button)this.Controls[index1];
                                Button buttonToChange2 = (Button)this.Controls[index2];
                                Button buttonToChange3 = (Button)this.Controls[index3];
                                Button buttonToChange4 = (Button)this.Controls[index4];
                                buttonToChange1.BackColor = System.Drawing.Color.Green;
                                buttonToChange2.BackColor = System.Drawing.Color.Green;
                                buttonToChange3.BackColor = System.Drawing.Color.Green;
                                buttonToChange4.BackColor = System.Drawing.Color.Green;
                                areasPlayer[areaX, areaY] = Condition.Ship.ToString();
                                areasPlayer[areaX - 1, areaY] = Condition.Ship.ToString();
                                areasPlayer[areaX - 2, areaY] = Condition.Ship.ToString();
                                areasPlayer[areaX - 3, areaY] = Condition.Ship.ToString();
                            }
                            else if (CanPlaceShip1(areaX + 3, areaY, areasPlayer))
                            {
                                placed = true;
                                int index1 = areaY * 10 + areaX + 100;
                                int index2 = areaY * 10 + areaX + 1 + 100;
                                int index3 = areaY * 10 + areaX + 2 + 100;
                                int index4 = areaY * 10 + areaX + 3 + 100;
                                Button buttonToChange1 = (Button)this.Controls[index1];
                                Button buttonToChange2 = (Button)this.Controls[index2];
                                Button buttonToChange3 = (Button)this.Controls[index3];
                                Button buttonToChange4 = (Button)this.Controls[index4];
                                buttonToChange1.BackColor = System.Drawing.Color.Green;
                                buttonToChange2.BackColor = System.Drawing.Color.Green;
                                buttonToChange3.BackColor = System.Drawing.Color.Green;
                                buttonToChange4.BackColor = System.Drawing.Color.Green;
                                areasPlayer[areaX, areaY] = Condition.Ship.ToString();
                                areasPlayer[areaX + 1, areaY] = Condition.Ship.ToString();
                                areasPlayer[areaX + 2, areaY] = Condition.Ship.ToString();
                                areasPlayer[areaX + 3, areaY] = Condition.Ship.ToString();
                            }
                        }
                        if (direction == 1)//pion
                        {
                            if (CanPlaceShip1(areaX, areaY - 3, areasPlayer))
                            {
                                placed = true;
                                int index1 = areaY * 10 + areaX + 100;
                                int index2 = (areaY - 1) * 10 + areaX + 100;
                                int index3 = (areaY - 2) * 10 + areaX + 100;
                                int index4 = (areaY - 3) * 10 + areaX + 100;
                                Button buttonToChange1 = (Button)this.Controls[index1];
                                Button buttonToChange2 = (Button)this.Controls[index2];
                                Button buttonToChange3 = (Button)this.Controls[index3];
                                Button buttonToChange4 = (Button)this.Controls[index4];
                                buttonToChange1.BackColor = System.Drawing.Color.Green;
                                buttonToChange2.BackColor = System.Drawing.Color.Green;
                                buttonToChange3.BackColor = System.Drawing.Color.Green;
                                buttonToChange4.BackColor = System.Drawing.Color.Green;
                                areasPlayer[areaX, areaY] = Condition.Ship.ToString();
                                areasPlayer[areaX, areaY - 1] = Condition.Ship.ToString();
                                areasPlayer[areaX, areaY - 2] = Condition.Ship.ToString();
                                areasPlayer[areaX, areaY - 3] = Condition.Ship.ToString();
                            }
                            else if (CanPlaceShip1(areaX, areaY + 3, areasPlayer))
                            {
                                placed = true;
                                int index1 = areaY * 10 + areaX + 100;
                                int index2 = (areaY + 1) * 10 + areaX + 100;
                                int index3 = (areaY + 2) * 10 + areaX + 100;
                                int index4 = (areaY + 3) * 10 + areaX + 100;
                                Button buttonToChange1 = (Button)this.Controls[index1];
                                Button buttonToChange2 = (Button)this.Controls[index2];
                                Button buttonToChange3 = (Button)this.Controls[index3];
                                Button buttonToChange4 = (Button)this.Controls[index4];
                                buttonToChange1.BackColor = System.Drawing.Color.Green;
                                buttonToChange2.BackColor = System.Drawing.Color.Green;
                                buttonToChange3.BackColor = System.Drawing.Color.Green;
                                buttonToChange4.BackColor = System.Drawing.Color.Green;
                                areasPlayer[areaX, areaY] = Condition.Ship.ToString();
                                areasPlayer[areaX, areaY + 1] = Condition.Ship.ToString();
                                areasPlayer[areaX, areaY + 2] = Condition.Ship.ToString();
                                areasPlayer[areaX, areaY + 3] = Condition.Ship.ToString();
                            }
                        }
                    }
                }
            }
        }
     
        void CreateBotButtons()
        {
            int buttonSize = 25;
            int buttonsPerRow = 10;
            int marginX = 420;
            int marginY = 50;
            int labelPositionX = buttonsPerRow * buttonSize + marginX;
            int labelPositionY = marginY / 2;

            for (int i = 0; i < 100; i++)
            {
                Button btn = new Button();
                btn.Width = buttonSize;
                btn.Height = buttonSize;
                btn.BackColor = System.Drawing.Color.LightBlue;
                int row = i / buttonsPerRow;
                int col = i % buttonsPerRow;
                btn.Left = col * (buttonSize) + marginX;
                btn.Top = row * (buttonSize) + marginY;
                btn.Text = "";
                btn.Tag = i;
                btn.Click += Button_Click;
                this.Controls.Add(btn);
            }
        }
        void PlayerButtons()
        {
            int buttonSize = 25;
            int buttonsPerRow = 10;
            int marginX = 50;
            int marginY = 50;
            int labelPositionX = buttonsPerRow * buttonSize + marginX;
            int labelPositionY = marginY / 2;

            for (int i = 100; i < 200; i++)
            {
                Button btn = new Button();
                btn.Width = buttonSize;
                btn.Height = buttonSize;
                btn.BackColor = System.Drawing.Color.LightBlue;
                int row = (i - 100) / buttonsPerRow;
                int col = (i - 100) % buttonsPerRow;
                btn.Left = col * (buttonSize) + marginX;
                btn.Top = row * (buttonSize) + marginY;
                btn.Text = "";
                btn.Tag = i;
                btn.Click += Button_Click;
                this.Controls.Add(btn);
            }
        }
        void Button_Click(object sender, EventArgs e)
        {
            int positionX, positionY;
            Button clickedButton = (Button)sender;

            if (clickedButton.Tag is int tagValue1 && tagValue1 < 100)
            {
                positionX = tagValue1 % 10;
                positionY = (tagValue1 - positionX) / 10;
                if (areasBot[positionX, positionY] == Condition.Empty.ToString())
                {
                    areasBot[positionX, positionY] = Condition.Blocked.ToString();
                }
                ShipSunk(positionX, positionY);
                MessageBox.Show($"Klikniêto przycisk o indeksie {clickedButton.Tag}");//debug
                AreasColors();
                }         
        }                     
        void ShipSunk(int x, int y)
        {
            if (x >= 0 && x < 10 && y >= 0 && y < 10)
            {

                bool sunk = false; //false oznacza ze jest zatopiony
                if (x > 0)
                {
                    sunk = areasBot[x - 1, y] == Condition.Ship.ToString();
                }
                else if (x < 9)
                {
                    sunk = areasBot[x + 1, y] == Condition.Ship.ToString();
                }
                else if (y > 0)
                {
                    sunk = areasBot[x, y - 1] == Condition.Ship.ToString();
                }
                else if (y < 9)
                {
                    sunk = areasBot[x, y + 1] == Condition.Ship.ToString();
                }

                if(sunk == true) //czyli nie jest
                {
                    areasBot[x, y] = Condition.Hit.ToString();
                }
                else //czyli zatopiony
                {
                    CheckSunkShipElements(x, y);
                }
                
            }

           
        }
        //musze pomyslec
        void CheckSunkShipElements(int x, int y)
        {
            if(x > 0 )
            {
                if (areasBot[x - 1, y] == Condition.Hit.ToString())
                {
                    if (areasBot[x-2, y] == Condition.Hit.ToString())
                    {

                    }
                    areasBot[x - 1, y] = Condition.Sunk.ToString();
                }
            }
            if (x < 9)
            {
                if (areasBot[x + 1, y] == Condition.Hit.ToString())
                {
                    areasBot[x + 1, y] = Condition.Sunk.ToString();
                }
            }
            if(y > 0)
            {
                if (areasBot[x, y - 1] == Condition.Hit.ToString())
                {
                    areasBot[x, y - 1] = Condition.Sunk.ToString();
                }
            }
            if(y < 9)
            {
                if (areasBot[x, y + 1] == Condition.Hit.ToString())
                {
                    areasBot[x, y + 1] = Condition.Sunk.ToString();
                }
            }
            
        }
        void AreasColors()
        {
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    int position = y * 10 + x;                    
                    Button btn = (Button)this.Controls[position];
                    if (areasBot[x, y] == Condition.Hit.ToString())
                    {
                        btn.BackColor = Color.Yellow;
                    }
                    if (areasBot[x,y] == Condition.Sunk.ToString())
                    {
                        btn.BackColor = Color.Red;
                    }
                    if (areasBot[x, y] == Condition.Empty.ToString() || areasBot[x,y] == Condition.Ship.ToString())
                    {
                        btn.BackColor = Color.LightBlue;
                    }
                    if (areasBot[x, y] == Condition.Blocked.ToString())
                    {
                        btn.BackColor= Color.Gray;
                    }


                }
            }
        }
        
        
        bool CanPlaceShip1(int x, int y, string[,] areas)
        {
            if (x >= 0 && x < 10 && y >= 0 && y < 10)
            {
                bool isSafe = areas[x, y] == "Empty";

                if (x > 0) isSafe &= areas[x - 1, y] == "Empty";          
                if (x < 9) isSafe &= areas[x + 1, y] == "Empty";          
                if (y > 0) isSafe &= areas[x, y - 1] == "Empty";          
                if (y < 9) isSafe &= areas[x, y + 1] == "Empty";          
                if (x > 0 && y > 0) isSafe &= areas[x - 1, y - 1] == "Empty"; 
                if (x > 0 && y < 9) isSafe &= areas[x - 1, y + 1] == "Empty"; 
                if (x < 9 && y > 0) isSafe &= areas[x + 1, y - 1] == "Empty"; 
                if (x < 9 && y < 9) isSafe &= areas[x + 1, y + 1] == "Empty"; 
                

                return isSafe;
            }

            return false; // poza granicami
        }
        
    }


    public class Ship
    {
        public int ship1Count = 4;
        public int ship2Count = 3;
        public int ship3Count = 2;
        public int ship4Count = 1;
    }

    public enum Condition 
    { 
       Ship,
       Empty,
       Hit,
       Sunk,
       Blocked
    }
}
