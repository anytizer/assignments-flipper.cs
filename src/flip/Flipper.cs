using System.Text.RegularExpressions;

namespace AssignmentsFlipper
{
    public partial class Flipper : Form
    {
        public Flipper()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string data = this.textBox1.Text;
            List<string> list = new List<string>();

            string[] lines = data.Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            foreach (string line in lines)
            {
                if (line.Trim().Length > 0)
                {
                    string flipped = this.flip(line);
                    if (flipped != "")
                    {
                        list.Add(flipped);
                    }
                }
            }

            string flips = string.Join("\r\n", list);
            this.textBox1.Text = flips;
        }

        private string flip(string line)
        {
            string flipped = "";
            string[] columns = this.RemoveSingleLineComments(line).Replace(";", "").Split("=");
            if (columns.Length == 2)
            {
                flipped = columns[1].Trim() + " = " + columns[0].Trim() + ";";
            }

            return flipped;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("@anytizer: https://github.com/anytizer", "GitHub Profile");
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = label1.Text;
        }

        private string RemoveSingleLineComments(string input)
        {
            string pattern = @"//.*?$";
            string result = Regex.Replace(input, pattern, "", RegexOptions.Multiline);
            return result;
        }
    }
}
