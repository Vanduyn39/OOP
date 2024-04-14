using OOP_CLASS_1;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Vòng_2
{
    public partial class PunchABunch : Form
    {
        private int correctGuesses;
        private int currentGuess;
        private int punchesLeft;
        private int punchesTaken;
        private List<int> prizes;
        private Random random;
        public Vong_BanTayVang vongBanTayVang;

        public PunchABunch(int correctGuesses)
        {
            InitializeComponent();
            this.correctGuesses = correctGuesses;
            this.currentGuess = 0;
            this.punchesLeft = 0;
            this.punchesTaken = 0;
            this.prizes = new List<int>();
            this.random = new Random();
            InitializePrizes();
            DisplayPrizes();
        }

        private void InitializePrizes()
        {
            prize = Vong_BanTayVang.prizevalue;
        }

        private void DisplayPrizes()
        {
            for (int i = 0; i < 50; i++)
            {
                if (prizes[i] == 0)
                {
                    btnPrize[i].Text = "Thêm lượt";
                }
                else
                {
                    btnPrizes[i].Text = prizes[i].ToString("N0");
                }
            }
        }

        private void btnPrizes_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            int index = btnPrizes.ToList().IndexOf(clickedButton);
            if (prizes[index] ==0)
            {
                punchesLeft++;
                DisplayPrizes();
            }
            else
            {
                punchesTaken += prizes[index];
                prizes[index] = 0;
                DisplayPrizes();
            }
            currentGuess++;
            if (currentGuess >= correctGuesses)
            {
                int finalPrize = GetFinalPrize();
                MessageBox.Show($"Bạn đạt được {finalPrize} VND! Thúc đây, trò chơi kết thúc.");
                this.Close();
            }
        }

        private int GetFinalPrize()
        {
            int finalPrize = 0;
            if (punchesTaken < 100000)
            {
                finalPrize = punchesTaken * 2;
            }
            else
            {
                finalPrize = 15000000;
            }
            return finalPrize;
        }
        
    }
}

