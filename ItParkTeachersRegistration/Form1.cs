using ItParkTeachersRegistration.DataBase;
using ItParkTeachersRegistration.DataBase.Entities;
namespace ItParkTeachersRegistration
{
    public partial class Form1 : Form
    {
        private DbManager dbManager = new DbManager();

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
            if (name.Length < 6 || name.Length > 128)
            {
                isCorrect = false;
                MessageBox.Show("������ ������ ��������� �� 6 �� 128 ��������");
            }

            if (isCorrect)
            {
                Teachers teachers = new Teachers();
                
                teachers.Name = name;
                teachers.InviteCode = pass;
                
                //����� �������� �� ������������ ������-���� (password)

                //dbManager.TableTeachers.AddNew(teachers);

                MessageBox.Show("������ ������� ���������");
            }
        }
    }
}