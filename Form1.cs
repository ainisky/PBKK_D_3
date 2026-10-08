using System;
using System.Drawing;
using System.Windows.Forms;

namespace kalkulator_tugas_2
{
    public class Form1 : Form
    {
        private TextBox display;

        private double firstNumber = 0;
        private string operation = "";
        private bool newNumber = true;

        public Form1()
        {
            CreateCalculatorUI();
        }

        private void CreateCalculatorUI()
        {
            this.Text = "Kalkulator";
            this.Width = 350;
            this.Height = 500;
            this.StartPosition = FormStartPosition.CenterScreen;

            display = new TextBox();

            display.Text = "0";
            display.Font = new Font("Arial", 24);
            display.TextAlign = HorizontalAlignment.Right;
            display.ReadOnly = true;

            display.Width = 290;
            display.Height = 50;
            display.Location = new Point(20, 20);

            this.Controls.Add(display);

            // Tombol
            string[,] buttons =
            {
                { "7", "8", "9", "/" },
                { "4", "5", "6", "*" },
                { "1", "2", "3", "-" },
                { "0", "C", "=", "+" }
            };

            int startX = 20;
            int startY = 100;

            int buttonWidth = 65;
            int buttonHeight = 60;
            int gap = 10;

            for (int row = 0; row < 4; row++)
            {
                for (int col = 0; col < 4; col++)
                {
                    Button button = new Button();

                    button.Text = buttons[row, col];

                    button.Font = new Font("Arial", 16);

                    button.Width = buttonWidth;
                    button.Height = buttonHeight;

                    button.Location = new Point(
                        startX + col * (buttonWidth + gap),
                        startY + row * (buttonHeight + gap)
                    );

                    button.Click += Button_Click;

                    this.Controls.Add(button);
                }
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            string value = button.Text;

            if (double.TryParse(value, out _))
            {
                if (display.Text == "0" || newNumber)
                {
                    display.Text = value;
                    newNumber = false;
                }
                else
                {
                    display.Text += value;
                }
            }

            else if (value == "+" ||
                     value == "-" ||
                     value == "*" ||
                     value == "/")
            {
                firstNumber = double.Parse(display.Text);

                operation = value;

                newNumber = true;
            }

            else if (value == "=")
            {
                double secondNumber = double.Parse(display.Text);

                double result = 0;

                switch (operation)
                {
                    case "+":
                        result = firstNumber + secondNumber;
                        break;

                    case "-":
                        result = firstNumber - secondNumber;
                        break;

                    case "*":
                        result = firstNumber * secondNumber;
                        break;

                    case "/":

                        if (secondNumber == 0)
                        {
                            MessageBox.Show(
                                "Tidak dapat membagi dengan 0!",
                                "Error"
                            );

                            return;
                        }

                        result = firstNumber / secondNumber;
                        break;
                }

                display.Text = result.ToString();

                newNumber = true;
            }

            else if (value == "C")
            {
                display.Text = "0";

                firstNumber = 0;

                operation = "";

                newNumber = true;
            }
        }
    }
}