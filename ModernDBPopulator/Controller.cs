using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToExcel;

namespace ModernDBPopulator
{
    public static class Controller
    {

        private static int Entidad;
        private static Connector conector;
        public static string pathToExcelFile;
        public const string sheetGrupos = "Grupos";
        public const string sheetTrabajadores = "Trabajadores";

        public static void SetController()
        {

            conector = new Connector(ModernDBPopulator.Properties.Settings.Default.Host, ModernDBPopulator.Properties.Settings.Default.Port,
                ModernDBPopulator.Properties.Settings.Default.Database, ModernDBPopulator.Properties.Settings.Default.User, ModernDBPopulator.Properties.Settings.Default.Password);
            Entidad = ModernDBPopulator.Properties.Settings.Default.Entidad;
            pathToExcelFile = ModernDBPopulator.Properties.Settings.Default.Url;
        }


        public static List<Grupo> LoadGrupo(List<Grupo> listGrupos)
        {
            Dictionary<string, int> stop = new Dictionary<string, int>();
            List<Grupo> listaretorno = new List<Grupo>();
            try
            {


                Queue<Grupo> cola = new Queue<Grupo>(listGrupos);
                while (cola.Count > 0)
                {
                    Grupo grupoAux = cola.Dequeue();
                    try
                    {

                        if ((grupoAux.GrupoCodigo == null) || (grupoAux.GrupoNombre == null))
                        {
                            grupoAux.Error = "Tiene valores vacios";
                            listaretorno.Add(grupoAux); }
                        else if ((grupoAux.GrupoSuperiorCodigo == null) || (grupoAux.GrupoSuperiorCodigo == ""))
                            conector.InsertarGrupo(grupoAux, Entidad);
                        else
                        {
                            if ((conector.ExisteGrupo(grupoAux.GrupoSuperiorCodigo)) &&(!conector.ExisteGrupo(grupoAux.GrupoCodigo)))
                                conector.InsertarGrupo(grupoAux, Entidad);
                            else if (conector.ExisteGrupo(grupoAux.GrupoCodigo))
                            {
                                grupoAux.Error = "El grupo " + grupoAux.GrupoNombre + " ya existe";
                                listaretorno.Add(grupoAux);
                            }
                            else
                            {
                                if ((stop.ContainsKey(grupoAux.GrupoCodigo)) && (stop[grupoAux.GrupoCodigo] != cola.Count))
                                {
                                    stop[grupoAux.GrupoCodigo] = cola.Count;
                                    cola.Enqueue(grupoAux);
                                }
                                else if (!stop.ContainsKey(grupoAux.GrupoCodigo))
                                {
                                    stop.Add(grupoAux.GrupoCodigo, cola.Count);
                                    cola.Enqueue(grupoAux);
                                }
                                else if ((stop.ContainsKey(grupoAux.GrupoCodigo)) && (stop[grupoAux.GrupoCodigo] == cola.Count))
                                {
                                    grupoAux.Error = "El grupo superior no existe";
                                    listaretorno.Add(grupoAux);

                                }

                            }
                        }
                    }
                    catch (Exception e)
                    {
                        grupoAux.Error = e.Message;
                        listaretorno.Add(grupoAux);
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return listaretorno;

        }

        public static List<Grupo> GetGrupos()
        {
            string sheetName = sheetGrupos;

            var excelFile = new ExcelQueryFactory(pathToExcelFile);
            var artistAlbums = from a in excelFile.Worksheet<Grupo>(sheetName) select a;
            return artistAlbums.ToList();
        }
        public static List<Trabajador> LoadTrabajador(List<Trabajador> listTrabajador)
        {
            List<Trabajador> listRetorno = new List<Trabajador>();
            
            foreach (Trabajador workerTrabajador in listTrabajador)
            {
                try
                {
                    if ((workerTrabajador.GrupoCodigo == null) || (workerTrabajador.TrabajadorApellidos == null) || (workerTrabajador.TrabajadorCodigo == null) ||
                        (workerTrabajador.TrabajadorIdentidad == null) || (workerTrabajador.TrabajadorLdap == null) || (workerTrabajador.TrabajadorNombre == null))
                    {

                    }
                    if (!conector.InsertarTrabajador(workerTrabajador, Entidad))
                    {
                        workerTrabajador.Error = "No se pudo insertar.";
                        listRetorno.Add(workerTrabajador);
                    }
                }
                catch (Exception e)
                {
                    workerTrabajador.Error = e.Message;
                    listRetorno.Add(workerTrabajador);
                }
            }
            return listRetorno;
        }
        public static List<Trabajador> GetTrabajador()
        {
            string sheetName = sheetTrabajadores;

            var excelFile = new ExcelQueryFactory(pathToExcelFile);
            var artistAlbums = from a in excelFile.Worksheet<Trabajador>(sheetName) select a;
            return artistAlbums.ToList();
        }
    }
}
