using ScottPlot;
using ScottPlot.WPF;
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
using System.Windows.Shapes;

namespace Electronic
{
    /// <summary>
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
            //Дано
            int[] f = new int[] {105,205,305 };
            float U = 2;
            float R = 10;
            float C = 0.0000012f;

            float[] Xc = new float[] { 100.55f , 51.64F, 37.74f };
            float[] Xl = new float[] { 26.52f , 51.64f, 76.76f };
            float[] X = new float[] { -74.03f, 0, 42.02f };
            float[] Z = new float[] { 158.37f , 140f, 146.17f };
            float[] I = new float[] { 0.06f, 0.07f, 0.07f };
            float[] F = new float[] { -27.88f, 0,16.71f };
            float[] Ur = new float[] { 6.31f , 7.14f, 6.84f };
            float[] Uc = new float[] { 6.34f , 3.69f, 2.37f };
            float[] Uk = new float[] { 3.03f , 4.67f, 5.92f };

            //     for (int i = 0; i < f.Length; i++)
            //     {
            //         Xcs[i] = (float)1/(2*(float)Math.PI*f[i]*C);
            //         Xcs[i] = (float)Math.Round((decimal)Xcs[i], 5);
            //
            //         Zcs[i] = (float)Math.Sqrt(R * R + Xcs[i] * Xcs[i]);
            //         Zcs[i] = (float)Math.Round((decimal)Zcs[i], 5);
            //
            //         Is[i]=U/Zcs[i];
            //         Is[i] = (float)Math.Round((decimal)Is[i], 5);
            //
            //         Urs[i]=Is[i]*R;
            //         Urs[i] = (float)Math.Round((decimal)Urs[i], 5);
            //
            //         Ucs[i]=Is[i]*Xcs[i];
            //         Ucs[i] = (float)Math.Round((decimal)Ucs[i], 5);
            //
            //         Fs[i] = (float)Math.Atan2(-Xcs[i], R);
            //         Fs[i] = (float)Fs[i] * (180 / (float)(Math.PI));
            //         Fs[i] = (float)Math.Round((decimal)Fs[i], 5);
            //     }
            //
            //     var dg = new DataGrid();
            //     dg.Margin = new Thickness(405, 260, 10, 10);
            //
            //     this.MainGrid.Children.Add(dg);
            //
            //     var column = new DataGridTextColumn();
            //     column.Header = "Xc";
            //     column.Binding = new Binding("Xc");
            //     dg.Columns.Add(column);
            //
            //     column = new DataGridTextColumn();
            //     column.Header = "Zc";
            //     column.Binding = new Binding("Zc");
            //     dg.Columns.Add(column);
            //    
            //    
            //     column = new DataGridTextColumn();
            //     column.Header = "I";
            //     column.Binding = new Binding("I");
            //     dg.Columns.Add(column);
            //
            //     column = new DataGridTextColumn();
            //     column.Header = "Ur";
            //     column.Binding = new Binding("Ur");
            //     dg.Columns.Add(column);
            //
            //     column = new DataGridTextColumn();
            //     column.Header = "Uc";
            //     column.Binding = new Binding("Uc");
            //     dg.Columns.Add(column);
            //
            //     column = new DataGridTextColumn();
            //     column.Header = "Ф";
            //     column.Binding = new Binding("F");
            //     dg.Columns.Add(column);
            //
            //     for (int i = 0; i < f.Length; i++)
            //     {
            //         dg.Items.Add(new DataItem2 { Xc = Xcs[i], Zc = Zcs[i], I = Is[i], Ur = Urs[i], Uc = Ucs[i], F = Fs[i] });
            //
            //     }


            var Xcgraph = WpfPlot1.Plot.Add.Scatter(f, Xc);
            Xcgraph.LegendText = "Xc";
            Xcgraph.Axes.YAxis = WpfPlot1.Plot.Axes.Left;

            var Xlgraph = WpfPlot1.Plot.Add.Scatter(f, Xl);
            Xlgraph.LegendText = "Xl";
            Xlgraph.Axes.YAxis = WpfPlot1.Plot.Axes.Left;

            var Xgraph = WpfPlot1.Plot.Add.Scatter(f, X);
            Xgraph.LegendText = "X";
            Xgraph.Axes.YAxis = WpfPlot1.Plot.Axes.Left;
            WpfPlot1.Plot.Axes.AntiAlias(false);
            WpfPlot1.Plot.XLabel("Ф, Гц");
            WpfPlot1.Plot.Axes.Left.Label.Text = "Ом";
            WpfPlot1.Refresh();

            var Zgraph = WpfPlot2.Plot.Add.Scatter(f, Z);
            Zgraph.LegendText = "Z";
            Zgraph.Axes.YAxis = WpfPlot2.Plot.Axes.Left;
            WpfPlot2.Plot.Axes.AntiAlias(false);
            WpfPlot2.Plot.XLabel("Ф, Гц");
            WpfPlot2.Plot.Axes.Left.Label.Text = "Ом";
            WpfPlot2.Refresh();

            var Igraph = WpfPlot3.Plot.Add.Scatter(f, I);
            Igraph.LegendText = "I";
            Igraph.Axes.YAxis = WpfPlot3.Plot.Axes.Left;
            WpfPlot3.Plot.Axes.AntiAlias(false);
            WpfPlot3.Plot.XLabel("Ф, Гц");
            WpfPlot3.Plot.Axes.Left.Label.Text = "A";
            WpfPlot3.Refresh();

           

            var Fgraph = WpfPlot4.Plot.Add.Scatter(f, F);
            Fgraph.LegendText = "F";
            Fgraph.Axes.YAxis = WpfPlot4.Plot.Axes.Left;

            WpfPlot4.Plot.Axes.AntiAlias(false);
            WpfPlot4.Plot.XLabel("Ф, Гц");
            WpfPlot4.Plot.Axes.Left.Label.Text = "град";
            WpfPlot4.Refresh();


        }

       

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }
    }
}
