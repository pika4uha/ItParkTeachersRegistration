using ItParkTeachersRegistration.DataBase;
using ItParkTeachersRegistration.DataBase.Entities;
namespace ItParkTeachersRegistration
{
    public partial class Form1 : Form
    {
        private DbManager _dbManager = new DbManager();

        public Form1()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            bool isCorrect = true;

            string name = textBoxName.Text;
            if (name.Length < 1 || name.Length > 128)
            {
                isCorrect = false;
                MessageBox.Show("������� ���");
            }

            string pass = textBoxPassword.Text;
            if (pass.Length < 6 || pass.Length > 128)
            {
                isCorrect = false;
                MessageBox.Show("������ ������ ��������� �� 6 �� 128 ��������");
            }

            if (isCorrect)
            {
                Teacher teachers = new Teacher();
                
                teachers.Name = name;
                teachers.InviteCode = pass;

                bool isSucces = _dbManager.TableTeachers.AddNew(teachers);

                if (isSucces)
                {
                    UpdateTeachersText();

                    MessageBox.Show("������ ������� ���������");
                }
                else
                {
                    MessageBox.Show("����� ��� ��� ����������, ���������� �����");
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateTeachersText();
        }

        private void UpdateTeachersText()
        {
            var teachers = _dbManager.TableTeachers.GetTeachers();

            string text = "";

            for (int i = 0; i < teachers.Count; i++)
            {
                text += $"{teachers[i].Name} ({teachers[i].InviteCode})";
                text += "\n";
            }

            teachersText.Text = text;
        }
    }
}