using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using Ometz.Cinema.BLL;

namespace Ometz.Cinema.UI.ContentPages.Users.PaymentMVP
{
    public partial class PaymentControl : System.Web.UI.UserControl, IPaymentView
    {

        public event DataLoadHandler LoadData;
        public event ButtonSubmitHandler Submit;

        public PaymentModel Model { get; set; }
        public PaymentPresenter Presenter { get; set; }

        [Browsable(true)]
        public String PerformanceID { get; set; }
        [Browsable(true)]
        public String UserID { get; set; }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Model = new PaymentModel();
            this.Presenter = new PaymentPresenter(this);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (this.PerformanceID != null)
                {

                    if (LoadData != null)
                    {
                        PerformanceDataArgs pda = new PerformanceDataArgs();
                        pda.PerformanceID = this.PerformanceID;
                        LoadData(pda);
                       
                        lblMovie.Text = Model.MovieTitle;
                        lblPerformance.Text = Model.PerformanceDetails;
                        lblTheater.Text = Model.TheaterDetails;
                        txtPrice.Text = Model.Price;

                    }
                }

            }
        }



        protected void ValidatorTicketAmountINT_ServerValidate(object source, ServerValidateEventArgs args)
        {
            int amount = 0;
            args.IsValid = int.TryParse(args.Value, out amount);
        }

        protected void ValidatorInteger_ServerValidate(object source, ServerValidateEventArgs args)
        {
            int creaditCardNumber = 0;
            args.IsValid = int.TryParse(args.Value, out creaditCardNumber);
        }

        protected void txtTicketsAmount_TextChanged(object sender, EventArgs e)
        {
            decimal price = decimal.Parse(txtPrice.Text);
            decimal amount;
            ValidatorTicketAmountINT.IsValid = decimal.TryParse(txtTicketsAmount.Text, out amount);
            decimal total = price * amount;
            txtTotal.Text = total.ToString();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (this.Submit != null)
            {
                OrderArgs or = new OrderArgs();
                or.NumberOfSeats = int.Parse(txtTicketsAmount.Text);
                or.PerformanceID = int.Parse(this.PerformanceID);
                or.TotalPrice = decimal.Parse(txtTotal.Text);
                or.UserID = this.UserID;
                Submit(or);
            }
        }
    }
}