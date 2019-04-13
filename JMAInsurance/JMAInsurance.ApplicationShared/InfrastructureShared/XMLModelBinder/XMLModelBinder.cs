using System;
using System.Web.Mvc;
using System.Xml.Serialization;

namespace JMAInsurance.ApplicationShared.InfrastructureShared.XMLModelBinder
{
    public class XMLModelBinder : IModelBinder
    {
      

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            try
            {
                var modelType = bindingContext.ModelType;
                //XmlSerializer serializer = new XmlSerializer(typeof(string), new XmlRootAttribute("response"));

                var serializer = new XmlSerializer(modelType);

                var inputStream = controllerContext.HttpContext.Request.InputStream;

                return serializer.Deserialize(inputStream);
            }
            catch (Exception ex)
            {
                bindingContext.ModelState.AddModelError("", "The item could not be serialized");
                return null;
            }
        }
    }
}
