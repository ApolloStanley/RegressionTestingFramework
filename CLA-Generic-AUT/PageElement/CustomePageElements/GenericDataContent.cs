using CLA_Generic_AUT.PageObjects.Attributes;
using OpenQA.Selenium;

namespace CLA_Generic_AUT.PageElement.CustomePageElements
{
    public class GenericDataContent<T> : PageElementBase where T : IMetaDataCards
    {
        public T DataValues { get; private set; }

        public GenericDataContent(IWebElement element) : base(element)
        {
            GetMetaData();
        }

        private void GetMetaData()
        {
            var childType = typeof(T);

            var childProperties = childType.GetProperties();

            DataValues = (T)Activator.CreateInstance(childType);

            foreach (var prop in childProperties)
            {
                try
                {
                    var attributes = prop.GetCustomAttributes(typeof(ElementPathAttributeBase), true);
                    var pathAttribute = attributes.FirstOrDefault() as ElementPathAttributeBase;
                    var newValue = ThisElement.FindElement(pathAttribute.GetElementPath());
                    var newInstante = Activator.CreateInstance(prop.PropertyType, new object[] { newValue }) as PageElementBase;
                    prop.SetValue(DataValues, newInstante);
                }
                catch
                {
                    // ignore exception
                }
            }
        }
    }
}
