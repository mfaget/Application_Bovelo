using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bovelo
{
    public partial class Order : Form
    {
        private App newApp = new App();
        private User _currentUser;
        //private List<List<string>> orderList;
        internal Order(ref User incomingUser)
        {
            _currentUser = incomingUser;
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            {
                string details = dataGridView1.Rows[e.RowIndex].Cells[6].ToolTipText.ToString();
                MessageBox.Show(this,"BIKES :\n\n"+details,"ORDER DETAILS");
            }
        }
        private void Order_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            newApp.updateOrderBikeList();
            int i = 0;
            foreach(var orders in newApp.orderBikeList)//Errors in the cells
            {
                string orderDetails = "";
                foreach(var detail in orders.bikeList)
                {
                    orderDetails += detail.bikeId + " | " + detail.Type + " | " + detail.Color + " | " + detail.Size + " | " + detail.Price + " | " + detail.state.First(x=>x.Value ==true).Key + "\n";
                }
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = orders.orderId.ToString();
                dataGridView1.Rows[i].Cells[1].Value = orders.clientName;
                dataGridView1.Rows[i].Cells[2].Value = orders.totalPrice;
                dataGridView1.Rows[i].Cells[3].Value = orders.orderDate.ToString();
                dataGridView1.Rows[i].Cells[4].Value = orders.shippingDate.ToString();
                dataGridView1.Rows[i].Cells[5].Value = orders.isReadyToShip.ToString();
                dataGridView1.Rows[i].Cells[6].ToolTipText = orderDetails;
                i++;
            }
         
        }
        private void button3_Click(object sender, EventArgs e)//Order button => reload
        {
            Order_Load( sender, e);
        }

        private void button7_Click(object sender, EventArgs e)//home button
        {
            this.Hide();
            var MainHome = new MainHome(_currentUser);// create new window
            MainHome.FormClosed += (s, args) => this.Close();
            MainHome.Show();// Showing the Login window
        }

        private void button2_Click(object sender, EventArgs e)//cart button
        {
            this.Hide();
            Cart cart = new Cart(ref _currentUser);// create new window
            cart.FormClosed += (s, args) => this.Close();
            cart.Show();// Showing the Cart window
        }

    }
}
