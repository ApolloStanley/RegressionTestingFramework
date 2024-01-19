using CLA_Generic_AUT.WebHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLA_Generic_AUT.PageObjects
{
    public class PageObjectBase: IPageObject
    {

        protected IWebHandler webHandler;
        protected string URL;

        public PageObjectBase(IWebHandler webHandler, string URL)
        {
            this.webHandler = webHandler;
            this.URL = URL;
        }

        public PageObjectBase(IWebHandler webHandler)
        {
            this.webHandler = webHandler;
        }


        public void NavigateTo()
        {
            webHandler.Navigate(URL);
        }


    }
}
