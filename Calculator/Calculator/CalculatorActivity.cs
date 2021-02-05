using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calculator
{
    [Activity(Label = "CalculatorActivity")]
    public class CalculatorActivity : Activity
    {
        EditText firstEditText;
        EditText secondEditText;
        TextView answerText;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.calculator_layout);

            firstEditText = FindViewById<EditText>(Resource.Id.firstNumberEditText);
            secondEditText = FindViewById<EditText>(Resource.Id.secondNumberEditText);
            var addButton = FindViewById<Button>(Resource.Id.addButton);
            answerText = FindViewById<TextView>(Resource.Id.answerTextView);

            addButton.Click += AddButton_Click;
            
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            var answer = int.Parse(firstEditText.Text) + int.Parse(secondEditText.Text);
            answerText.Text = answer.ToString();
        }
    }
}