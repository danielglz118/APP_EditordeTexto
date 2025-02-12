using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace APP_EditordeTexto
{
    public partial class frmEditor : Form
    {

        bool archguardado = false;
        string filePath;
        public frmEditor()
        {
            InitializeComponent();
        }

        private void frmEditor_Load(object sender, EventArgs e)
        {

        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!archguardado)
            {
                DialogResult result = MessageBox.Show("¿Desea guardar los cambios?", "Confirmar", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    guardarToolStripMenuItem_Click(sender, e);
                }
                else if (result == DialogResult.Cancel)
                {
                    return;
                }
            }

            rtbEditor.Clear();
            filePath = string.Empty;
            archguardado = false;
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult resultado;
            resultado = openFileDialogEditor.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                filePath = openFileDialogEditor.FileName;
                try
                {
                    String texto = File.ReadAllText(filePath);
                    rtbEditor.Text = texto;
                    archguardado = true;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar el archivo" + ex.Message);
                }
            }
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult resultado;
            if (archguardado == false)
            {
                resultado = saveFileDialogEditor.ShowDialog();

                if (resultado == DialogResult.OK)
                {
                    filePath = saveFileDialogEditor.FileName;
                    string texto = rtbEditor.Text;
                    try
                    {
                        File.WriteAllText(filePath, texto);
                        MessageBox.Show("Archivo guardado correctamente");
                        archguardado = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al guardar el archivo" + ex.Message);
                    }
                }
            }
            else
                try
                {
                    string texto = rtbEditor.Text;
                    File.WriteAllText(filePath, texto);
                    MessageBox.Show("Archivo guardado correctamente");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar el archivo" + ex.Message);
                }
        }

        private void guardarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialogEditor.FileName = "";
            saveFileDialogEditor.Filter = "Archivos de Texto (*.txt)|*.txt|Todos los Archivos (*.*)|*.*";
            DialogResult resultado = saveFileDialogEditor.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                filePath = saveFileDialogEditor.FileName;
                try
                {
                    File.WriteAllText(filePath, rtbEditor.Text);
                    MessageBox.Show("Archivo guardado correctamente");
                    archguardado = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar el archivo: " + ex.Message);
                }
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("¿Deseas salir?", "Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (res == DialogResult.Yes)
            {
                this.Close();
            }
    }
}
    }