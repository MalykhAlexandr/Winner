using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Football;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        FootballDto GetModelFromUI()
        {
            return new FootballDto()
            {
                Filled = dateTimePicker1.Value,
                FullName = maskedTextBox1.Text,
                Citizenship = maskedTextBox2.Text,
                Age = (int)numericUpDown1.Value,
                Height = (int)numericUpDown2.Value,
                Weight = (int)numericUpDown3.Value,
                AgeStartCareer = (int)numericUpDown4.Value,
                ExperienceInFootball = (int)numericUpDown5.Value,
            };
        }

        private void SetModelToUI(FootballDto dto)
        {
            dateTimePicker1.Value = dto.Filled;
            maskedTextBox1.Text = dto.FullName;
            maskedTextBox2.Text = dto.Citizenship;
            numericUpDown1.Value = dto.Age;
            numericUpDown2.Value = dto.Height;
            numericUpDown3.Value = dto.Weight;
            numericUpDown4.Value = dto.AgeStartCareer;
            numericUpDown5.Value = dto.ExperienceInFootball;
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            var sfd = new SaveFileDialog() { Filter = "Файлы заявки|*.ftb" };
            var result = sfd.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                var dto = GetModelFromUI();
                Helper.WriteToFile(sfd.FileName, dto);
            }
        }

        private void button2_Click_1(object sender, System.EventArgs e)
        {
            var ofd = new OpenFileDialog() { Filter = "Файл заявки|*.ftb" };
            var result = ofd.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                var dto = Helper.LoadFromFile(ofd.FileName);
                SetModelToUI(dto);
            }
        }

        private void button3_Click_1(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}