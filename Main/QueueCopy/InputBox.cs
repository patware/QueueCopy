using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QueueCopy
{
    public partial class InputBox : Form
    {
        public string ReturnValue = "";
        private bool _isMultiline = false;

        public bool IsMultiline
        {
            get { return _isMultiline; }
            set { 
                _isMultiline = value;
                textBox1.Multiline = _isMultiline;
                textBox1.AcceptsReturn = _isMultiline;
                textBox1.AcceptsTab = _isMultiline;
                if (_isMultiline)
                {
                    this.Height = 512;
                }
                else
                {
                    this.Height = 121;
                }

            }
        }

        public InputBox()
        {
            InitializeComponent();
        }

        public InputBox(string message)
            : this()
        {
            label1.Text = message;
        }

        public InputBox(string message, string defaultValue)
            : this(message)
        {
            textBox1.Text = defaultValue;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ReturnValue = textBox1.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
    }
}