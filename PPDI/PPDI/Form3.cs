using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PPDI
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            string string1 = "Aplicación de filtros para fotos y videos, con histograma incluido";
            string string2 = "En el menú se encuentran 3 pestañas: 'Archivo', 'Editar' y 'Ayuda'.";
            string string3 = "En la pestaña de Archivo se encuentra 2 opciones para subir archivos, imagen o video, " +
                "en la pestana de Editar esta la opcion de borrar todos los filtros aplicados de la imagen o de el video " +
                "y por ultimo en la pestaña Ayuda esta el manual de usuario indicando como funciona la publicación.";
            string string4 = "Despues de agregar una imagen o un video se habilitarán los botones de los filtros, que" +
                "al dejar el cursor arriba de uno, te notificará que filtro es el que estas seleccionando.";
            string string5 = "Debajo de los filtros a escojer se encuentra un textbox con el nombre de donde esta" +
                "localizado el archivo que se abrió y debajo de eso esta la misma imagen cargada pero en miniatura.";
            string string6 = "A la derecha de la aplicación estan los 3 histogramas de los colores de la imagen en RGB y finalizando" +
                "abajo de todo se encuentra el botón guardar, para como dice su nombre, guardar el archivo que este mostrado en pantalla.";

            richTextBox1.Text = string1 + System.Environment.NewLine + 
                                string2 + System.Environment.NewLine + 
                                string3 + System.Environment.NewLine +
                                string4 + System.Environment.NewLine +
                                string5 + System.Environment.NewLine +
                                string6;

        }
    }
}
