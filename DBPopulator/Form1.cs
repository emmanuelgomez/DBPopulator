using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LinqToExcel;
using LinqToExcel.Extensions;
using Remotion.Data.Linq.Clauses;


namespace DBPopulator
{
    public partial class Form1 : Form
    {
        private int Entidad = 16;
        private Connector conector;
        string pathToExcelFile = @"F:\Asistencia\Excel\Modelo.xlsx";
        public Form1()
        {
            InitializeComponent();
            conector = new Connector("localhost", "1433","Biomesys","sa","Admin123");
        }



        public List<Grupo> LoadGrupo()
        {
            Dictionary<string,int> stop=new Dictionary<string, int>();
            List<Grupo> listaretorno=new List<Grupo>();
            try
            {
                

                string sheetName = "Hoja2";

                var excelFile = new ExcelQueryFactory(pathToExcelFile);
                var artistAlbums = from a in excelFile.Worksheet<Grupo>(sheetName) select a ;

                Queue<Grupo> cola=new Queue<Grupo>((artistAlbums.ToList<Grupo>()));
                while (cola.Count>0)
                {
                    Grupo grupoAux = cola.Dequeue();
                    try
                    {
                       
                        if ((grupoAux.GrupoCodigo == null) || (grupoAux.GrupoNombre == null)) { listaretorno.Add(grupoAux); }
                        else if ( grupoAux.GrupoSuperiorCodigo==null)
                            conector.InsertarGrupo(grupoAux, Entidad);
                        else
                        {
                            if (conector.ExisteGrupo(grupoAux.GrupoSuperiorCodigo))
                                conector.InsertarGrupo(grupoAux, Entidad);
                            else
                            {
                                if ((stop.ContainsKey(grupoAux.GrupoCodigo)) && (stop[grupoAux.GrupoCodigo]!=cola.Count))
                                {
                                    stop[grupoAux.GrupoCodigo]=cola.Count;
                                    cola.Enqueue(grupoAux);
                                }
                                else if (!stop.ContainsKey(grupoAux.GrupoCodigo))
                                {
                                    stop.Add(grupoAux.GrupoCodigo,cola.Count);
                                    cola.Enqueue(grupoAux);
                                }
                                else if ((stop.ContainsKey(grupoAux.GrupoCodigo)) && (stop[grupoAux.GrupoCodigo]==cola.Count))
                                {
                                    listaretorno.Add(grupoAux);
                                
                                }
                           
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        listaretorno.Add(grupoAux);
                    }
                }
            }
            catch (Exception e)
            {
                toolStripStatusLabel1.Text = e.Message;
            }
            return listaretorno;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadTrabajador();
        }

        public List<Trabajador> LoadTrabajador()
        {
            List<Trabajador> listRetorno=new List<Trabajador>();
            string sheetName = "Hoja1";

            var excelFile = new ExcelQueryFactory(pathToExcelFile);
            var artistAlbums = from a in excelFile.Worksheet<Trabajador>(sheetName) select a;

            foreach (Trabajador workerTrabajador in artistAlbums )
            {
                try
                {
                    if ((workerTrabajador.GrupoCodigo==null)||(workerTrabajador.TrabajadorApellidos==null)||(workerTrabajador.TrabajadorCodigo==null)||
                        (workerTrabajador.TrabajadorIdentidad==null)||(workerTrabajador.TrabajadorLdap==null)||(workerTrabajador.TrabajadorNombre==null))
                    {
                        
                    }
                    if (!conector.InsertarTrabajador(workerTrabajador, Entidad))
                    {
                        listRetorno.Add(workerTrabajador);
                    }
                }
                catch (Exception e)
                {
                    listRetorno.Add(workerTrabajador);
                }
            }
            return listRetorno;
        }

    }
}
