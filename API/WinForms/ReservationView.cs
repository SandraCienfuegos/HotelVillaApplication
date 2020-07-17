using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.AspNetCore.SignalR.Client;
using Winforms;

namespace WinForms
{
    public partial class ReservationView : UserControl
    {
        HubConnection connection;
        List<ReservationResource> reservations = new List<ReservationResource>();

        public ReservationView()
        {
            InitializeComponent();
        }

        private async void ReservationView_Load(object sender, EventArgs e)
        {
            dataGridView.DataSource = new BindingSource {DataSource = reservations};
            connection = new HubConnectionBuilder()
                .WithUrl("http://localhost:5000/reservations_hub")
                .Build();

            connection.Closed += async (error) =>
            {
                await Task.Delay(new Random().Next(0, 5) * 1000);
                await connection.StartAsync();
            };

            await connection.StartAsync();

            MessageBox.Show(connection.State.ToString());

            connection.On<ReservationResource>("BroadCastReservation",
                (reservation) =>
                {
                    reservations.Insert(0, reservation);
                    dataGridView.DataSource = new BindingSource {DataSource = reservations};
                    dataGridView.Refresh();
                });
        }
    }
}