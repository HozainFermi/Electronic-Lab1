using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Electronic
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            int u = 10;
            int R = 100;
            int Rk = 40;
            float L = 0.04f;
            int[] f = new int[] {100,200,300,400,500};

            float[] Xls = new float[] {0,0,0,0,0 };
            float[] Zks = new float[] { 0, 0, 0, 0, 0 };
            float[] Zs = new float[] { 0, 0, 0, 0, 0 };
            float[] Is = new float[] { 0, 0, 0, 0, 0 };
            float[] Urs = new float[] { 0, 0, 0, 0, 0 };
            float[] Uks = new float[] { 0, 0, 0, 0, 0 };
            float[] F = new float[] { 0, 0, 0, 0, 0 };

            for(int i = 0; i < f.Length; i++)
            {
                
                Xls[i]=2*(float)Math.PI*f[i]*L;
                Xls[i] = (float)Math.Round((decimal)Xls[i], 2);

                Zks[i] =(float) Math.Sqrt(Math.Pow(Rk, 2) + Math.Pow(Xls[i],2));
                Zks[i]=(float)Math.Round((decimal)Zks[i], 2);

                Zs[i] = (float)Math.Sqrt(Math.Pow((Rk + R), 2) + Math.Pow(Xls[i],2));
                Zs[i] = (float)Math.Round((decimal)Zs[i], 2);

                Is[i] = (float)u / Zs[i];
                Is[i] = (float)Math.Round((decimal)Is[i], 2);

                Urs[i]=R*u/Zs[i];
                Urs[i] = (float)Math.Round((decimal)Urs[i], 2);

                Uks[i] = u * (Zks[i] / Zs[i]);
                Uks[i] = (float)Math.Round((decimal)Uks[i], 2);

                F[i] = (float)Math.Atan2(Xls[i], Rk + R);
                F[i] = (float)F[i]*(180/(float)(Math.PI));
                F[i] = (float)Math.Round((decimal)F[i], 2);


            }


            // Creating Grid with data
            var dg = new DataGrid();
            dg.Margin = new Thickness(405, 260, 10, 10);
            
            this.MainGrid.Children.Add(dg);

            var column = new DataGridTextColumn();
                column.Header = "XL";
                column.Binding = new Binding("XL");
            dg.Columns.Add(column);

            column = new DataGridTextColumn();
            column.Header = "Zk";
            column.Binding = new Binding("Zk");
            dg.Columns.Add(column);
            column = new DataGridTextColumn();
            column.Header = "Z";
            column.Binding = new Binding("Z");
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
            column.Header = "Uk";
            column.Binding = new Binding("Uk");
            dg.Columns.Add(column);
            column = new DataGridTextColumn();
            column.Header = "Ф";
            column.Binding = new Binding("F");
            dg.Columns.Add(column);
            //

            for (int i = 0; i < f.Length; i++)
            {
                dg.Items.Add(new DataItem { XL = Xls[i], Zk = Zks[i], Z = Zs[i], I = Is[i], Ur = Urs[i] , Uk = Uks[i] , F = F[i] });

            }

            //Plots
           var Xgraph = WpfPlot1.Plot.Add.Scatter(f, Xls);
            Xgraph.LegendText = "XL";
           var Zgraph = WpfPlot1.Plot.Add.Scatter(f, Zs);
            Zgraph.LegendText = "Z";
           var Igraph = WpfPlot1.Plot.Add.Scatter(f, Is);
            Igraph.LegendText = "I";
         
            WpfPlot1.Refresh();

          var Urgraph =  WpfPlot2.Plot.Add.Scatter(f, Urs);
            Urgraph.LegendText = "Ur";
            var Ukgraph =  WpfPlot2.Plot.Add.Scatter(f, Uks);
            Ukgraph.LegendText = "Uk";
            var Fgraph = WpfPlot2.Plot.Add.Scatter(f, F);
            Fgraph.LegendText = "F";
            WpfPlot2.Refresh();





        }
    }
}