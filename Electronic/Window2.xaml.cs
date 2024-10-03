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
            int[] f = new int[] { 2000, 6000, 10000, 14000, 18000 };
            float U = 2;
            float R = 10;
            float C = 0.0000012f;

            float[] Xcs = new float[] { 0, 0, 0, 0, 0 };
            float[] Zcs = new float[] { 0, 0, 0, 0, 0 };
            float[] Is = new float[] { 0, 0, 0, 0, 0 };
            float[] Urs = new float[] { 0, 0, 0, 0, 0 };
            float[] Ucs = new float[] { 0, 0, 0, 0, 0 };
            float[] Fs = new float[] {0,0,0, 0, 0 };

            for (int i = 0; i < f.Length; i++)
            {
                Xcs[i] = (float)1/(2*(float)Math.PI*f[i]*C);
                Xcs[i] = (float)Math.Round((decimal)Xcs[i], 5);

                Zcs[i] = (float)Math.Sqrt(R * R + Xcs[i] * Xcs[i]);
                Zcs[i] = (float)Math.Round((decimal)Zcs[i], 5);

                Is[i]=U/Zcs[i];
                Is[i] = (float)Math.Round((decimal)Is[i], 5);

                Urs[i]=Is[i]*R;
                Urs[i] = (float)Math.Round((decimal)Urs[i], 5);

                Ucs[i]=Is[i]*Xcs[i];
                Ucs[i] = (float)Math.Round((decimal)Ucs[i], 5);

                Fs[i] = (float)Math.Atan2(-Xcs[i], R);
                Fs[i] = (float)Fs[i] * (180 / (float)(Math.PI));
                Fs[i] = (float)Math.Round((decimal)Fs[i], 5);
            }

            var dg = new DataGrid();
            dg.Margin = new Thickness(405, 260, 10, 10);

            this.MainGrid.Children.Add(dg);

            var column = new DataGridTextColumn();
            column.Header = "Xc";
            column.Binding = new Binding("Xc");
            dg.Columns.Add(column);

            column = new DataGridTextColumn();
            column.Header = "Zc";
            column.Binding = new Binding("Zc");
            dg.Columns.Add(column);
           
           
            column = new DataGridTextColumn();
            column.Header = "I";
            column.Binding = new Binding("I");
            dg.Columns.Add(column);

            column = new DataGridTextColumn();
            column.Header = "Ur";
            column.Binding = new Binding("Ur");
            dg.Columns.Add(column);

            column = new DataGridTextColumn();
            column.Header = "Uc";
            column.Binding = new Binding("Uc");
            dg.Columns.Add(column);

            column = new DataGridTextColumn();
            column.Header = "Ф";
            column.Binding = new Binding("F");
            dg.Columns.Add(column);

            for (int i = 0; i < f.Length; i++)
            {
                dg.Items.Add(new DataItem2 { Xc = Xcs[i], Zc = Zcs[i], I = Is[i], Ur = Urs[i], Uc = Ucs[i], F = Fs[i] });

            }


            var Xgraph = WpfPlot1.Plot.Add.Scatter(f, Xcs);
            Xgraph.LegendText = "XL";
            Xgraph.Axes.YAxis = WpfPlot1.Plot.Axes.Left;

            var Zgraph = WpfPlot1.Plot.Add.Scatter(f, Zcs);
            Zgraph.LegendText = "Z";
            Zgraph.Axes.YAxis = WpfPlot1.Plot.Axes.Left;

            var Igraph = WpfPlot1.Plot.Add.Scatter(f, Is);
            Igraph.LegendText = "I";
            Igraph.Axes.YAxis = WpfPlot1.Plot.Axes.Right;

            WpfPlot1.Plot.XLabel("Ф, Гц");
            WpfPlot1.Plot.Axes.Right.Label.Text = "А";
            WpfPlot1.Plot.Axes.Left.Label.Text = "Ом";

            WpfPlot1.Refresh();

            var Urgraph = WpfPlot2.Plot.Add.Scatter(f, Urs);
            Urgraph.LegendText = "Ur";
            var Ukgraph = WpfPlot2.Plot.Add.Scatter(f, Ucs);
            Ukgraph.LegendText = "Uk";
            var Fgraph = WpfPlot2.Plot.Add.Scatter(f, Fs);
            Fgraph.LegendText = "F";
            WpfPlot2.Plot.XLabel("Ф, Гц");

            WpfPlot2.Refresh();


        }

       

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }
    }
}
