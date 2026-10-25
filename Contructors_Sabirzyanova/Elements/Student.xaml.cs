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

namespace Contructors_Sabirzyanova.Elements
{
    /// <summary>
    /// Логика взаимодействия для Student.xaml
    /// </summary>
    public partial class Student : UserControl {
        public Student(Classes.Student student)
        {
            InitializeComponent();
            tb_fio.Content = student.GetFIO();
            tb_scholarship.Content = student.Scholarship ? "Стипендия: получает" : "Стипендия: не получает";
            tb_course.Content = $"Kypc: {student.Course}";
            if (student.Scholarship)
            {
                var grid = this.Content as Grid;
                if (grid != null)
                {
                    grid.Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Green);
                }
            }
            try
            {
                avatar.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri(student.ImagePath, UriKind.RelativeOrAbsolute));
            }
            catch { }
        }
    }
}
