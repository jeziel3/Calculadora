using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization; // <-- ¡Importante: Agrega esta librería arriba!

namespace mi_Calcu
{
    public partial class Form1 : Form
    {
        double numero1 = 0;
        double numero2 = 0;
        string operacion = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void lbl_titulo_Click(object sender, EventArgs e) { }

        // --- BOTONES DE NÚMEROS ---
        private void btn_0_Click(object sender, EventArgs e)
        { txt_resultado.Text += "0"; }
        private void btn_1_Click(object sender, EventArgs e) 
        { txt_resultado.Text += "1"; }
        private void btn_2_Click(object sender, EventArgs e) 
        { txt_resultado.Text += "2"; }
        private void btn_3_Click(object sender, EventArgs e) 
        { txt_resultado.Text += "3"; }
        private void btn_4_Click(object sender, EventArgs e) 
        { txt_resultado.Text += "4"; }
        private void btn_5_Click(object sender, EventArgs e) 
        { txt_resultado.Text += "5"; }
        private void btn_6_Click(object sender, EventArgs e) 
        { txt_resultado.Text += "6"; }
        private void btn_7_Click(object sender, EventArgs e) 
        { txt_resultado.Text += "7"; }
        private void btn_8_Click(object sender, EventArgs e) 
        { txt_resultado.Text += "8"; }
        private void btn_9_Click(object sender, EventArgs e)
        { txt_resultado.Text += "9"; }

        // --- BOTÓN PUNTO ---
        private void btn_punto_Click(object sender, EventArgs e)
        {
            if (!txt_resultado.Text.Contains("."))
            {
                if (txt_resultado.Text == "")
                {
                    txt_resultado.Text = "0";
                }
                txt_resultado.Text += ".";
            }
        }

        // --- BOTONES DE OPERACIONES ---
        private void btn_suma_Click(object sender, EventArgs e)
        {
            if (txt_resultado.Text != "")
            {
                // Usamos InvariantCulture para que lea el punto sin importar el idioma de Windows
                numero1 = Convert.ToDouble(txt_resultado.Text, CultureInfo.InvariantCulture);
                operacion = "+";
                txt_resultado.Clear();
            }
        }

        private void btn_resta_Click(object sender, EventArgs e)
        {
            if (txt_resultado.Text != "")
            {
                numero1 = Convert.ToDouble(txt_resultado.Text, CultureInfo.InvariantCulture);
                operacion = "-";
                txt_resultado.Clear();
            }
        }

        private void btn_multi_Click(object sender, EventArgs e)
        {
            if (txt_resultado.Text != "")
            {
                numero1 = Convert.ToDouble(txt_resultado.Text, CultureInfo.InvariantCulture);
                operacion = "*";
                txt_resultado.Clear();
            }
        }

        private void btn_division_Click(object sender, EventArgs e)
        {
            if (txt_resultado.Text != "")
            {
                numero1 = Convert.ToDouble(txt_resultado.Text, CultureInfo.InvariantCulture);
                operacion = "/";
                txt_resultado.Clear();
            }
        }

        // --- BOTÓN IGUAL ---
        private void btn_igual_Click(object sender, EventArgs e)
        {
            if (txt_resultado.Text != "")
            {
                numero2 = Convert.ToDouble(txt_resultado.Text, CultureInfo.InvariantCulture);
                double resultado = 0;

                switch (operacion)
                {
                    case "+":
                        resultado = numero1 + numero2;
                        break;
                    case "-":
                        resultado = numero1 - numero2;
                        break;
                    case "*":
                        resultado = numero1 * numero2;
                        break;
                    case "/":
                        // Validación de división entre cero
                        if (numero2 == 0)
                        {
                            MessageBox.Show("No se puede dividir entre cero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txt_resultado.Clear();
                            return;
                        }
                        resultado = numero1 / numero2;
                        break;
                }

                // Mostramos el resultado asegurando que use el punto como separador decimal
                txt_resultado.Text = resultado.ToString(CultureInfo.InvariantCulture);
            }
        }

        // --- BOTÓN ELIMINAR / LIMPIAR (C) ---
        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            txt_resultado.Clear();
            numero1 = 0;
            numero2 = 0;
            operacion = "";
        }
    }
}