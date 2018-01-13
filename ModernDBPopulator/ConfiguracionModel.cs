using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirstFloor.ModernUI.Presentation;

namespace ModernDBPopulator
{
    class ConfiguracionModel : NotifyPropertyChanged
    {
        private string host=Properties.Settings.Default.Host;
        public string Host
        {
            get { return this.host; }
            set
            {
                if (this.host != value)
                {
                    this.host = value;
                    OnPropertyChanged("Host");
                }
            }
        }

        private string port =Properties.Settings.Default.Port;
        public string Port
        {
            get { return this.port; }
            set
            {
                if (this.port != value)
                {
                    this.port = value;
                    OnPropertyChanged("Port");
                }
            }
        }

        private string user=Properties.Settings.Default.User;
        public string User
        {
            get { return this.user; }
            set
            {
                if (this.user != value)
                {
                    this.user = value;
                    OnPropertyChanged("User");
                }
            }
        }

        private string password=Properties.Settings.Default.Password;
        public string Password
        {
            get { return this.password; }
            set
            {
                if (this.password != value)
                {
                    this.password = value;
                    OnPropertyChanged("Password");
                }
            }
        }

        private string database=Properties.Settings.Default.Database;
        public string Database
        {
            get { return this.database; }
            set
            {
                if (this.database != value)
                {
                    this.database = value;
                    OnPropertyChanged("Database");
                }
            }
        }

        private int entidad=Properties.Settings.Default.Entidad;
        public int Entidad
        {
            get { return this.entidad; }
            set
            {
                if (this.entidad != value)
                {
                    this.entidad = value;
                    OnPropertyChanged("Entidad");
                }
            }
        }

        private string url=Properties.Settings.Default.Url;
        public string Url
        {
            get { return this.url; }
            set
            {
                if (this.url != value)
                {
                    this.url = value;
                    OnPropertyChanged("Url");
                }
            }
        }
    }
}
