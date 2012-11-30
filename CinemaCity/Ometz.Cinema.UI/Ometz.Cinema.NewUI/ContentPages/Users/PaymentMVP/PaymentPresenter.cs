using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ometz.Cinema.BLL.Users;

namespace Ometz.Cinema.UI.ContentPages.Users.PaymentMVP
{
    public class PaymentPresenter
    {
        public IPaymentView PaymentView { get; set; }

        public PaymentPresenter(IPaymentView MyView)
        {
            PaymentView = MyView;
            PaymentView.LoadData += LoadData;
            PaymentView.Submit += Submit;

        }

        private void LoadData(PerformanceDataArgs pda)
        {
            String PerformanceID = pda.PerformanceID;
            IUser UserServices = new UserServices();
            int performanceID;
            bool isInt = int.TryParse(PerformanceID, out performanceID);
            if (isInt)
            {
                UserPerformanceDTO CurrentPerformance = new UserPerformanceDTO();
                CurrentPerformance = UserServices.GetPerformanceByID(performanceID);
                this.PaymentView.Model.MovieTitle = CurrentPerformance.MovieTitle;
                string theaterDetails = string.Format("{0}, {1}.", CurrentPerformance.TheaterName, CurrentPerformance.TheaterAddress);
                this.PaymentView.Model.TheaterDetails = theaterDetails;
                string performance = string.Format("Date: {0}, Starting Time: {1}, Duration: {2}, Hall: {3}.",
                    CurrentPerformance.Date,
                    CurrentPerformance.StartingTime,
                    CurrentPerformance.Duration,
                    CurrentPerformance.roomNumber);
                this.PaymentView.Model.PerformanceDetails = performance;
                this.PaymentView.Model.Price = CurrentPerformance.price.ToString();

            }

        }

        private void Submit(OrderArgs or)
        {
            IUser UserServices = new UserServices();
            int performanceID = or.PerformanceID;
            UserOrderDTO NewOrder = new UserOrderDTO();
            NewOrder.PerformanceID = performanceID;
            Guid UserID = UserServices.GetUserID(or.UserName);
            NewOrder.UserID = UserID;
            NewOrder.NumberOfSeats = or.NumberOfSeats;
            NewOrder.TotalPrice = or.TotalPrice;
            UserOrderDTO OrderOut = new UserOrderDTO();
            OrderOut = UserServices.CreateOrder(NewOrder);
            if (OrderOut.isValid)
            {
                this.PaymentView.Model.ValidOrder = string.Format("The order was processed correctely, your order number: {0}, Enjoy the movie.",
                    OrderOut.OrderID.ToString());
                this.PaymentView.Model.IsValidOrder = true;
            }
            else
            {
                this.PaymentView.Model.ValidOrder = string.Format("The order was not saved, please try again or contact cutomer service.");
                this.PaymentView.Model.IsValidOrder = false;
            }


        }
    }

    //=========DELEGATES=============

    public delegate void DataLoadHandler(PerformanceDataArgs pda);
    public delegate void ButtonSubmitHandler(OrderArgs or);


    //==========Event Args==============

    public class PerformanceDataArgs : EventArgs
    {
        public String PerformanceID { get; set; }

    }

    public class OrderArgs : EventArgs
    {
        public int NumberOfSeats { get; set; }
        public decimal TotalPrice { get; set; }
        public int PerformanceID { get; set; }
        public String UserName { get; set; }
    }
}