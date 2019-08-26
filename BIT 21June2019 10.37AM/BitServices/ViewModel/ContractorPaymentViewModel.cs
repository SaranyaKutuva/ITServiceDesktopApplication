using System;
using System.Collections.Generic;
using System.Linq;
using BitServices.Model;
using BitServices.Commands;
using System.Data;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace BitServices.ViewModel
{
    class ContractorPaymentViewModel : NotificationClass
    {
        // This class is the communication class between your view(PaymentManagement.Xaml) and to your Model (Payment.cs)
        // Create a list that will generated from Database

        private ObservableCollection<Payment> paymentCollection = new ObservableCollection<Payment>();
        public ObservableCollection<Payment> PaymentCollection
        {
            get { return paymentCollection; }
        }
        // Constructor of this viewModel
        public ContractorPaymentViewModel()
        {
            //1. Its going to connect to DAL and bring in the results of all Instructors
            //2. we Create objects of type instructor and then add that object to our collection
            DAL dal = new DAL();
            DataTable dt = dal.Read("Select * from bit_payment");
            foreach (DataRow dr in dt.Rows)
            {
                Payment payment = new Payment(dr);
                PaymentCollection.Add(payment);
            }
        }
    }

}

