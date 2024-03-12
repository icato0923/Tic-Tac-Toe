using System;
using System.Windows.Forms;

namespace Tic_Tac_Toe
{
    public partial class GameScreen : UserControl
    {
        public GameScreen()
        {
            InitializeComponent();
        }

        bool turn = true; //true = player1 turn, false = player2 turn

        int turnCount = 0;

        bool[,] oClicked = new bool[3, 3]
        {
            { false, false, false },
            { false, false, false },
            { false, false, false }
        };

        bool[,] xClicked = new bool[3, 3]
        {
            { false, false, false },
            { false, false, false },
            { false, false, false }
        };

        bool[,] spaceClicked = new bool[3, 3]
        {
            { false, false, false },
            { false, false, false },
            { false, false, false }
        };

        bool playerVsPlayer, playerVsComputer = false;

        bool xWin, oWin, draw = false;

        int oScore, xScore = 0;

        static Random rand = new Random();


        private void GameScreen_Load(object sender, EventArgs e)
        {
            menuScreenGroup.BringToFront();
            menuScreenGroup.Show();
            optionsScreenGroup.Hide();
            gameScreenGroup.Hide();
            player1WinsPicturebox.Hide();
            player2WinsPicturebox.Hide();
            drawPictureBox.Hide();
            playerVsComputer = false;
            playerVsPlayer = false;
            oScore = 0;
            xScore = 0;
            BoardWipe();
        }

        private void optionsScreenBack_Click_1(object sender, EventArgs e)
        {
            menuScreenGroup.BringToFront();
            menuScreenGroup.Show();
            optionsScreenGroup.Hide();
            gameScreenGroup.Hide();
            playerVsPlayer = false;
            playerVsComputer = false;
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            optionsScreenGroup.BringToFront();
            optionsScreenGroup.Show();
            menuScreenGroup.Hide();
            gameScreenGroup.Hide();
        }

        private void gameScreenBack_Click(object sender, EventArgs e)
        {
            optionsScreenGroup.BringToFront();
            optionsScreenGroup.Show();
            menuScreenGroup.Hide();
            gameScreenGroup.Hide();
            BoardWipe();
            playerVsComputer = false;
            playerVsPlayer = false;
            oScore = 0;
            xScore = 0;
            ScoreChange();
        }

        private void reset_Click(object sender, EventArgs e)
        {
            BoardWipe();
        }

        private void playerVsPlayerButton_Click(object sender, EventArgs e)
        {
            gameScreenGroup.BringToFront();
            gameScreenGroup.Show();
            optionsScreenGroup.Hide();
            menuScreenGroup.Hide();
            playerVsPlayer = true;
            playerVsComputer = false;
        }

        private void playerVsComputerButton_Click(object sender, EventArgs e)
        {
            gameScreenGroup.BringToFront();
            gameScreenGroup.Show();
            optionsScreenGroup.Hide();
            menuScreenGroup.Hide();
            playerVsComputer = true;
            playerVsPlayer = false;
        }

        private void button1_1_Click(object sender, EventArgs e)
        {
            if (playerVsPlayer == true && turn == false)
            {
                xClicked[0, 0] = true;
                IfXClicked();

            }

            if (turn == true)
            {
                oClicked[0, 0] = true;
                IfOClicked();
            }

            RunGame();
        }

        private void button1_2_Click(object sender, EventArgs e)
        {
            if (playerVsPlayer == true && turn == false)
            {
                xClicked[0, 1] = true;
                IfXClicked();
            }

            if (turn == true)
            {
                oClicked[0, 1] = true;
                IfOClicked();
            }


            RunGame();
        }

        private void button1_3_Click(object sender, EventArgs e)
        {
            if (playerVsPlayer == true && turn == false)
            {
                xClicked[0, 2] = true;
                IfXClicked();
            }

            if (turn == true)
            {
                oClicked[0, 2] = true;
                IfOClicked();
            }

            RunGame();
        }

        private void button2_1_Click(object sender, EventArgs e)
        {
            if (playerVsPlayer == true && turn == false)
            {
                xClicked[1, 0] = true;
                IfXClicked();
            }

            if (turn == true)
            {
                oClicked[1, 0] = true;
                IfOClicked();
            }

            RunGame();
        }

        private void button2_2_Click(object sender, EventArgs e)
        {
            if (playerVsPlayer == true && turn == false)
            {
                xClicked[1, 1] = true;
                IfXClicked();
            }

            if (turn == true)
            {
                oClicked[1, 1] = true;
                IfOClicked();
            }

            RunGame();
        }

        private void button2_3_Click(object sender, EventArgs e)
        {
            if (playerVsPlayer == true && turn == false)
            {
                xClicked[1, 2] = true;
                IfXClicked();
            }

            if (turn == true)
            {
                oClicked[1, 2] = true;
                IfOClicked();
            }

            RunGame();
        }

        private void button3_1_Click(object sender, EventArgs e)
        {
            if (playerVsPlayer == true && turn == false)
            {
                xClicked[2, 0] = true;
                IfXClicked();
            }

            if (turn == true)
            {
                oClicked[2, 0] = true;
                IfOClicked();
            }

            RunGame();
        }

        private void button3_2_Click(object sender, EventArgs e)
        {
            if (playerVsPlayer == true && turn == false)
            {
                xClicked[2, 1] = true;
                IfXClicked();
            }

            if (turn == true)
            {
                oClicked[2, 1] = true;
                IfOClicked();
            }

            RunGame();
        }

        private void button3_3_Click(object sender, EventArgs e)
        {
            if (playerVsPlayer == true && turn == false)
            {
                xClicked[2, 2] = true;
                IfXClicked();
            }

            if (turn == true)
            {
                oClicked[2, 2] = true;
                IfOClicked();
            }

            RunGame();
        }

        //everytime a button is clicked in game this causes things to happen 
        private void RunGame()
        {
            TurnOpp_TurnCount();

            Computer();

            Player1Win();

            Player2Win();

            NeitherWin();

            WhenWinShowPic();

            WhenGameEnds();

            ScoreChange();

            IfNotTurn();
        }

        //wipes the board of everything 
        private void BoardWipe()
        {
            x1_1.Hide();
            o1_1.Hide();
            button1_1.BringToFront();

            x1_2.Hide();
            o1_2.Hide();
            button1_2.BringToFront();

            x1_3.Hide();
            o1_3.Hide();
            button1_3.BringToFront();

            x2_1.Hide();
            o2_1.Hide();
            button2_1.BringToFront();

            x2_2.Hide();
            o2_2.Hide();
            button2_2.BringToFront();

            x2_3.Hide();
            o2_3.Hide();
            button2_3.BringToFront();

            x3_1.Hide();
            o3_1.Hide();
            button3_1.BringToFront();

            x3_2.Hide();
            o3_3.Hide();
            button3_2.BringToFront();

            x3_3.Hide();
            o3_3.Hide();
            button3_3.BringToFront();

            xClicked[0, 0] = false;
            xClicked[0, 1] = false;
            xClicked[0, 2] = false;
            xClicked[1, 0] = false;
            xClicked[1, 1] = false;
            xClicked[1, 2] = false;
            xClicked[2, 0] = false;
            xClicked[2, 1] = false;
            xClicked[2, 2] = false;

            oClicked[0, 0] = false;
            oClicked[0, 1] = false;
            oClicked[0, 2] = false;
            oClicked[1, 0] = false;
            oClicked[1, 1] = false;
            oClicked[1, 2] = false;
            oClicked[2, 0] = false;
            oClicked[2, 1] = false;
            oClicked[2, 2] = false;

            spaceClicked[0, 0] = false;
            spaceClicked[0, 1] = false;
            spaceClicked[0, 2] = false;
            spaceClicked[1, 0] = false;
            spaceClicked[1, 1] = false;
            spaceClicked[1, 2] = false;
            spaceClicked[2, 0] = false;
            spaceClicked[2, 1] = false;
            spaceClicked[2, 2] = false;


            turn = true;
            turnCount = 0;

            xWin = false;
            oWin = false;
            draw = false;

            player1WinsPicturebox.Hide();
            player2WinsPicturebox.Hide();
            drawPictureBox.Hide();

            WhenGameEnds();
        }

        //when the game ands, disable the buttons on the board and otherwise enable them
        private void WhenGameEnds()
        {
            if ((draw || xWin || oWin) == true)
            {
                button1_1.Enabled = false;
                button1_2.Enabled = false;
                button1_3.Enabled = false;
                button2_1.Enabled = false;
                button2_2.Enabled = false;
                button2_3.Enabled = false;
                button3_1.Enabled = false;
                button3_2.Enabled = false;
                button3_3.Enabled = false;
            }

            if ((draw || xWin || oWin) == false)
            {
                button1_1.Enabled = true;
                button1_2.Enabled = true;
                button1_3.Enabled = true;
                button2_1.Enabled = true;
                button2_2.Enabled = true;
                button2_3.Enabled = true;
                button3_1.Enabled = true;
                button3_2.Enabled = true;
                button3_3.Enabled = true;
            }
        }

        //what the computer should do everytime an o is placed
        private void Computer()
        {

            if (playerVsComputer == true && turn == false)
            {
                if (turnCount == 1 && spaceClicked[1, 1] == false)
                {
                    xClicked[1, 1] = true;
                    TurnOpp_xClick();
                }
                else if (turnCount == 1)
                {
                    XRandomNum();
                    TurnOpp_xClick();
                }
                else
                {
                    if (oClicked[0, 0] && oClicked[0, 1] )
                    {
                        if (spaceClicked[0, 2] == false)
                        {
                            xClicked[0, 2] = true;
                            TurnOpp_xClick();
                            
                        }
                        else
                        {
                            XRandomNum();
                            TurnOpp_xClick();
                            
                        }
                    }
                    else
                    {
                        if (oClicked[0, 1] && oClicked[0, 2] )
                        {
                            if (spaceClicked[0, 0] == false)
                            {
                                xClicked[0, 0] = true;
                                TurnOpp_xClick();
                                
                            }
                            else
                            {
                                XRandomNum();
                                TurnOpp_xClick();
                                
                            }
                        }
                        else
                        {
                            if (oClicked[1, 0] && oClicked[1, 1] )
                            {
                                if (spaceClicked[1, 2] == false)
                                {
                                    xClicked[1, 2] = true;
                                    TurnOpp_xClick();
                                    
                                }
                                else
                                {
                                    XRandomNum();
                                    TurnOpp_xClick();
                                    
                                }
                            }
                            else
                            {
                                if (oClicked[1, 1] && oClicked[1, 2] )
                                {
                                    if (spaceClicked[1, 0] == false)
                                    {
                                        xClicked[1, 0] = true;
                                        TurnOpp_xClick();
                                        
                                    }
                                    else
                                    {
                                        XRandomNum();
                                        TurnOpp_xClick();
                                        
                                    }
                                }
                                else
                                {
                                    if (oClicked[2, 0] && oClicked[2, 1] )
                                    {
                                        if (spaceClicked[2, 2] == false)
                                        {
                                            xClicked[2, 2] = true;
                                            TurnOpp_xClick();
                                            
                                        }
                                        else
                                        {
                                            XRandomNum();
                                            TurnOpp_xClick();
                                            
                                        }
                                    }
                                    else
                                    {
                                        if (oClicked[2, 1] && oClicked[2, 2] )
                                        {
                                            if (spaceClicked[2, 0] == false)
                                            {
                                                xClicked[2, 0] = true;
                                                TurnOpp_xClick();
                                                
                                            }
                                            else
                                            {
                                                XRandomNum();
                                                TurnOpp_xClick();
                                                
                                            }
                                        }
                                        else
                                        {
                                            if (oClicked[0, 0] && oClicked[1, 0] )
                                            {
                                                if (spaceClicked[2, 0] == false)
                                                {
                                                    xClicked[2, 0] = true;
                                                    TurnOpp_xClick();
                                                    
                                                }
                                                else
                                                {
                                                    XRandomNum();
                                                    TurnOpp_xClick();
                                                    
                                                }
                                            }
                                            else
                                            {
                                                if (oClicked[1, 0] && oClicked[2, 0] )
                                                {
                                                    if (spaceClicked[0, 0] == false)
                                                    {
                                                        xClicked[0, 0] = true;
                                                        TurnOpp_xClick();
                                                        
                                                    }
                                                    else
                                                    {
                                                        XRandomNum();
                                                        TurnOpp_xClick();
                                                        
                                                    }
                                                }
                                                else
                                                {
                                                    if (oClicked[0, 1] && oClicked[1, 1] )
                                                    {
                                                        if (spaceClicked[2, 1] == false)
                                                        {
                                                            xClicked[2, 1] = true;
                                                            TurnOpp_xClick();
                                                            
                                                        }
                                                        else
                                                        {
                                                            XRandomNum();
                                                            TurnOpp_xClick();
                                                            
                                                        }

                                                    }
                                                    else
                                                    {
                                                        if (oClicked[1, 1] && oClicked[2, 1] )
                                                        {
                                                            if (spaceClicked[0, 1] == false)
                                                            {
                                                                xClicked[0, 1] = true;
                                                                TurnOpp_xClick();
                                                                
                                                            }
                                                            else
                                                            {
                                                                XRandomNum();
                                                                TurnOpp_xClick();
                                                                
                                                            }
                                                        }
                                                        else
                                                        {
                                                            if (oClicked[0, 2] && oClicked[1, 2] )
                                                            {
                                                                if (spaceClicked[2, 2] == false)
                                                                {
                                                                    xClicked[2, 2] = true;
                                                                    TurnOpp_xClick();
                                                                    
                                                                }
                                                                else
                                                                {
                                                                    XRandomNum();
                                                                    TurnOpp_xClick();
                                                                    
                                                                }
                                                            }
                                                            else
                                                            {
                                                                if (oClicked[1, 2] && oClicked[2, 2] )
                                                                {

                                                                    if (spaceClicked[0, 2] == false)
                                                                    {
                                                                        xClicked[0, 2] = true;
                                                                        TurnOpp_xClick();
                                                                        
                                                                    }
                                                                    else
                                                                    {
                                                                        XRandomNum();
                                                                        TurnOpp_xClick();
                                                                        
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    if (oClicked[0, 0] && oClicked[1, 1] )
                                                                    {
                                                                        if (spaceClicked[2, 2] == false)
                                                                        {
                                                                            xClicked[2, 2] = true;
                                                                            TurnOpp_xClick();
                                                                            
                                                                        }
                                                                        else
                                                                        {
                                                                            XRandomNum();
                                                                            TurnOpp_xClick();
                                                                            
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        if (oClicked[1, 1] && oClicked[2, 2] )
                                                                        {
                                                                            if (spaceClicked[0, 0] == false)
                                                                            {
                                                                                xClicked[0, 0] = true;
                                                                                TurnOpp_xClick();
                                                                                
                                                                            }
                                                                            else
                                                                            {
                                                                                XRandomNum();
                                                                                TurnOpp_xClick();
                                                                                
                                                                            }
                                                                        }
                                                                        else
                                                                        {
                                                                            if (oClicked[2, 0] && oClicked[1, 1] )
                                                                            {
                                                                                if (spaceClicked[0, 2] == false)
                                                                                {
                                                                                    xClicked[0, 2] = true;
                                                                                    TurnOpp_xClick();
                                                                                    
                                                                                }
                                                                                else
                                                                                {
                                                                                    XRandomNum();
                                                                                    TurnOpp_xClick();
                                                                                    
                                                                                }
                                                                            }
                                                                            else
                                                                            {
                                                                                if (oClicked[1, 1] && oClicked[0, 2] )
                                                                                {
                                                                                    if (spaceClicked[2, 0] == false)
                                                                                    {
                                                                                        xClicked[2, 0] = true;
                                                                                        TurnOpp_xClick();
                                                                                        
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        XRandomNum();
                                                                                        TurnOpp_xClick();
                                                                                        
                                                                                    }
                                                                                }
                                                                                else
                                                                                {
                                                                                    XRandomNum();
                                                                                    TurnOpp_xClick();
                                                                                   
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        //if the variable oClicked is true for any of the boxes, the o will be shown
        private void IfOClicked()
        {
            if (oClicked[0, 0] == true)
            {
                spaceClicked[0, 0] = true;
                o1_1.BringToFront();
                o1_1.Show();
            }
            else
            {
                o1_1.Hide();
            }

            if (oClicked[0, 1] == true)
            {
                spaceClicked[0, 1] = true;
                o1_2.BringToFront();
                o1_2.Show();
            }
            else
            {
                o1_2.Hide();
            }

            if (oClicked[0, 2] == true)
            {
                spaceClicked[0, 2] = true;
                o1_3.BringToFront();
                o1_3.Show();
            }
            else
            {
                o1_3.Hide();
            }

            if (oClicked[1, 0] == true)
            {
                spaceClicked[1, 0] = true;
                o2_1.BringToFront();
                o2_1.Show();
            }
            else
            {
                o2_1.Hide();
            }

            if (oClicked[1, 1] == true)
            {
                spaceClicked[1, 1] = true;
                o2_2.BringToFront();
                o2_2.Show();
            }
            else
            {
                o2_2.Hide();
            }

            if (oClicked[1, 2] == true)
            {
                spaceClicked[1, 2] = true;
                o2_3.BringToFront();
                o2_3.Show();
            }
            else
            {
                o2_3.Hide();
            }

            if (oClicked[2, 0] == true)
            {
                spaceClicked[2, 0] = true;
                o3_1.BringToFront();
                o3_1.Show();
            }
            else
            {
                o3_1.Hide();
            }

            if (oClicked[2, 1] == true)
            {
                spaceClicked[2, 1] = true;
                o3_2.BringToFront();
                o3_2.Show();
            }
            else
            {
                o3_2.Hide();
            }

            if (oClicked[2, 2] == true)
            {
                spaceClicked[2, 2] = true;
                o3_3.BringToFront();
                o3_3.Show();
            }
            else
            {
                o3_3.Hide();
            }
        }

        //if the variable xClicked is true for any of the boxes, the x will be shown
        private void IfXClicked()
        {
            if (xClicked[0, 0] == true)
            {
                if (spaceClicked[0, 0] == false)
                {
                    x1_1.BringToFront();
                    x1_1.Show();
                }

                spaceClicked[0, 0] = true;
            }
            else
            {
                x1_1.Hide();
            }

            if (xClicked[0, 1] == true)
            {
                if (spaceClicked[0, 1] == false)
                {
                    x1_2.BringToFront();
                    x1_2.Show();
                }

                spaceClicked[0, 1] = true;
            }
            else
            {
                x1_2.Hide();
            }

            if (xClicked[0, 2] == true)
            {
                if (spaceClicked[0, 2] == false)
                {
                    x1_3.BringToFront();
                    x1_3.Show();
                }

                spaceClicked[0, 2] = true;
            }
            else
            {
                x1_3.Hide();
            }

            if (xClicked[1, 0] == true)
            {
                if (spaceClicked[1, 0] == false)
                {
                    x2_1.BringToFront();
                    x2_1.Show();
                }

                spaceClicked[1, 0] = true;
            }
            else
            {
                x2_1.Hide();
            }

            if (xClicked[1, 1] == true)
            {
                if (spaceClicked[1, 1] == false)
                {
                    x2_2.BringToFront();
                    x2_2.Show();
                }

                spaceClicked[1, 1] = true;
            }
            else
            {
                x2_2.Hide();
            }

            if (xClicked[1, 2] == true)
            {
                if (spaceClicked[1, 2] == false)
                {
                    x2_3.BringToFront();
                    x2_3.Show();
                }

                spaceClicked[1, 2] = true;
            }
            else
            {
                x2_3.Hide();
            }

            if (xClicked[2, 0] == true)
            {
                if (spaceClicked[2, 0] == false)
                {
                    x3_1.BringToFront();
                    x3_1.Show();
                }

                spaceClicked[2, 0] = true;
            }
            else
            {
                x3_1.Hide();
            }

            if (xClicked[2, 1] == true)
            {
                if (spaceClicked[2, 1] == false)
                {
                    x3_2.BringToFront();
                    x3_2.Show();
                }

                spaceClicked[2, 1] = true;
            }
            else
            {
                x3_2.Hide();
            }

            if (xClicked[2, 2] == true)
            {
                if (spaceClicked[2, 2] == false)
                {
                    x3_3.BringToFront();
                    x3_3.Show();
                }

                spaceClicked[2, 2] = true;
            }
            else
            {
                x3_3.Hide();
            }
        }

        //when the o's match up in three in any sequence the win variable is true and the score in increased by one
        private void Player1Win()
        {
            if ((oClicked[0, 0] && oClicked[1, 0] && oClicked[2, 0]) == true)
            {
                oIncScore_WinVar();
            }

            if ((oClicked[0, 1] && oClicked[1, 1] && oClicked[2, 1]) == true)
            {
                oIncScore_WinVar();
            }

            if ((oClicked[0, 2] && oClicked[1, 2] && oClicked[2, 2]) == true)
            {
                oIncScore_WinVar();
            }

            if ((oClicked[0, 0] && oClicked[0, 1] && oClicked[0, 2]) == true)
            {
                oIncScore_WinVar();
            }

            if ((oClicked[1, 0] && oClicked[1, 1] && oClicked[1, 2]) == true)
            {
                oIncScore_WinVar();
            }

            if ((oClicked[2, 0] && oClicked[2, 1] && oClicked[2, 2]) == true)
            {
                oIncScore_WinVar();
            }

            if ((oClicked[0, 0] && oClicked[1, 1] && oClicked[2, 2]) == true)
            {
                oIncScore_WinVar();
            }

            if ((oClicked[2, 0] && oClicked[1, 1] && oClicked[0, 2]) == true)
            {
                oIncScore_WinVar();
            }
        }

        //when the x's match up in three in any sequence the win variable is true and the score in increased by one 
        private void Player2Win()
        {
            if ((xClicked[0, 0] && xClicked[1, 0] && xClicked[2, 0]) == true)
            {
                xIncScore_WinVar();
            }

            if ((xClicked[0, 1] && xClicked[1, 1] && xClicked[2, 1]) == true)
            {
                xIncScore_WinVar();
            }

            if ((xClicked[0, 2] && xClicked[1, 2] && xClicked[2, 2]) == true)
            {
                xIncScore_WinVar();
            }

            if ((xClicked[0, 0] && xClicked[0, 1] && xClicked[0, 2]) == true)
            {
                xIncScore_WinVar();
            }

            if ((xClicked[1, 0] && xClicked[1, 1] && xClicked[1, 2]) == true)
            {
                xIncScore_WinVar();
            }

            if ((xClicked[2, 0] && xClicked[2, 1] && xClicked[2, 2]) == true)
            {
                xIncScore_WinVar();
            }

            if ((xClicked[0, 0] && xClicked[1, 1] && xClicked[2, 2]) == true)
            {
                xIncScore_WinVar();
            }

            if ((xClicked[2, 0] && xClicked[1, 1] && xClicked[0, 2]) == true)
            {
                xIncScore_WinVar();
            }

        }

        //draw variable is true if the board is filled up and oWin and xWin are not true 
        private void NeitherWin()
        {
            if ((turnCount == 9) && (xWin == false) && (oWin == false))
            {
                draw = true;
            }
        }

        //show the pictures that say "player (1 or 2) wins" or "draw" when the variables are true
        private void WhenWinShowPic()
        {
            if (oWin == true)
            {
                player1WinsPicturebox.BringToFront();
                player1WinsPicturebox.Show();
            }

            if (xWin == true)
            {
                player2WinsPicturebox.BringToFront();
                player2WinsPicturebox.Show();

            }

            if (draw == true)
            {
                drawPictureBox.BringToFront();
                drawPictureBox.Show();
            }
        }

        //shows score
        private void ScoreChange()
        {
            oScoreLabel.Text = oScore.ToString();
            xScoreLabel.Text = xScore.ToString();
        }

        //increases turn count and changes turn variable to opposite of what it is
        private void TurnOpp_TurnCount()
        {
            turn = !turn;
            turnCount++;
        }

        //increase score and turn win variable to true for player 1
        private void oIncScore_WinVar()
        {
            oWin = true;
            oScore++;
        }

        //increase score and turn win variable to true for player 2
        private void xIncScore_WinVar()
        {
            xWin = true;
            xScore++;
        }

        //gets a random number for the computer to put the x on a spot on the board
        private void XRandomNum()
        {
            int randomNumber = rand.Next(1, 65);
            rand.Next(1, 65);

            for (int i = 0; i <= randomNumber; i++)
            {
                switch (randomNumber)
                {
                    case 1:
                    case 9:
                    case 17:
                    case 25:
                    case 33:
                    case 41:
                    case 49:
                    case 57:
                        if (spaceClicked[0, 0] == false)
                        {
                            xClicked[0, 0] = true;
                            IfXClicked();
                            rand.Next(1, 65);
                            break;
                        }
                        else
                        {
                            break;
                        }
                    case 2:
                    case 10:
                    case 18:
                    case 26:
                    case 34:
                    case 42:
                    case 50:
                    case 58:
                        if (spaceClicked[0, 1] == false)
                        {
                            xClicked[0, 1] = true;
                            IfXClicked();
                            rand.Next(1, 65);
                            break;
                        }
                        else
                        {
                            break;
                        }
                    case 3:
                    case 11:
                    case 19:
                    case 27:
                    case 35:
                    case 43:
                    case 51:
                    case 59:
                        if (spaceClicked[0, 2] == false)
                        {
                            xClicked[0, 2] = true;
                            IfXClicked();
                            rand.Next(1, 65);
                            break;
                        }
                        else
                        {
                            break;
                        }
                    case 4:
                    case 12:
                    case 20:
                    case 28:
                    case 36:
                    case 44:
                    case 52:
                    case 60:
                        if (spaceClicked[1, 0] == false)
                        {
                            xClicked[1, 0] = true;
                            IfXClicked();
                            rand.Next(1, 65);
                            break;
                        }
                        else
                        {
                            break;
                        }
                    case 5:
                    case 13:
                    case 21:
                    case 29:
                    case 37:
                    case 45:
                    case 53:
                    case 61:
                        if (spaceClicked[1, 2] == false)
                        {
                            xClicked[1, 2] = true;
                            IfXClicked();
                            rand.Next(1, 65);
                            break;
                        }
                        else
                        {
                            break;
                        }
                    case 6:
                    case 14:
                    case 22:
                    case 30:
                    case 38:
                    case 46:
                    case 54:
                    case 62:
                        if (spaceClicked[2, 0] == false)
                        {
                            xClicked[2, 0] = true;
                            IfXClicked();
                            rand.Next(1, 65);
                            break;
                        }
                        else
                        {
                            break;
                        }
                    case 7:
                    case 15:
                    case 23:
                    case 31:
                    case 39:
                    case 47:
                    case 55:
                    case 63:
                        if (spaceClicked[2, 1] == false)
                        {
                            xClicked[2, 1] = true;
                            IfXClicked();
                            rand.Next(1, 65);
                            break;
                        }
                        else
                        {
                            break;
                        }
                    case 8:
                    case 16:
                    case 24:
                    case 32:
                    case 40:
                    case 48:
                    case 56:
                    case 64:
                        if (spaceClicked[2, 2] == false)
                        {
                            xClicked[2, 2] = true;
                            IfXClicked();
                            rand.Next(1, 65);
                            break;
                        }
                        else
                        {
                            break;
                        }
                    default:
                        if (spaceClicked[0, 0] == false)
                        {
                            xClicked[0, 0] = true;
                            IfXClicked();
                            rand.Next(1, 65);
                            break;
                        }
                        else if (spaceClicked[0, 1] == false)
                        {
                            xClicked[0, 1] = true;
                            IfXClicked();
                            rand.Next(1, 65);
                            break;
                        }
                        else if (spaceClicked[0, 2] == false)
                        {
                            xClicked[0, 2] = true;
                            IfXClicked();
                            rand.Next(1, 65);
                            break;
                        }
                        else if (spaceClicked[1, 0] == false)
                        {
                            xClicked[1, 0] = true;
                            IfXClicked();
                            rand.Next(1, 65);
                            break;
                        }
                        else if (spaceClicked[1, 1] == false)
                        {
                            xClicked[1, 1] = true;
                            IfXClicked();
                            rand.Next(1, 65);
                            break;
                        }
                        else if (spaceClicked[1, 2] == false)
                        {
                            xClicked[1, 2] = true;
                            IfXClicked();
                            rand.Next(1, 65);
                            break;
                        }
                        else if (spaceClicked[2, 0] == false)
                        {
                            xClicked[2, 0] = true;
                            IfXClicked();
                            rand.Next(1, 65);
                            break;
                        }
                        else if (spaceClicked[2, 1] == false)
                        {
                            xClicked[2, 1] = true;
                            IfXClicked();
                            rand.Next(1, 65);
                            break;
                        }
                        else if (spaceClicked[2, 2] == false)
                        {
                            xClicked[2, 2] = true;
                            IfXClicked();
                            rand.Next(1, 65);
                            break;
                        }
                        else
                        {
                            break;
                        }
                }
            }
        }

        //does TurnOpp_TurnCount and XClicked methods at the same time 
        private void TurnOpp_xClick()
        {
            IfXClicked();
            TurnOpp_TurnCount();
        }

        //disables buttons for player one in Vs computer mode if it is not their turn
        private void IfNotTurn()
        {

            if (playerVsComputer == true)
            {
                if (turn == true)
                {
                    button1_1.Enabled = true;
                    button1_2.Enabled = true;
                    button1_3.Enabled = true;
                    button2_1.Enabled = true;
                    button2_2.Enabled = true;
                    button2_3.Enabled = true;
                    button3_1.Enabled = true;
                    button3_2.Enabled = true;
                    button3_3.Enabled = true;
                }

                if (turn == false)
                {
                    button1_1.Enabled = false;
                    button1_2.Enabled = false;
                    button1_3.Enabled = false;
                    button2_1.Enabled = false;
                    button2_2.Enabled = false;
                    button2_3.Enabled = false;
                    button3_1.Enabled = false;
                    button3_2.Enabled = false;
                    button3_3.Enabled = false;
                }
            }
        }
    }
}
