﻿using knapsackEvolutionALgorithm.Service.Common;
using knapsackEvolutionALgorithm.Service.Entities;
using knapsackEvolutionALgorithm.Service.Services.LocalServcies;
using System;
using System.Timers;
using System.Windows.Forms;

namespace knapsackEvolutionALgorithm
{
    public partial class Form1 : Form
    {
        private readonly System.Timers.Timer _timer;
        private decimal _timeCount;
        public Form1()
        {
            InitializeComponent();

            _timer = new System.Timers.Timer();
            _timer.Interval = 10;
            _timer.Elapsed += Timer_Elapsed;
        }

        private async void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            _timeCount = int.Parse(ExcutedTimeTextBox.Text);
            _timeCount++;
            if(ExcutedTimeTextBox.InvokeRequired)
            {
                ExcutedTimeTextBox.Invoke(new MethodInvoker(delegate 
                {
                    ExcutedTimeTextBox.Text = _timeCount.ToString();
                }));
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private async void Run_Click(object sender, EventArgs e)
        {
            maximumChildsTextBox.Text = "";
            if (Validation())
            { MessageBox.Show("تمامی آیتم های ورودی رو وارد کنید", "", MessageBoxButtons.OK); return; }
            var gettingStarted = new GettingStarted(
                    int.Parse(CapacityTextBox.Text),
                    int.Parse(EarlyPopulationTextBox.Text),
                    int.Parse(NumberOfParentsTextBox.Text),
                    int.Parse(NumberOfGenerationRepetitionsTextBox.Text),
                    ItemsTextBox1.Text.ConvertToItemList()
             );
            var evaluationTrain = new EvaluationTrain(gettingStarted);
            evaluationTrain.MaximumChildChanged += EvaluationTrain_MaximumChildChanged;

            _timer.Start();
            Run.Enabled = false;
            await evaluationTrain.DoTrain();
            _timer.Stop();
            MessageBox.Show($"Fitness: {evaluationTrain.ExcetedFitness}\n");
            ExcutedTimeTextBox.Text = "0";
            Run.Enabled = true;
        }

        private void EvaluationTrain_MaximumChildChanged(Individual maximumChild, int Try)
        {
            if (maximumChildsTextBox.InvokeRequired)
            {
                maximumChildsTextBox.Invoke(new MethodInvoker(delegate
                {
                    maximumChildsTextBox.Text += $"\nChoose Fitness: {maximumChild.Fitness}  try: {Try}";
                }));
            }
        }

        private void EarlyPopulationTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void ExcutedTimeTextBox_Click(object sender, EventArgs e)
        {

        }

        private bool Validation()
        {
            if (CapacityTextBox.Text == "" || EarlyPopulationTextBox.Text == ""
                || NumberOfParentsTextBox.Text == ""
                || NumberOfGenerationRepetitionsTextBox.Text == ""
                || ItemsTextBox1.Text == "")
                return true;
            return false;
        }

        private void label6_Click_1(object sender, EventArgs e)
        {

        }
    }
}
