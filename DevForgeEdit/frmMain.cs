using System.DirectoryServices.ActiveDirectory;

namespace DevForgeEdit
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private bool isModificado = false;

        private void AbrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new()
            {
                Filter = "Arquivos de Texto (*.txt)|*.txt|Todos os arquivos (*.*)|*.*",
                FilterIndex = 1,
                RestoreDirectory = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using StreamReader sr = new(openFileDialog1.FileName);
                    txtConteudo.Text = sr.ReadToEnd();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao abrir o arquivo: " + ex.Message);
                }
            }
        }

        private void SalvarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new()
            {
                Filter = "Arquivos de Texto (*.txt)|*.txt|Todos os arquivos (*.*)|*.*",
                FilterIndex = 1,
                RestoreDirectory = true
            };

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using StreamWriter sw = new(saveFileDialog1.FileName);
                    sw.Write(txtConteudo.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao salvar o arquivo: " + ex.Message);
                }
            }
        }

        private void SairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isModificado)
            {
                var confirma = MessageBox.Show("O texto foi modificado, quer salvar as modificações?", "Confirmação",
                    MessageBoxButtons.YesNo);
                if (confirma == DialogResult.Yes)
                {
                    SalvarToolStripMenuItem_Click(null, null);
                }
            }
            Application.Exit();
        }

        private void txtConteudo_ModifiedChanged(object sender, EventArgs e)
        {
            isModificado = true;
        }
    }
}
