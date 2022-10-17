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
                MessageBox.Show("Введите ФИО");
            }

            string pass = textBoxPassword.Text;
            if (name.Length < 6 || name.Length > 128)
            {
                isCorrect = false;
                MessageBox.Show("Пароль должен содержать от 6 до 128 символов");
            }

            if (isCorrect)
            {
                Teachers teachers = new Teachers();
                
                teachers.Name = name;
                teachers.InviteCode = pass;
                
                //нужна проверка на уникальность инвайт-кода (password)

                //dbManager.TableTeachers.AddNew(teachers);

                MessageBox.Show("Данные успешно добавлены");
            }
        }
    }
}