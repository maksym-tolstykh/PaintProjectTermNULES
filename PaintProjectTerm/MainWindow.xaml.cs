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

namespace PaintProjectTerm
{
    public partial class MainWindow : Window
    {
        //Розмір по замовчуванню
        private int diameter = (int)Sizes.small;
        //Колір по замовчуванню ЧОРНИЙ
        private Brush brushColor = Brushes.Black;

        private bool isPaint = false;
        private bool isErase = false;


        //Color

        //Розмір пензлика
        private enum Sizes
        {
             small=10,
             medum=15,
             large=30
        }
        public MainWindow()
        {
            InitializeComponent();
        }
        //Функція яка створює фігуру коло при малюванні
        private void paintCircle(Brush circleColor, Point position)
        {
            Ellipse ellipse = new Ellipse();
            ellipse.Fill = circleColor;
            ellipse.Width = diameter;
            ellipse.Height = diameter;
            Canvas.SetTop(ellipse, position.Y);
            Canvas.SetLeft(ellipse, position.X);
            paintCanvas.Children.Add(ellipse);

        }

        //Функція малювання на канвасі
        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (isPaint)
            {
                Point mousPos = e.GetPosition(paintCanvas);
                paintCircle(brushColor,mousPos);
            }
            if (isErase)
            {
                Point mousPos = e.GetPosition(paintCanvas);
                paintCircle(brushColor, mousPos);
            }
        }
        // Кнопки кольорів
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            brushColor = Brushes.Red;
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            brushColor = Brushes.Blue;
        }

        private void RadioButton_Checked_2(object sender, RoutedEventArgs e)
        {
            brushColor = Brushes.Black;
        }

        //кнопки ромізрів
        private void RadioButton_Checked_3(object sender, RoutedEventArgs e)
        {
            diameter = (int)Sizes.small;
        }

        private void RadioButton_Checked_4(object sender, RoutedEventArgs e)
        {
            diameter = (int)Sizes.medum;
        }

        private void RadioButton_Checked_5(object sender, RoutedEventArgs e)
        {
            diameter = (int)Sizes.large;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int count = paintCanvas.Children.Count;
            if (count > 0)
            {
                paintCanvas.Children.RemoveAt(count -1);
            }
        }

        private void paintCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            isPaint = true;
        }

        private void paintCanvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            isPaint = false;
        }
    }
}
