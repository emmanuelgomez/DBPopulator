using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernDBPopulator
{
    class HiloGrupo:BackgroundWorker
    {
        public delegate void NuevoGrupoHandler(Object sender, Grupo grupo); 

        public HiloGrupo() : base()
        {
        }

        public event NuevoGrupoHandler NuevoGrupo;

        public void Iniciar()
        {
            base.DoWork += HiloGrupo_DoWork;

        }

        void HiloGrupo_DoWork(object sender, DoWorkEventArgs e)
        {
            Controller.SetController();
            List<Grupo> listGrupo = Controller.GetGrupos();
            foreach (var grupo in listGrupo)
            {
                NuevoGrupo(this, grupo);
            }

        }
    }
}
