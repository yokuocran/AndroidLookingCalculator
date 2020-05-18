using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AndroidLookingCalculator
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private string operandOne { get; set; }
        private string operandTwo { get; set; }
        private string operation { get; set; }


        public MainPage()
        {
            InitializeComponent();
        }

        private void Op_Tapped(object sender, EventArgs e)
        {
            var opLbl = sender as Label;

            if (opLbl.Text == "Clear")
                clearAll();
            else
            {
                calculationLbl.Text += opLbl.Text;
                operation = opLbl.Text;
                if (!string.IsNullOrEmpty(displayLbl.Text))
                {
                    operandOne = displayLbl.Text;
                    operandTwo = string.Empty;
                }
            }
        }

        private void numKey_Tapped(object sender, EventArgs e)
        {            
            var lbl = sender as Label;

            if (lbl.Text == "=")
            {
                calculationLbl.Text = displayLbl.Text;
                displayLbl.Text = string.Empty;
            }
            else
            {
                if (string.IsNullOrEmpty(operation))
                    operandOne += lbl.Text;
                else
                    operandTwo += lbl.Text;

                calculationLbl.Text += lbl.Text;

                if (!string.IsNullOrEmpty(operandTwo))
                {
                    Evaluate();
                }
            }
        }

        private void Evaluate()
        {
            string sum = string.Empty;

            try
            {
                var one = int.Parse(operandOne);
                var two = int.Parse(operandTwo);

                switch (operation)
                {
                    case "-":
                        sum = (one - two).ToString();
                        break;
                    case "+":
                        sum = (one + two).ToString();
                        break;
                    case "x":
                        sum = (one * two).ToString();
                        break;
                    case "/":
                        sum = (one / two).ToString();
                        break;
                    case "Clear":
                        clearAll();
                        break;
                    default:
                        sum = "Bad Expression";
                        break;
                }
            }
            catch(Exception ex)
            {
                sum = "Bad Expression";
            }
            finally
            {
                displayLbl.Text = sum;
            }
        }

        private void clearAll()
        {
            displayLbl.Text = string.Empty;
            calculationLbl.Text = string.Empty;
            operandOne = string.Empty;
            operandTwo = string.Empty;
            operation = string.Empty;
        }
    }
}
