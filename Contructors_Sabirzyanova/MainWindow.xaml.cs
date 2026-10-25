using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Contructors_Sabirzyanova
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Classes.Student> AllStudent = Classes.RepoStudents.AllStudent();
        public int Count = 10;
        public int Step = 0;

        public MainWindow()
        {
            InitializeComponent();
            CreateStudent(Step, Count);
        }

        public void CreateStudent(int Step, int Count)
        {
            for (int iStudent = Step; iStudent < Step + Count; iStudent++)
            {
                if (AllStudent.Count > iStudent)
                    parent.Children.Add(new Elements.Student(AllStudent[iStudent]));
            }
            this.Step += Count;
        }
        private void ScrollViewer_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            ScrollViewer scroll = sender as ScrollViewer;
            double ParentHeight = parent.ActualHeight;
            double WindowHeight = scroll.ActualHeight - 20;
            double DeltaHeight = ParentHeight - WindowHeight;
            if (DeltaHeight - scroll.VerticalOffset < 140)
            {
                CreateStudent(Step, Count);
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var newStudent = new Classes.Student("Фунтик", "Николай", "Эдуардович", true, 1);
            AllStudent.Add(newStudent);
            parent.Children.Clear();
            Step = 0;
            CreateStudent(Step, Count);
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (AllStudent.Count > 0)
            {
                AllStudent[0].Firstname = "Шевченко";
                parent.Children.Clear();
                Step = 0;
                CreateStudent(Step, Count);
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (AllStudent.Count > 0)
            {
                AllStudent.RemoveAt(AllStudent.Count - 1);
                parent.Children.Clear();
                Step = 0;
                CreateStudent(Step, Count);
            }
        }

        private void Sort_Click(object sender, RoutedEventArgs e)
        {
            AllStudent.Sort((x, y) => x.Firstname.CompareTo(y.Firstname));
            parent.Children.Clear();
            Step = 0;
            CreateStudent(Step, Count);
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (System.IO.StreamWriter writer = new System.IO.StreamWriter("Студенты.txt", false, System.Text.Encoding.UTF8))
                {
                    foreach (var student in AllStudent)
                    {
                        string scholarshipText = student.Scholarship ? "Получает стипендию" : "Нет стипендии";
                        writer.WriteLine($"{student.Firstname};{student.Lastname};{student.Surname};{scholarshipText};{student.Course}");
                    }
                }
                MessageBox.Show("Данные сохранены в файл Студенты.txt");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }
    }
}
