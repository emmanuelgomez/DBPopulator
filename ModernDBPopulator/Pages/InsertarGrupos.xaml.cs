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
    public partial class InsertarGrupos : UserControl
    {
        private ObservableCollection<Grupo> custdata;

        public InsertarGrupos()
        {
            InitializeComponent();

            custdata = new ObservableCollection<Grupo>();
            //Bind the DataGrid to the customer data
            DG1.DataContext = custdata;
            BackgroundWorker loadGrupo = new BackgroundWorker();
            loadGrupo.DoWork += loadGrupo_DoWork;
            loadGrupo.RunWorkerAsync();
        }

        void loadGrupo_DoWork(object sender, DoWorkEventArgs e)
        {
            App.Current.Dispatcher.Invoke((Action)delegate // <--- HERE
           {
               Controller.SetController();
               List<Grupo> listGrupo = Controller.GetGrupos();
               foreach (var grupo in listGrupo)
               {
                   custdata.Add(grupo);
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
            grupoInsertar.DoWork += grupoInsertar_DoWork;
            grupoInsertar.RunWorkerAsync();
        }

        void grupoInsertar_DoWork(object sender, DoWorkEventArgs e)
        {  App.Current.Dispatcher.Invoke((Action)delegate // <--- HERE
          {
            LogMessage("Iniciando a insertar los Grupos");
            List<Grupo> lista = new List<Grupo>();
            try
            {
                lista = Controller.LoadGrupo(custdata.ToList());
            }
            catch (Exception ex)
            {
                LogMessage(ex.Message);
            }
            custdata.Clear();
            if (lista.Count > 0)
            {
                foreach (var grupo in lista)
                {
                    LogMessage(grupo.GrupoNombre + " :--> No se insertó :---->>>  " + grupo.Error);
                    custdata.Add(grupo);
                }
                LogMessage("Se ha completado la insercion, pero algunos Grupos no se pudieron insertar.");
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

            var dataTable = GetTable(Controller.sheetGrupos);

            // Add a DataTable as a worksheet
            wb.Worksheets.Add(dataTable);

            wb.SaveAs(textbox1.Text);
        }

        private DataTable GetTable(string tableName)
        {
            DataTable table = new DataTable();
            table.TableName = tableName;
            table.Columns.Add("GrupoNombre", typeof(string));
            table.Columns.Add("GrupoCodigo", typeof(string));
            table.Columns.Add("GrupoSuperiorCodigo", typeof(string));

            foreach (var grupo in custdata)
            {
                table.Rows.Add(grupo.GrupoNombre, grupo.GrupoCodigo, grupo.GrupoSuperiorCodigo);
            }

          
            return table;

        }
    }
}
