using CLA_Generic_AUT.WebHandler;
using OpenQA.Selenium;

namespace CLA_Generic_AUT.PageElement.CustomePageElements
{
    public class GenericCollectionOfObject<T> : PageElementBase where T : IMetaDataCards
    {
        public List<GenericDataContent<T>> MetaDataContents { get; set; }

        private IWebHandler webHandler;

        public GenericCollectionOfObject(By by, IWebHandler webHandler) : base(by, webHandler)
        {
            this.webHandler = webHandler;
            LoadSubElements(by);
        }

        public GenericCollectionOfObject(By by, IWebHandler webHandler, TimeSpan timeOut) : base(by, webHandler, timeOut)
        {
            this.webHandler = webHandler;
            LoadSubElements(by);
        }

        private void LoadSubElements(By by)
        {
            MetaDataContents = webHandler.GetElements(by).Select(x => new GenericDataContent<T>(x)).ToList();
        }

        public GenericDataContent<T> FindElementWithHeader(string HeaderValue)
        {
            return MetaDataContents.Where(x => x.DataValues.HeaderTitle.Text.ToLower().Contains(HeaderValue.ToLower())).FirstOrDefault();
        }
    }
}
