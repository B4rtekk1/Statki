using System;
using System.Windows.Forms;
using System.Drawing;

/*Sprawdzanie czy moze byc dwojka, trojka, czworka - generowanie statkow bota
 * losowe generownaie statkow gracza lub mozliwosc wyboru polozenia
 */

namespace statki
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CreateBotButtons();
            PlayerButtons();
            GenerateLabels();
            //CreateBotButtons();
            int areaX, areaY, direction, previousPlace;
            bool placed;
            string[,] areas = new string[10, 10];
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    areas[x, y] = "Empty";
                }
            }
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

            //jedynki bot
            for (int i = 0; i < ship1.ship1Count; i++)
            {
                placed = false;
                while (!placed)
                {
                    areaX = shipPosition.Next(0, 10);
                    areaY = shipPosition.Next(0, 10);
                    //CanPlaceShip(areaX, areaY, areas);
                    if (CanPlaceShip1(areaX, areaY, areas))
                    {
                        placed = true;
                        int index = areaY * 10 + areaX;
                        Button buttonToChange = (Button)this.Controls[index];
                        buttonToChange.BackColor = System.Drawing.Color.Red;
                        areas[areaX, areaY] = Condition.Ship.ToString();


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
                    if (CanPlaceShip1(areaX, areaY, areas))
                    {
                        if (direction == 0)//poziom
                        {
                            if (CanPlaceShip1(areaX - 1, areaY, areas))
                            {
                                placed = true;
                                int index1 = areaY * 10 + areaX;
                                int index2 = areaY * 10 + areaX - 1;
                                Button buttonToChange1 = (Button)this.Controls[index1];
                                Button buttonToChange2 = (Button)this.Controls[index2];
                                buttonToChange1.BackColor = System.Drawing.Color.Red;
                                buttonToChange2.BackColor = System.Drawing.Color.Red;
                                areas[areaX, areaY] = Condition.Ship.ToString();
                                areas[areaX - 1, areaY] = Condition.Ship.ToString();
                            }
                            else if (CanPlaceShip1(areaX + 1, areaY, areas))
                            {
                                placed = true;
                                int index1 = areaY * 10 + areaX;
                                int index2 = areaY * 10 + areaX + 1;
                                Button buttonToChange1 = (Button)this.Controls[index1];
                                Button buttonToChange2 = (Button)this.Controls[index2];
                                buttonToChange1.BackColor = System.Drawing.Color.Red;
                                buttonToChange2.BackColor = System.Drawing.Color.Red;
                                areas[areaX, areaY] = Condition.Ship.ToString();
                                areas[areaX + 1, areaY] = Condition.Ship.ToString();
                            }
                        }
                        if (direction == 1) //pion
                        {
                            if (CanPlaceShip1(areaX, areaY - 1, areas))
                            {
                                placed = true;
                                int index1 = areaY * 10 + areaX;
                                int index2 = (areaY - 1) * 10 + areaX;
                                Button buttonToChange1 = (Button)this.Controls[index1];
                                Button buttonToChange2 = (Button)this.Controls[index2];
                                buttonToChange1.BackColor = System.Drawing.Color.Red;
                                buttonToChange2.BackColor = System.Drawing.Color.Red;
                                areas[areaX, areaY] = Condition.Ship.ToString();
                                areas[areaX, areaY - 1] = Condition.Ship.ToString();
                            }
                            else if (CanPlaceShip1(areaX, areaY + 1, areas))
                            {
                                placed = true;
                                int index1 = areaY * 10 + areaX;
                                int index2 = (areaY + 1) * 10 + areaX;
                                Button buttonToChange1 = (Button)this.Controls[index1];
                                Button buttonToChange2 = (Button)this.Controls[index2];
                                buttonToChange1.BackColor = System.Drawing.Color.Red;
                                buttonToChange2.BackColor = System.Drawing.Color.Red;
                                areas[areaX, areaY] = Condition.Ship.ToString();
                                areas[areaX, areaY + 1] = Condition.Ship.ToString();

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
                    if (CanPlaceShip1(areaX, areaY, areas))
                    {
                        if (direction == 0)//poziom
                        {
                            if (CanPlaceShip1(areaX - 2, areaY, areas))
                            {
                                placed = true;
                                int index1 = areaY * 10 + areaX;
                                int index2 = areaY * 10 + areaX - 1;
                                int index3 = areaY * 10 + areaX - 2;
                                Button buttonToChange1 = (Button)this.Controls[index1];
                                Button buttonToChange2 = (Button)this.Controls[index2];
                                Button buttonToChange3 = (Button)this.Controls[index3];
                                buttonToChange1.BackColor = System.Drawing.Color.Red;
                                buttonToChange2.BackColor = System.Drawing.Color.Red;
                                buttonToChange3.BackColor = System.Drawing.Color.Red;
                                areas[areaX, areaY] = Condition.Ship.ToString();
                                areas[areaX - 1, areaY] = Condition.Ship.ToString();
                                areas[areaX - 2, areaY] = Condition.Ship.ToString();
                            }
                            else if (CanPlaceShip1(areaX + 2, areaY, areas))
                            {
                                placed = true;
                                int index1 = areaY * 10 + areaX;
                                int index2 = areaY * 10 + areaX + 1;
                                int index3 = areaY * 10 + areaX + 2;
                                Button buttonToChange1 = (Button)this.Controls[index1];
                                Button buttonToChange2 = (Button)this.Controls[index2];
                                Button buttonToChange3 = (Button)this.Controls[index3];
                                buttonToChange1.BackColor = System.Drawing.Color.Red;
                                buttonToChange2.BackColor = System.Drawing.Color.Red;
                                buttonToChange3.BackColor = System.Drawing.Color.Red;
                                areas[areaX, areaY] = Condition.Ship.ToString();
                                areas[areaX + 1, areaY] = Condition.Ship.ToString();
                                areas[areaX + 2, areaY] = Condition.Ship.ToString();
                            }
                        }
                        if (direction == 1)//pion
                        {
                            if (CanPlaceShip1(areaX, areaY - 2, areas))
                            {
                                placed = true;
                                int index1 = areaY * 10 + areaX;
                                int index2 = (areaY - 1) * 10 + areaX;
                                int index3 = (areaY - 2) * 10 + areaX;
                                Button buttonToChange1 = (Button)this.Controls[index1];
                                Button buttonToChange2 = (Button)this.Controls[index2];
                                Button buttonToChange3 = (Button)this.Controls[index3];
                                buttonToChange1.BackColor = System.Drawing.Color.Red;
                                buttonToChange2.BackColor = System.Drawing.Color.Red;
                                buttonToChange3.BackColor = System.Drawing.Color.Red;
                                areas[areaX, areaY] = Condition.Ship.ToString();
                                areas[areaX, areaY - 1] = Condition.Ship.ToString();
                                areas[areaX, areaY - 2] = Condition.Ship.ToString();
                            }
                            else if (CanPlaceShip1(areaX, areaY + 2, areas))
                            {
                                placed = true;
                                int index1 = areaY * 10 + areaX;
                                int index2 = (areaY + 1) * 10 + areaX;
                                int index3 = (areaY + 2) * 10 + areaX;
                                Button buttonToChange1 = (Button)this.Controls[index1];
                                Button buttonToChange2 = (Button)this.Controls[index2];
                                Button buttonToChange3 = (Button)this.Controls[index3];
                                buttonToChange1.BackColor = System.Drawing.Color.Red;
                                buttonToChange2.BackColor = System.Drawing.Color.Red;
                                buttonToChange3.BackColor = System.Drawing.Color.Red;
                                areas[areaX, areaY] = Condition.Ship.ToString();
                                areas[areaX, areaY + 1] = Condition.Ship.ToString();
                                areas[areaX, areaY + 2] = Condition.Ship.ToString();
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
                    if (CanPlaceShip1(areaX, areaY, areas))
                    {
                        if (direction == 0)//poziom
                        {
                            if (CanPlaceShip1(areaX - 3, areaY, areas))
                            {
                                placed = true;
                                int index1 = areaY * 10 + areaX;
                                int index2 = areaY * 10 + areaX - 1;
                                int index3 = areaY * 10 + areaX - 2;
                                int index4 = areaY * 10 + areaX - 3;
                                Button buttonToChange1 = (Button)this.Controls[index1];
                                Button buttonToChange2 = (Button)this.Controls[index2];
                                Button buttonToChange3 = (Button)this.Controls[index3];
                                Button buttonToChange4 = (Button)this.Controls[index4];
                                buttonToChange1.BackColor = System.Drawing.Color.Red;
                                buttonToChange2.BackColor = System.Drawing.Color.Red;
                                buttonToChange3.BackColor = System.Drawing.Color.Red;
                                buttonToChange4.BackColor = System.Drawing.Color.Red;
                                areas[areaX, areaY] = Condition.Ship.ToString();
                                areas[areaX - 1, areaY] = Condition.Ship.ToString();
                                areas[areaX - 2, areaY] = Condition.Ship.ToString();
                                areas[areaX - 3, areaY] = Condition.Ship.ToString();
                            }
                            else if (CanPlaceShip1(areaX + 3, areaY, areas))
                            {
                                placed = true;
                                int index1 = areaY * 10 + areaX;
                                int index2 = areaY * 10 + areaX + 1;
                                int index3 = areaY * 10 + areaX + 2;
                                int index4 = areaY * 10 + areaX + 3;
                                Button buttonToChange1 = (Button)this.Controls[index1];
                                Button buttonToChange2 = (Button)this.Controls[index2];
                                Button buttonToChange3 = (Button)this.Controls[index3];
                                Button buttonToChange4 = (Button)this.Controls[index4];
                                buttonToChange1.BackColor = System.Drawing.Color.Red;
                                buttonToChange2.BackColor = System.Drawing.Color.Red;
                                buttonToChange3.BackColor = System.Drawing.Color.Red;
                                buttonToChange4.BackColor = System.Drawing.Color.Red;
                                areas[areaX, areaY] = Condition.Ship.ToString();
                                areas[areaX + 1, areaY] = Condition.Ship.ToString();
                                areas[areaX + 2, areaY] = Condition.Ship.ToString();
                                areas[areaX + 3, areaY] = Condition.Ship.ToString();
                            }
                        }
                        if (direction == 1)//pion
                        {
                            if (CanPlaceShip1(areaX, areaY - 3, areas))
                            {
                                placed = true;
                                int index1 = areaY * 10 + areaX;
                                int index2 = (areaY - 1) * 10 + areaX;
                                int index3 = (areaY - 2) * 10 + areaX;
                                int index4 = (areaY - 3) * 10 + areaX;
                                Button buttonToChange1 = (Button)this.Controls[index1];
                                Button buttonToChange2 = (Button)this.Controls[index2];
                                Button buttonToChange3 = (Button)this.Controls[index3];
                                Button buttonToChange4 = (Button)this.Controls[index4];
                                buttonToChange1.BackColor = System.Drawing.Color.Red;
                                buttonToChange2.BackColor = System.Drawing.Color.Red;
                                buttonToChange3.BackColor = System.Drawing.Color.Red;
                                buttonToChange4.BackColor = System.Drawing.Color.Red;
                                areas[areaX, areaY] = Condition.Ship.ToString();
                                areas[areaX, areaY - 1] = Condition.Ship.ToString();
                                areas[areaX, areaY - 2] = Condition.Ship.ToString();
                                areas[areaX, areaY - 3] = Condition.Ship.ToString();
                            }
                            else if (CanPlaceShip1(areaX, areaY + 3, areas))
                            {
                                placed = true;
                                int index1 = areaY * 10 + areaX;
                                int index2 = (areaY + 1) * 10 + areaX;
                                int index3 = (areaY + 2) * 10 + areaX;
                                int index4 = (areaY + 3) * 10 + areaX;
                                Button buttonToChange1 = (Button)this.Controls[index1];
                                Button buttonToChange2 = (Button)this.Controls[index2];
                                Button buttonToChange3 = (Button)this.Controls[index3];
                                Button buttonToChange4 = (Button)this.Controls[index4];
                                buttonToChange1.BackColor = System.Drawing.Color.Red;
                                buttonToChange2.BackColor = System.Drawing.Color.Red;
                                buttonToChange3.BackColor = System.Drawing.Color.Red;
                                buttonToChange3.BackColor = System.Drawing.Color.Red;
                                areas[areaX, areaY] = Condition.Ship.ToString();
                                areas[areaX, areaY + 1] = Condition.Ship.ToString();
                                areas[areaX, areaY + 2] = Condition.Ship.ToString();
                                areas[areaX, areaY + 3] = Condition.Ship.ToString();
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
                //btn.Click += Button_Click;
                this.Controls.Add(btn);
            }
        }
        void GenerateLabels()
        {

        }
        void Button_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            MessageBox.Show($"Klikniêto przycisk {clickedButton.Text}");
        }
        void Setup()
        {

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
