using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HolaMundoWEB
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void salurdarbtn_Click(object sender, EventArgs e)
        {
            //para los asp components, la propiedad para obtener el valor es TEXT
            string nombre = this.nombretxt.Text.Trim();

            //para los HTMLElements, la propiedad es InnerText
            this.mensajeH1.InnerText = "Hola "+nombre + " , no dejes de venir a clases";

        }
    }
}