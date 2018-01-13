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

namespace ModernDBPopulator.Pages
{
    /// <summary>
    /// Interaction logic for Configuracion.xaml
    /// </summary>
    public partial class Configuracion : UserControl
    {
        public Configuracion()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ConfiguracionModel x = ModelConf;
            ModernDBPopulator.Properties.Settings.Default.Database = x.Database;
            ModernDBPopulator.Properties.Settings.Default.Entidad = x.Entidad;
            ModernDBPopulator.Properties.Settings.Default.Host = x.Host;
            ModernDBPopulator.Properties.Settings.Default.Password = x.Password;
            ModernDBPopulator.Properties.Settings.Default.Port = x.Port;
            ModernDBPopulator.Properties.Settings.Default.User = x.User;
            ModernDBPopulator.Properties.Settings.Default.Url = x.Url;
            ModernDBPopulator.Properties.Settings.Default.Save();
        }
    }
}
