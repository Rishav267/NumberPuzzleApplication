using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NumberPuzzleApplication
{
    public class PuzzleControl
    {
        #region Fields of the class
        Random rnd= new Random();
        #endregion

        /// <summary>
        /// Method to generate a random number
        /// </summary>
        /// <returns></returns>
        private int GetRandomNumber()
        {   
            return rnd.Next(17);
        }

        /// <summary>
        /// Method to change the value of the button when clicked
        /// </summary>
        /// <param name="emptyButton"></param>
        /// <param name="clicked"></param>
        private void SwapButton(Button emptyButton, Button clicked)
        {
            emptyButton.Text = clicked.Text;
            clicked.Text = "";
        }
        
        /// <summary>
        /// Method to get an array of integers for the buttons on the grid
        /// </summary>
        /// <param name="buttons"></param>
        /// <returns></returns>
        private int[] GetIntegerArrayOfButtonIds(Button[] buttons)
        {
            int[] buttonIds = new int[16];
            int id;
            for (int i = 0; i < 16; ++i)
            {
                if (int.TryParse(buttons[i].Text, out id))
                    buttonIds[i] = id;
                else
                    buttonIds[i] = 16;
                Console.Write(id);
            }
            return buttonIds;
        }

        
        //----------------------Public Methods to be filled by the participant------------


        /// <summary>
        /// Method to get random numbers to be displayed on the grid
        /// </summary>
        /// <returns></returns>
        public int[] GetRandomNumbersForGrid()
        {
            int[] arr = new int[16];

            //Logic to be filled by the participant
            int[] vis = new int[17];


            for (int i = 0; i < 16; i++)
            {
                while (true)
                {
                    int randomval = GetRandomNumber();
                    if (vis[randomval] == 1)
                        continue;
                    vis[randomval] = 1;
                    arr[i] = randomval;
                    break;
                }


            }
            //ArrayList array = new ArrayList();
            //int max = 15;
            //Random rand = new Random();
            //int count = 0;
            ////int num = rand.Next(1,max+1);
            //int num = GetRandomNumber();
            //if(num>0 && num<16)
            //    array.Add(num);
            //do
            //{
            //    //num = rand.Next(1, max+1);
            //    num = GetRandomNumber();
            //    if (num > 0 && num < 16 && !array.Contains(num))
            //    {
            //        array.Add(num);
            //    }
            //    count++;
            //    if (array.Count == 15)
            //        break;
            //} while (count < 6 * max);

            ////array.Add("");
            //array.CopyTo(arr);

            return arr;
        }

        /// <summary>
        /// Method to swap the buttons when a number is clicked on the grid
        /// </summary>
        /// <param name="emptyCellId"></param>
        /// <param name="buttonClicked"></param>
        /// <param name="buttons"></param>
        /// <returns></returns>
        public int HandleButtonClicked(int emptyCellId, Button buttonClicked, Button[] buttons)
        {

            //Logic to be filled by the participant

            int index = -1;
            for (int i = 0; i < 16; i++)
                if (buttons[i] == buttonClicked)
                {
                    index = i;
                    break;
                }

            int a = index - 1;
            int b = index + 1;
            int c = index + 4;
            int d = index - 4;
            if (a >= 0 && (a / 4 == index / 4) && a == emptyCellId)
            {
                SwapButton(buttons[emptyCellId], buttonClicked);
                emptyCellId = index;
                return emptyCellId;
            }

            if (b <= 15 && (b / 4 == index / 4) && b == emptyCellId)
            {
                SwapButton(buttons[emptyCellId], buttonClicked);
                emptyCellId = index;
                return emptyCellId;
            }
            if (c <= 15 && c / 4 - index / 4 == 1 && c == emptyCellId)
            {
                SwapButton(buttons[emptyCellId], buttonClicked);
                emptyCellId = index;
                return emptyCellId;

            }
            if (d >= 0 && index / 4 - d / 4 == 1 && d == emptyCellId)
            {
                SwapButton(buttons[emptyCellId], buttonClicked);
                emptyCellId = index;
                return emptyCellId;
            }
            //if (buttons[emptyCellId].Text == "0")
            //    buttons[emptyCellId].Text = "";
            //if (buttonClicked.TabIndex == emptyCellId -1 || buttonClicked.TabIndex == emptyCellId-4 ||
            //    buttonClicked.TabIndex == emptyCellId+1 || buttonClicked.TabIndex == emptyCellId+4)
            //{
            //    //buttons[6].TabIndex;
            //    SwapButton(buttons[emptyCellId], buttonClicked);
            //}


            return emptyCellId;
        }

        /// <summary>
        /// Method to check for a winner of the game
        /// </summary>
        /// <param name="buttons"></param>
        /// <returns></returns>
        public bool CheckForWinner(Button[] buttons)
        {
            bool winner = true;

            //Logic to be filled by the participant

            int[] arr = GetIntegerArrayOfButtonIds(buttons);
            for (int i = 0; i < 15; i++)
            {
                if (arr[i] != i + 1)
                {
                    winner = false;
                    break;
                }
            }
            //for(int i=0;i<16;i++)
            //{
            //    if (string.Compare(buttons[i].Text, buttons[i + 1].Text) <= 0)
            //        return false;

            //}
            return winner;
        }


    }
}
