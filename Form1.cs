using System;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Media;


namespace statki
{
    public partial class Statki : Form
    {
        string[,] areasBot = new string[10, 10];
        string move = "Player";
        string winner;
        string[,] areasPlayer = new string[10, 10];
        List<int> availbleAreana = new List<int>();
        int areaX, areaY, direction, lastHited1, lastHited2, lastHited3;
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
        public Statki()
        {
            lastHited1 = -1;
            InitializeComponent();
            Setup();
            TableImplementation();
            CreateBotButtons();
            PlayerButtons();
            InfoButton();
            GenerateBotShips();
            GeneratePlayerShips();
            GenerateLabels();

        }

        void GenerateLabels()
        {
            Label lblPlayer = new Label();
            lblPlayer.Left = 150;
            lblPlayer.Top = 20;
            lblPlayer.Text = "Gracz";
            this.Controls.Add(lblPlayer);
            Label lblBot = new Label();
            lblBot.Left = 520;
            lblBot.Top = 20;
            lblBot.Text = "Bot";
            this.Controls.Add(lblBot);
        }
        void InfoButton()
        {
            Button infoButton = new Button();
            infoButton.Height = 32;
            infoButton.Width = 85;
            infoButton.Left = 315;
            infoButton.Top = 315;
            infoButton.Text = "Jak graæ?";
            this.Controls.Add(infoButton);
            infoButton.Click += InfoButton_Click;
        }

        private void InfoButton_Click(object? sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }

        void Setup()
        {
            this.Text = "Statki";
            this.Size = new System.Drawing.Size(740, 420);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }
        void TableImplementation()
        {
            int arena;
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    areasBot[x, y] = Condition.Empty.ToString();
                }
            }
            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    areasPlayer[x, y] = Condition.Empty.ToString();
                    arena = y * 10 + x;
                    availbleAreana.Add(arena);
                }
            }
        }

        void GenerateBotShips()
        {
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
                }
            }
            for (int i = 0; i < ship1.ship1Count; i++)
            {
                placed = false;
                while (!placed)
                {
                    areaX = shipPosition.Next(0, 10);
                    areaY = shipPosition.Next(0, 10);
                    if (CanPlaceShip1(areaX, areaY, areasBot))
                    {
                        placed = true;
                        areasBot[areaX, areaY] = Condition.Ship.ToString();
                    }
                }
            }
        }
        void GeneratePlayerShips()
        {
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
                }
            }
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
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderColor = Color.LightGray;
                btn.FlatAppearance.BorderSize = 1;
                btn.FlatAppearance.MouseOverBackColor = Color.DarkBlue;
                btn.Cursor = Cursors.Default;
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
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderColor = Color.LightGray;
                btn.FlatAppearance.BorderSize = 1;
                //btn.FlatAppearance.MouseOverBackColor = null;
                int row = (i - 100) / buttonsPerRow;
                int col = (i - 100) % buttonsPerRow;
                btn.Left = col * (buttonSize) + marginX;
                btn.Top = row * (buttonSize) + marginY;
                btn.Text = "";
                btn.Tag = i;
                this.Controls.Add(btn);
            }
        }
        void Button_Click(object sender, EventArgs e)
        {
            int positionX, positionY;
            Button clickedButton = (Button)sender;

            if (move == "Player" && clickedButton.Tag is int tagValue1 && tagValue1 < 100)
            {
                positionX = tagValue1 % 10;
                positionY = (tagValue1 - positionX) / 10;
                if (areasBot[positionX, positionY] == Condition.Empty.ToString())
                {
                    areasBot[positionX, positionY] = Condition.Blocked.ToString();
                    move = "Bot";
                    BotMove();
                }
                if (areasBot[positionX, positionY] == Condition.Ship.ToString())
                {
                    areasBot[positionX, positionY] = Condition.Hit.ToString();
                    ShipSunkBot(positionX, positionY);
                }
                AreasColors();

            }
        }
        async void BotMove()
        {
            int newIndex, randomIndex;
            bool available = false;
            int index = 0, x = 0, y = 0;
            //Cursor.Current = Cursors.WaitCursor;
            await Task.Delay(500);
            
            int direction1 = Math.Abs(lastHited1 - lastHited2);
            if (winner == null)
            {
                if (lastHited2 == -1 || direction1 == 1 || direction1 == 2)
                {
                    if (lastHited1 != -1)
                    {
                        for (int i = -1; i < 2; i++)
                        {
                            if ((lastHited1 + i) % 10 >= 0 && (lastHited1 + i) % 10 <= 9)
                            {
                                newIndex = lastHited1 + i;

                                available = availbleAreana.Contains(newIndex);
                                if (newIndex / 10 != lastHited1 / 10)
                                {
                                    available = false;
                                }
                                if (available)
                                {
                                    index = newIndex;
                                    x = index % 10;
                                    y = (index - x) / 10;
                                    break;
                                }
                            }
                        }
                        if (!available && lastHited2 != -1)
                        {
                            for (int i = -1; i < 2; i++)
                            {
                                if ((lastHited2 + i) % 10 >= 0 && (lastHited2 + i) % 10 <= 9)
                                {
                                    newIndex = lastHited2 + i;
                                    available = availbleAreana.Contains(newIndex);
                                    if (newIndex / 10 != lastHited2 / 10)
                                    {
                                        available = false;
                                    }
                                    if (available)
                                    {
                                        index = newIndex;
                                        x = index % 10;
                                        y = (index - x) / 10;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
                
                if (lastHited2 == -1 || direction1 == 10 || direction1 == 20)
                {
                    if (!available && lastHited1 != -1)
                    {

                        for (int i = -1; i < 2; i++)
                        {
                            if (lastHited1 + (i * 10) >= 0 && lastHited1 + (i * 10) <= 99)
                            {
                                newIndex = lastHited1 + (i * 10);
                                available = availbleAreana.Contains(newIndex);
                                if (available)
                                {
                                    index = newIndex;
                                    x = index % 10;
                                    y = (index - x) / 10;
                                    break;
                                }
                            }

                        }
                        if (!available && lastHited2 != -1)
                        {
                            for (int i = -1; i < 2; i++)
                            {
                                if (lastHited2 + (i * 10) >= 0 && lastHited2 + (i * 10) <= 99)
                                {
                                    newIndex = lastHited2 + (i * 10);
                                    available = availbleAreana.Contains(newIndex);
                                    if (available)
                                    {
                                        index = newIndex;
                                        x = index % 10;
                                        y = (index - x) / 10;
                                        break;
                                    }
                                }

                            }
                        }
                    }
                }
                
                if (!available)
                {
                    Random random = new Random();
                    randomIndex = random.Next(0, availbleAreana.Count);
                    index = availbleAreana[randomIndex];
                    x = index % 10;
                    y = (index - x) / 10;
                }

                if (areasPlayer[x, y] == Condition.Empty.ToString())
                {
                    areasPlayer[x, y] = Condition.Blocked.ToString();
                    availbleAreana.Remove(index);
                    //Cursor.Current = Cursors.Default;
                    move = "Player";
                }
                else if (areasPlayer[x, y] == Condition.Ship.ToString())
                {
                    areasPlayer[x, y] = Condition.Hit.ToString();
                    lastHited3 = lastHited2;
                    lastHited2 = lastHited1;
                    lastHited1 = index;
                    ShipSunkPlayer(x, y);
                    availbleAreana.Remove(index);
                    BotMove();
                }
                AreasColors();
            }

            
        }
        void ShipSunkBot(int x, int y)
        {
            if (x >= 0 && x < 10 && y >= 0 && y < 10)
            {

                bool sunk = false; //false oznacza ze jest zatopiony

                if (x > 0)
                {
                    if (areasBot[x - 1, y] == Condition.Ship.ToString() || areasBot[x - 1, y] == Condition.Hit.ToString())
                    {
                        sunk = true;
                    }
                }
                if (x < 9 && sunk == false)
                {
                    if (areasBot[x + 1, y] == Condition.Ship.ToString() || areasBot[x + 1, y] == Condition.Hit.ToString())
                    {
                        sunk = true;
                    }
                }
                if (y > 0 && sunk == false)
                {
                    if (areasBot[x, y - 1] == Condition.Ship.ToString() || areasBot[x, y - 1] == Condition.Hit.ToString())
                    {
                        sunk = true;
                    }
                }
                if (y < 9 && sunk == false)
                {
                    if (areasBot[x, y + 1] == Condition.Ship.ToString() || areasBot[x, y + 1] == Condition.Hit.ToString())
                    {
                        sunk = true;
                    }
                }
                if (sunk == false) //zatopiony, jedynka
                {
                    areasBot[x, y] = Condition.Sunk.ToString();
                    BlockAreasBot(x, y);

                }
                else
                {
                    CheckSunkShipElementsBot(x, y);
                }

            }
        }
        void ShipSunkPlayer(int x, int y)
        {
            if (x >= 0 && x < 10 && y >= 0 && y < 10)
            {

                bool sunk = false; //false oznacza ze jest zatopiony

                if (x > 0)
                {
                    if (areasPlayer[x - 1, y] == Condition.Ship.ToString() || areasPlayer[x - 1, y] == Condition.Hit.ToString())
                    {
                        sunk = true;
                    }
                }
                if (x < 9 && sunk == false)
                {
                    if (areasPlayer[x + 1, y] == Condition.Ship.ToString() || areasPlayer[x + 1, y] == Condition.Hit.ToString())
                    {
                        sunk = true;
                    }
                }
                if (y > 0 && sunk == false)
                {
                    if (areasPlayer[x, y - 1] == Condition.Ship.ToString() || areasPlayer[x, y - 1] == Condition.Hit.ToString())
                    {
                        sunk = true;
                    }
                }
                if (y < 9 && sunk == false)
                {
                    if (areasPlayer[x, y + 1] == Condition.Ship.ToString() || areasPlayer[x, y + 1] == Condition.Hit.ToString())
                    {
                        sunk = true;
                    }
                }
                if (sunk == false) //zatopiony, jedynka
                {
                    areasPlayer[x, y] = Condition.Sunk.ToString();
                    BlockAreasPlayer(x, y);
                    lastHited1 = -1;

                }
                else
                {
                    CheckSunkShipElementsPlayer(x, y);
                    
                }

            }


        }
        void CheckSunkShipElementsBot(int x, int y)
        {
            int loops1 = 0;
            int loops2 = 0;
            bool isSunk = false, shipDetected =false;

            if(x > 0 && areasBot[x-1, y] == Condition.Ship.ToString())
            {
                shipDetected = true;
            }
            else
            {
                if (x > 0 && areasBot[x - 1, y] == Condition.Hit.ToString())
                {
                    for (int i = x; i > x - 4; i--)
                    {
                        if (i < 0 || areasBot[i, y] == Condition.Empty.ToString() || areasBot[i, y] == Condition.Blocked.ToString())
                        {
                            break;
                        }
                        if (areasBot[i, y] == Condition.Hit.ToString())
                        {
                            loops1++;
                            isSunk = true;
                        }
                        if (areasBot[i, y] == Condition.Ship.ToString())
                        {
                            loops1 = 0;
                            shipDetected = true;
                            break;
                        }
                    }
                }
                
                if((x < 9 && areasBot[x + 1, y] == Condition.Ship.ToString()) || shipDetected)
                {
                    isSunk = false;
                }
                else
                {
                    if (x < 9 && (areasBot[x + 1, y] == Condition.Hit.ToString()))
                    {
                        for (int i = x; i < x + 4; i++)
                        {
                            if (i > 9 || areasBot[i, y] == Condition.Empty.ToString() || areasBot[i, y] == Condition.Blocked.ToString())
                            {
                                break;
                            }
                            if (areasBot[i, y] == Condition.Hit.ToString())
                            {
                                loops2++;
                                isSunk = true;
                            }
                            if (areasBot[i, y] == Condition.Ship.ToString())
                            {
                                loops2 = 0;
                                isSunk = false;
                                break;
                            }
                        }
                    }
                }
            }
            if (isSunk)
            {

                for (int i = 0; i < loops1; i++)
                {
                    areasBot[x - i, y] = Condition.Sunk.ToString();
                    BlockAreasBot(x - i, y);
                }
                for (int i = 0; i < loops2; i++)
                {
                    areasBot[x + i, y] = Condition.Sunk.ToString();
                    BlockAreasBot(x + i, y);
                }
            }
            loops1 = 0;
            loops2 = 0;
            isSunk = false;
            shipDetected = false;
            if (y > 0 && areasBot[x, y - 1] == Condition.Ship.ToString())
            {
                shipDetected = true;
            }
            else
            {
                if (y > 0 && areasBot[x, y - 1] == Condition.Hit.ToString())
                {
                    for (int i = y; i > y - 4; i--)
                    {
                        if (i < 0 || areasBot[x, i] == Condition.Empty.ToString() || areasBot[x, i] == Condition.Blocked.ToString())
                        {
                            break;
                        }
                        if (areasBot[x, i] == Condition.Hit.ToString())
                        {
                            loops1++;
                            isSunk = true;
                        }
                        if (areasBot[x, i] == Condition.Ship.ToString())
                        {
                            loops1 = 0;
                            shipDetected = true;
                            break;
                        }
                    }
                }
            }
            if((y < 9 && areasBot[x, y + 1] == Condition.Ship.ToString()) || shipDetected)
            {
                isSunk = false;
            }
            else
            {
                if (y < 9 && areasBot[x, y + 1] == Condition.Hit.ToString())
                {
                    for (int i = y; i < y + 4; i++)
                    {
                        if (i > 9 || areasBot[x, i] == Condition.Empty.ToString() || areasBot[x, i] == Condition.Blocked.ToString())
                        {
                            break;
                        }
                        if (areasBot[x, i] == Condition.Hit.ToString())
                        {
                            loops2++;
                            isSunk = true;
                        }
                        if (areasBot[x, i] == Condition.Ship.ToString())
                        {
                            loops1 = 0;
                            loops2 = 0;
                            isSunk = false;
                            break;
                        }
                    }
                }
            }
            
            if (isSunk)
            {

                for (int i = 0; i < loops1; i++)
                {
                    areasBot[x, y - i] = Condition.Sunk.ToString();
                    BlockAreasBot(x, y - i);

                }
                for (int i = 0; i < loops2; i++)
                {
                    areasBot[x, y + i] = Condition.Sunk.ToString();
                    BlockAreasBot(x, y + i);
                }
            }
        }
        void CheckSunkShipElementsPlayer(int x, int y)
        {
            int loops1 = 0;
            int loops2 = 0;
            bool isSunk = false, shipDetected = false;

            if (x > 0 && areasPlayer[x - 1, y] == Condition.Ship.ToString())
            {
                shipDetected = true;
            }
            else
            {
                if (x > 0 && areasPlayer[x - 1, y] == Condition.Hit.ToString())
                {
                    for (int i = x; i > x - 4; i--)
                    {
                        if (i < 0 || areasPlayer[i, y] == Condition.Empty.ToString() || areasPlayer[i, y] == Condition.Blocked.ToString())
                        {
                            break;
                        }
                        if (areasPlayer[i, y] == Condition.Hit.ToString())
                        {
                            loops1++;
                            isSunk = true;
                        }
                        if (areasPlayer[i, y] == Condition.Ship.ToString())
                        {
                            loops1 = 0;
                            shipDetected = true;
                            break;
                        }
                    }
                }

                if ((x < 9 && areasPlayer[x + 1, y] == Condition.Ship.ToString()) || shipDetected)
                {
                    isSunk = false;
                }
                else
                {
                    if (x < 9 && (areasPlayer[x + 1, y] == Condition.Hit.ToString()))
                    {
                        for (int i = x; i < x + 4; i++)
                        {
                            if (i > 9 || areasPlayer[i, y] == Condition.Empty.ToString() || areasPlayer[i, y] == Condition.Blocked.ToString())
                            {
                                break;
                            }
                            if (areasPlayer[i, y] == Condition.Hit.ToString())
                            {
                                loops2++;
                                isSunk = true;
                            }
                            if (areasPlayer[i, y] == Condition.Ship.ToString())
                            {
                                loops2 = 0;
                                isSunk = false;
                                break;
                            }
                        }
                    }
                }
            }
            if (isSunk)
            {
                lastHited1 = -1;
                for (int i = 0; i < loops1; i++)
                {
                    areasPlayer[x - i, y] = Condition.Sunk.ToString();
                    BlockAreasPlayer(x - i, y);
                }
                for (int i = 0; i < loops2; i++)
                {
                    areasPlayer[x + i, y] = Condition.Sunk.ToString();
                    BlockAreasPlayer(x + i, y);
                }
            }
            loops1 = 0;
            loops2 = 0;
            isSunk = false;
            shipDetected = false;
            if (y > 0 && areasPlayer[x, y - 1] == Condition.Ship.ToString())
            {
                shipDetected = true;
            }
            else
            {
                if (y > 0 && areasPlayer[x, y - 1] == Condition.Hit.ToString())
                {
                    for (int i = y; i > y - 4; i--)
                    {
                        if (i < 0 || areasPlayer[x, i] == Condition.Empty.ToString() || areasPlayer[x, i] == Condition.Blocked.ToString())
                        {
                            break;
                        }
                        if (areasPlayer[x, i] == Condition.Hit.ToString())
                        {
                            loops1++;
                            isSunk = true;
                        }
                        if (areasPlayer[x, i] == Condition.Ship.ToString())
                        {
                            loops1 = 0;
                            shipDetected = true;
                            break;
                        }
                    }
                }
            }
            if ((y < 9 && areasPlayer[x, y + 1] == Condition.Ship.ToString()) || shipDetected)
            {
                isSunk = false;
            }
            else
            {
                if (y < 9 && areasPlayer[x, y + 1] == Condition.Hit.ToString())
                {
                    for (int i = y; i < y + 4; i++)
                    {
                        if (i > 9 || areasPlayer[x, i] == Condition.Empty.ToString() || areasPlayer[x, i] == Condition.Blocked.ToString())
                        {
                            break;
                        }
                        if (areasPlayer[x, i] == Condition.Hit.ToString())
                        {
                            loops2++;
                            isSunk = true;
                        }
                        if (areasPlayer[x, i] == Condition.Ship.ToString())
                        {
                            loops1 = 0;
                            loops2 = 0;
                            isSunk = false;
                            break;
                        }
                    }
                }
            }

            if (isSunk)
            {
                lastHited1 = -1;
                for (int i = 0; i < loops1; i++)
                {
                    areasPlayer[x, y - i] = Condition.Sunk.ToString();
                    BlockAreasPlayer(x, y - i);

                }
                for (int i = 0; i < loops2; i++)
                {
                    areasPlayer[x, y + i] = Condition.Sunk.ToString();
                    BlockAreasPlayer(x, y + i);
                }
            }
        }

        void BlockAreasBot(int x, int y)
        {
            if (x < 9 && areasBot[x + 1, y] == Condition.Empty.ToString())
            {
                areasBot[x + 1, y] = Condition.Blocked.ToString();
            }
            if (x > 0 && areasBot[x - 1, y] == Condition.Empty.ToString())
            {
                areasBot[x - 1, y] = Condition.Blocked.ToString();
            }
            if (y < 9 && areasBot[x, y + 1] == Condition.Empty.ToString())
            {
                areasBot[x, y + 1] = Condition.Blocked.ToString();
            }
            if (y > 0 && areasBot[x, y - 1] == Condition.Empty.ToString())
            {
                areasBot[x, y - 1] = Condition.Blocked.ToString();
            }

            if (x < 9 && y < 9 && areasBot[x + 1, y + 1] == Condition.Empty.ToString())
            {
                areasBot[x + 1, y + 1] = Condition.Blocked.ToString();
            }
            if (x > 0 && y < 9 && areasBot[x - 1, y + 1] == Condition.Empty.ToString())
            {
                areasBot[x - 1, y + 1] = Condition.Blocked.ToString();
            }
            if (x < 9 && y > 0 && areasBot[x + 1, y - 1] == Condition.Empty.ToString())
            {
                areasBot[x + 1, y - 1] = Condition.Blocked.ToString();
            }
            if (x > 0 && y > 0 && areasBot[x - 1, y - 1] == Condition.Empty.ToString())
            {
                areasBot[x - 1, y - 1] = Condition.Blocked.ToString();
            }
        }
        void BlockAreasPlayer(int x, int y)
        {
            if (x < 9 && areasPlayer[x + 1, y] == Condition.Empty.ToString())
            {
                areasPlayer[x + 1, y] = Condition.Blocked.ToString();
                availbleAreana.Remove(y * 10 + x + 1);
            }
            if (x > 0 && areasPlayer[x - 1, y] == Condition.Empty.ToString())
            {
                areasPlayer[x - 1, y] = Condition.Blocked.ToString();
                availbleAreana.Remove(y * 10 + x - 1);
            }
            if (y < 9 && areasPlayer[x, y + 1] == Condition.Empty.ToString())
            {
                areasPlayer[x, y + 1] = Condition.Blocked.ToString();
                availbleAreana.Remove((y + 1) * 10 + x);
            }
            if (y > 0 && areasPlayer[x, y - 1] == Condition.Empty.ToString())
            {
                areasPlayer[x, y - 1] = Condition.Blocked.ToString();
                availbleAreana.Remove((y - 1) * 10 + x);
            }

            if (x < 9 && y < 9 && areasPlayer[x + 1, y + 1] == Condition.Empty.ToString())
            {
                areasPlayer[x + 1, y + 1] = Condition.Blocked.ToString();
                availbleAreana.Remove((y + 1) * 10 + x + 1);
            }
            if (x > 0 && y < 9 && areasPlayer[x - 1, y + 1] == Condition.Empty.ToString())
            {
                areasPlayer[x - 1, y + 1] = Condition.Blocked.ToString();
                availbleAreana.Remove((y + 1) * 10 + x - 1);
            }
            if (x < 9 && y > 0 && areasPlayer[x + 1, y - 1] == Condition.Empty.ToString())
            {
                areasPlayer[x + 1, y - 1] = Condition.Blocked.ToString();
                availbleAreana.Remove((y - 1) * 10 + x + 1);
            }
            if (x > 0 && y > 0 && areasPlayer[x - 1, y - 1] == Condition.Empty.ToString())
            {
                areasPlayer[x - 1, y - 1] = Condition.Blocked.ToString();
                availbleAreana.Remove((y - 1) * 10 + x - 1);
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
                    if (areasBot[x, y] == Condition.Sunk.ToString())
                    {
                        btn.BackColor = Color.Red;
                    }
                    if (areasBot[x, y] == Condition.Empty.ToString() || areasBot[x, y] == Condition.Ship.ToString())
                    {
                        btn.BackColor = Color.LightBlue;
                    }
                    if (areasBot[x, y] == Condition.Blocked.ToString())
                    {
                        btn.BackColor = Color.Gray;
                    }


                }
            }
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    int position = y * 10 + x;
                    Button btn = (Button)this.Controls[position + 100];
                    if (areasPlayer[x, y] == Condition.Hit.ToString())
                    {
                        btn.BackColor = Color.Yellow;
                    }
                    if (areasPlayer[x, y] == Condition.Sunk.ToString())
                    {
                        btn.BackColor = Color.Red;
                    }
                    if (areasPlayer[x, y] == Condition.Empty.ToString())
                    {
                        btn.BackColor = Color.LightBlue;
                    }
                    if (areasPlayer[x, y] == Condition.Blocked.ToString())
                    {
                        btn.BackColor = Color.Gray;
                    }
                    if (areasPlayer[x, y] == Condition.Ship.ToString())
                    {
                        btn.BackColor = Color.Green;
                    }

                }
            }
            if (CheckWin())
            {
                int index;
                move = "Koniec";
                
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (areasBot[i, j] == Condition.Ship.ToString())
                        {
                            index = j * 10 + i;
                            Button brn = (Button)this.Controls[index];
                            brn.BackColor = Color.Green;
                        }
                    }
                }
                DialogResult dialogResult = MessageBox.Show($"Wygra³ {winner}" + Environment.NewLine + "Zamkn¹æ program?", "Koniec gry", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    this.Close();
                }
            }

        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogresult = MessageBox.Show("Czy napewno chcesz zamkn¹æ program?", "Zamykanie aplikacji", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogresult == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
        bool CheckWin()
        {
            bool Win = true;
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    if (areasBot[x, y] == Condition.Ship.ToString())
                    {
                        Win = false;
                        break;
                    }
                }
            }
            if (Win)
            {
                winner = "Gracz";
                return Win;
            }
            else
            {
                Win = true;
                for (int x = 0; x < 10; x++)
                {
                    for (int y = 0; y < 10; y++)
                    {
                        if (areasPlayer[x, y] == Condition.Ship.ToString())
                        {
                            Win = false;
                            break;
                        }
                    }
                }
                if (Win)
                {
                    winner = "Bot";
                    return Win;
                }
            }
            return Win;

        }
        private bool CanPlaceShip1(int x, int y, string[,] areas)
        {
            if (x >= 0 && x < 10 && y >= 0 && y < 10)
            {
                bool isSafe = areas[x, y] == Condition.Empty.ToString();

                if (x > 0) isSafe &= areas[x - 1, y] == Condition.Empty.ToString();
                if (x < 9) isSafe &= areas[x + 1, y] == Condition.Empty.ToString();
                if (y > 0) isSafe &= areas[x, y - 1] == Condition.Empty.ToString();
                if (y < 9) isSafe &= areas[x, y + 1] == Condition.Empty.ToString();
                if (x > 0 && y > 0) isSafe &= areas[x - 1, y - 1] == Condition.Empty.ToString();
                if (x > 0 && y < 9) isSafe &= areas[x - 1, y + 1] == Condition.Empty.ToString();
                if (x < 9 && y > 0) isSafe &= areas[x + 1, y - 1] == Condition.Empty.ToString();
                if (x < 9 && y < 9) isSafe &= areas[x + 1, y + 1] == Condition.Empty.ToString();


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
