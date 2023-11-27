using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Piloto
{
    public partial class _Default : Page
    {
            private static string palabraSecreta = "ahorcado";
            private static List<char> letrasCorrectas = new List<char>();
            private static List<char> letrasIncorrectas = new List<char>();
            private static int errores = 1;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InicializarJuego();
                MostrarPalabraSecreta();
            }
        }

        protected void InicializarJuego()
        {
            Session["palabraSecreta"] = "ahorcado";
            Session["letrasCorrectas"] = new List<char>();
            Session["letrasIncorrectas"] = new List<char>();
            Session["errores"] = 0;
        }

        protected void ActualizarImagen()
        {
            int errores = (int)Session["errores"];
            string url = $"/IMG/{errores}.png";
            Image1.ImageUrl = url;
        }

        protected void btnIntentar_Click(object sender, EventArgs e)
        {
            char letra = txtLetra.Text.ToLower()[0];

            List<char> letrasCorrectas = (List<char>)Session["letrasCorrectas"];
            List<char> letrasIncorrectas = (List<char>)Session["letrasIncorrectas"];
            int errores = (int)Session["errores"];

            if (!letrasCorrectas.Contains(letra))
            {
                letrasCorrectas.Add(letra);

                // Verificar si la letra está en la palabra secreta
                string palabraSecreta = (string)Session["palabraSecreta"];
                if (palabraSecreta.Contains(letra))
                {
                    MostrarPalabraSecreta();
                    lblMensaje.Text = "¡Letra correcta!";
                }
                else
                {
                    lblMensaje.Text = "¡Letra incorrecta!";
                    errores++;
                    Session["errores"] = errores;
                    ActualizarImagen();
                    letrasIncorrectas.Add(letra);
                    Session["letrasIncorrectas"] = letrasIncorrectas;
                    lblLetrasWrong.Text = string.Join("-", letrasIncorrectas);
                    if (errores == 5)
                    {
                        btnIntentar.Enabled = false;
                        lblMensaje.Text = "Fuiste ahorcado!";
                    }
                }

                // Verificar si el jugador ha adivinado la palabra
                string palabraMostrada = MostrarPalabraSecreta();
                if (!palabraMostrada.Contains("_"))
                {
                    lblMensaje.Text = "¡Felicidades! ¡Has adivinado la palabra!";
                    btnIntentar.Enabled = false;
                }
            }
            else
            {
                lblMensaje.Text = "Ya has intentado esa letra. Intenta con otra.";
            }

            txtLetra.Text = "";
        }

        private string MostrarPalabraSecreta()
        {
            string palabraMostrada = "";
            string palabraSecreta = (string)Session["palabraSecreta"];
            List<char> letrasCorrectas = (List<char>)Session["letrasCorrectas"];

            foreach (char letra in palabraSecreta)
            {
                if (letrasCorrectas.Contains(letra))
                {
                    palabraMostrada += letra + " ";
                }
                else
                {
                    palabraMostrada += "_ ";
                }
            }

            lblPalabra.Text = palabraMostrada.Trim();
            return palabraMostrada;
        }
        }
    }