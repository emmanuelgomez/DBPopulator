using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
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
using ClosedXML.Excel;
using Path = System.IO.Path;

namespace ModernDBPopulator.Pages
{
    /// <summary>
    /// Interaction logic for InsertarGrupos.xaml
    /// </summary>
    public partial class InsertarTrabajadores : UserControl
    {
        private ObservableCollection<Trabajador> custdata;

        public InsertarTrabajadores()
        {
            InitializeComponent();

            custdata = new ObservableCollection<Trabajador>();
            //Bind the DataGrid to the customer data
            DG1.DataContext = custdata;
            BackgroundWorker loadTrabajador = new BackgroundWorker();
            loadTrabajador.DoWork += loadTrabajador_DoWork;
            loadTrabajador.RunWorkerAsync();
        }

        void loadTrabajador_DoWork(object sender, DoWorkEventArgs e)
        {
            App.Current.Dispatcher.Invoke((Action)delegate // <--- HERE
           {
               Controller.SetController();
               List<Trabajador> listTrabajador = Controller.GetTrabajador();
               foreach (var trabajador in listTrabajador)
               {
                   custdata.Add(trabajador);
               }
               textbox1.Text =Path.GetDirectoryName(Controller.pathToExcelFile)+@"\" +Path.GetFileNameWithoutExtension(Controller.pathToExcelFile) + 
                   "-ErrorSalva-" + DateTime.Now.Month + "_" + DateTime.Now.Day + "_" + DateTime.Now.Hour + "_" + 
                   DateTime.Now.Minute + Path.GetExtension(Controller.pathToExcelFile);
               ;
           });
        }





        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Controller.
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            BackgroundWorker grupoInsertar = new BackgroundWorker();
            grupoInsertar.DoWork += trabajadorInsertar_DoWork;
            grupoInsertar.RunWorkerAsync();
        }

        void trabajadorInsertar_DoWork(object sender, DoWorkEventArgs e)
        {  App.Current.Dispatcher.Invoke((Action)delegate // <--- HERE
          {
              LogMessage("Iniciando a insertar los Trabajadores");
              List<Trabajador> lista = new List<Trabajador>();
            try
            {
                lista = Controller.LoadTrabajador(custdata.ToList());
            }
            catch (Exception ex)
            {
                LogMessage(ex.Message);
            }
            custdata.Clear();
            if (lista.Count > 0)
            {
                foreach (var trabajador in lista)
                {
                    LogMessage(trabajador.TrabajadorNombre+" "+trabajador.TrabajadorApellidos +" :--> No se insertó :---->>>  "+trabajador.Error);
                    custdata.Add(trabajador);
                }
                LogMessage("Se ha completado la insercion, pero algunos Trabajadores no se pudieron insertar.");
                ButtonSalva.IsEnabled = true;
                textbox1.IsEnabled = true;
            }
            else
            {
                LogMessage("Se ha completado la insercion.");
            }
            ;
          });
        }
        private void LogMessage(string message)
        {
            App.Current.Dispatcher.Invoke((Action)delegate // <--- HERE
          {
              message = string.Format(CultureInfo.CurrentUICulture, message);
              this.TextEvents.AppendText(message + "\r\n");
              ;
          });

        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var wb = new XLWorkbook();

            var dataTable = GetTable(Controller.sheetTrabajadores);

            // Add a DataTable as a worksheet
            wb.Worksheets.Add(dataTable);

            wb.SaveAs(textbox1.Text);
        }

        private DataTable GetTable(string tableName)
        {
            DataTable table = new DataTable();
            table.TableName = tableName;
            table.Columns.Add("TrabajadorNombre", typeof(string));
            table.Columns.Add("TrabajadorApellidos", typeof(string));
            table.Columns.Add("TrabajadorCodigo", typeof(string));
            table.Columns.Add("TrabajadorIdentidad", typeof(string));
            table.Columns.Add("TrabajadorLdap", typeof(string));
            table.Columns.Add("GrupoCodigo", typeof(string));


            foreach (var trabajador in custdata)
            {
                table.Rows.Add(trabajador.TrabajadorNombre, trabajador.TrabajadorApellidos, trabajador.TrabajadorCodigo, trabajador.TrabajadorIdentidad,
                    trabajador.TrabajadorLdap, trabajador.GrupoCodigo);
            }

          
            return table;

        }
    }
}
