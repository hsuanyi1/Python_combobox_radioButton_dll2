using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Python_combobox_radioButton_dll
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox1.Items.Add(new MyItem("一", "1"));
            comboBox1.Items.Add(new MyItem("二", "2"));
            comboBox1.Items.Add(new MyItem("三", "3"));
            comboBox1.Items.Add(new MyItem("四", "4"));
            comboBox1.Items.Add(new MyItem("五", "5"));

            comboBox2.Items.Add(new MyItem("六", "6"));
            comboBox2.Items.Add(new MyItem("七", "7"));
            comboBox2.Items.Add(new MyItem("八", "8"));
            comboBox2.Items.Add(new MyItem("九", "9"));
            comboBox2.Items.Add(new MyItem("十", "10"));
        }
        struct MyItem
        {
              public MyItem(string displayName, string realValue)
              {
                  DisplayName = displayName;
                  RealValue = realValue;
              }
              public string DisplayName { get; set; }

              public string RealValue { get; set; }

              public override string ToString()
              {
                  return DisplayName;
              }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = ((MyItem)comboBox1.SelectedItem).RealValue;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox2.Text = ((MyItem)comboBox2.SelectedItem).RealValue;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            //label1.ForeColor = Color.Black;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            //label1.ForeColor = Color.Black;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ScriptRuntime pyRuntime = Python.CreateRuntime(); //建立一下執行環境
            dynamic obj = pyRuntime.UseFile("C:/Users/User/Documents/上課用 Pycharm/add/sum.py"); //呼叫一個Python檔案
            int num1 = int.Parse(textBox1.Text);
            int num2 = int.Parse(textBox2.Text);
            int sum = obj.add(num1, num2); //呼叫Python檔案中的求和函式
            int mp = obj.mp(num1, num2); //呼叫Python檔案中的求和函式
            if (radioButton1.Checked)
                label1.Text = sum.ToString();
            else
                label1.Text = mp.ToString();
        }
    }
}