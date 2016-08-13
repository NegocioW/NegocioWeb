using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFNEGOGOCIO
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IProductoService" in both code and config file together.
    [ServiceContract]
    public interface IProductoService
    {
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "ObtenerProductos", ResponseFormat = WebMessageFormat.Json)]
        DataTable ObtenerProductos();
         [OperationContract]
         [WebInvoke(Method = "GET", UriTemplate = "ObtenerDatos/{Codigo}", ResponseFormat = WebMessageFormat.Json)]
        Producto ObtenerDatos(int Codigo);

         [OperationContract]
         [WebInvoke(Method = "POST", UriTemplate = "ActualizarProd", ResponseFormat = WebMessageFormat.Json)]
         string ActualizarProd(Producto varProduct);

         [OperationContract]
         [WebInvoke(Method = "POST", UriTemplate = "InsertarProd", ResponseFormat = WebMessageFormat.Json)]
         string InsertarProd(Producto varProduct);
    }
}
