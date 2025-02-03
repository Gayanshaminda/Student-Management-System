using System;
using System.ComponentModel;
using MySql.Data.MySqlClient;

namespace Project
{
    public partial class DBconnection : Component
    {
        private MySqlConnection connect;

        public DBconnection()
        {
            InitializeComponent();
            InitializeDatabaseConnection();
        }

        public DBconnection(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            InitializeDatabaseConnection();
        }

        private void InitializeDatabaseConnection()
        {
            // Initialize MySqlConnection here
            connect = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=studentdata");
        }

        public MySqlConnection GetConnection
        {
            get
            {
                return connect;
            }
        }

        //To open connection
        public void openconnect()
        {
            if(connect.State==System.Data.ConnectionState.Closed)
                connect.Open();
        }

        //To close connection
        public void closeconnect()
        {
            if (connect.State == System.Data.ConnectionState.Open)
                connect.Close();
        }

        public MySqlConnection getconnection
        {
            get { return connect; }
        }




        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Dispose of managed resources
                connect?.Dispose();
            }

            // Dispose of base class resources
            base.Dispose(disposing);
        }
    }
}
