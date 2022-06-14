using StarCapModel;
using StarCapModel.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StarCapWeb
{
    public partial class VerCliente : System.Web.UI.Page
    {
        private IClientesDAL clientesDAL = new ClientesDALObjetos();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarGrilla();
            }
        }

        private void cargarGrilla()
        {
            List<Cliente> clientes = clientesDAL.Obtener();
            this.grillaClientes.DataSource = clientes;
            this.grillaClientes.DataBind();
        }
        protected void grillaClientes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "eliminar")
            {
                //signfica que el usuario apreto el boton eliminar
                //por ende, tengo que eliminar el cliente
                string rut = Convert.ToString(e.CommandArgument);
                clientesDAL.Eliminar(rut);
                cargarGrilla();
            }
        }
    }
}