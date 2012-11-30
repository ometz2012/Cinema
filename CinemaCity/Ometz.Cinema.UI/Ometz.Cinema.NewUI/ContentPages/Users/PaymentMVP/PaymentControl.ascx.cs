using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;


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
            Int64 creaditCardNumber = 0;
            args.IsValid = Int64.TryParse(args.Value, out creaditCardNumber);
        }

        protected void txtTicketsAmount_TextChanged(object sender, EventArgs e)
        {
            decimal price = decimal.Parse(txtPrice.Text);
            decimal amount;
            bool isDecimal = decimal.TryParse(txtTicketsAmount.Text, out amount);
            ValidatorTicketAmountINT.IsValid = isDecimal;
            if (isDecimal)
            {
                decimal total = price * amount;
                txtTotal.Text = total.ToString();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (txbCreditCardNumber.Text.Length < 16 || ddlMonth.SelectedValue.Equals("0") || ddlYear.SelectedValue.Equals("0"))
                {
                    ValidatorEmptyText.IsValid = false;
                    throw new Exception();
                }
                else
                {
                    if (this.Submit != null)
                    {
                        OrderArgs or = new OrderArgs();
                        or.NumberOfSeats = int.Parse(txtTicketsAmount.Text);
                        or.PerformanceID = int.Parse(this.PerformanceID);
                        or.TotalPrice = decimal.Parse(txtTotal.Text);
                        or.UserName = System.Web.HttpContext.Current.User.Identity.Name;

                        Submit(or);

                        if (this.Model.IsValidOrder)
                        {
                            lblOrderDetails.Text = this.Model.ValidOrder;
                            lblOrderDetails.BackColor = Color.LightGreen;
                            lblOrderDetails.Focus();
                            btnSubmit.Enabled = false;
                            btnConfirmTickets.Enabled = false;
                        }
                        else
                        {
                            lblOrderDetails.Text = this.Model.ValidOrder;
                            lblOrderDetails.BackColor = Color.OrangeRed;
                            lblOrderDetails.Focus();
                        }

                    }

                }

            }
            catch { }


        }


    }
}