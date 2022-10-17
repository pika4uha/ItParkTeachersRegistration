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
                MessageBox.Show("Введите ФИО");
            }

            string pass = textBoxPassword.Text;
            if (pass.Length < 6 || pass.Length > 128)
            {
                isCorrect = false;
                MessageBox.Show("Пароль должен содержать от 6 до 128 символов");
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

                    MessageBox.Show("Данные успешно добавлены");
                }
                else
                {
                    MessageBox.Show("Такой код уже существует, придумайте новый");
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