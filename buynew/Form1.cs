namespace buynew
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Welcome");
            Visible = false;
            Form2 form2 = new Form2();
            form2.Visible = true;
        }
    }
}