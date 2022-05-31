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
    public partial class Default : System.Web.UI.Page
    {
        private IClientesDAL clienteDAL = new ClientesDALObjetos();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void agregarBtn_Click(object sender, EventArgs e)
        {
            //1. obtener los datos del formulario
            string nombre = this.nombreTxt.Text.Trim();
            string rut = this.rutTxt.Text.Trim();
            //esto obtine el valor del dropdown
            string bebidaValor = this.bebidaDdl.SelectedValue;
            //esto obtiene el texto
            string bebidaTexto = this.bebidaDdl.SelectedItem.Text;
            int nivel = Convert.ToInt32(this.nivelRbl.SelectedItem.Value);
            //2. construir el objeto de tipo cliente
            Bebida bebida = new Bebida()
            {
                Codigo = bebidaValor,
                Nombre = bebidaTexto
            };

            Cliente cliente = new Cliente()
            {
                Nombre = nombre,
                Rut = rut,
                Nivel = nivel,
                BebidaFavorita = bebida
            };

            //3. Llammar al DAL
            clienteDAL.Agregar(cliente);
            //4. Mostrar mensaje de exito
            this.mensajeslbl.Text = "Cliente Ingresado";

        }
    }
}