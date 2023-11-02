using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace PaintProjectTerm
{
    public partial class MainWindow : Window
    {
        private PaintBrush paintBrush;

        public MainWindow()
        {
            InitializeComponent();
            paintBrush = new PaintBrush(paintCanvas);
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            paintBrush.SetColor(Brushes.Red);
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            paintBrush.SetColor(Brushes.Blue);
        }

        private void RadioButton_Checked_2(object sender, RoutedEventArgs e)
        {
            paintBrush.SetColor(Brushes.Black);
        }

        private void RadioButton_Checked_3(object sender, RoutedEventArgs e)
        {
            paintBrush.SetSize(PaintBrush.BrushSize.Small);
        }

        private void RadioButton_Checked_4(object sender, RoutedEventArgs e)
        {
            paintBrush.SetSize(PaintBrush.BrushSize.Medium);
        }

        private void RadioButton_Checked_5(object sender, RoutedEventArgs e)
        {
            paintBrush.SetSize(PaintBrush.BrushSize.Large);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            paintBrush.Undo();
        }

        private void paintCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            paintBrush.StartPainting();
        }

        private void paintCanvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            paintBrush.StopPainting();
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            paintBrush.Paint(e.GetPosition(paintCanvas));
        }
    }

    public class PaintBrush
    {
        private Canvas canvas;
        private bool isPainting;
        private Brush color;
        private BrushSize size;

        public enum BrushSize
        {
            Small = 10,
            Medium = 15,
            Large = 30
        }

        public PaintBrush(Canvas canvas)
        {
            this.canvas = canvas;
            this.isPainting = false;
            this.color = Brushes.Black;
            this.size = BrushSize.Small;
        }

        public void StartPainting()
        {
            isPainting = true;
        }

        public void StopPainting()
        {
            isPainting = false;
        }

        public void Paint(Point position)
        {
            if (isPainting)
            {
                var ellipse = CreateEllipse(position);
                canvas.Children.Add(ellipse);
            }
        }

        public void SetColor(Brush brush)
        {
            color = brush;
        }

        public void SetSize(BrushSize brushSize)
        {
            size = brushSize;
        }

        public void Undo()
        {
            int count = canvas.Children.Count;
            if (count > 0)
            {
                canvas.Children.RemoveAt(count - 1);
            }
        }

        private Ellipse CreateEllipse(Point position)
        {
            var ellipse = new Ellipse
            {
                Fill = color,
                Width = (int)size,
                Height = (int)size
            };

            Canvas.SetTop(ellipse, position.Y);
            Canvas.SetLeft(ellipse, position.X);

            return ellipse;
        }
    }
}
