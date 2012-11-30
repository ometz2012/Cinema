using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ometz.Cinema.UI.ContentPages.Users.MyAreaMVP
{
   public interface IMyAreaView
    {
       event DataLoadHandler LoadData;
       event GridUpdateHandler GridUpdate;
       event GridUpdateHandler RemoveMovie;


       MyAreaModel Model { get; set; }
       MyAreaPresenter Presenter { get; set; }
       
    }
}
