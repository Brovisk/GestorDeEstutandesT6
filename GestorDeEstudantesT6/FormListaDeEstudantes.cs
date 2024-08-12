using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestorDeEstudantesT6
{
    public partial class FormListaDeEstudantes : Form
    {
        public FormListaDeEstudantes()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonAtualizar_Click(object sender, EventArgs e)
        {
            //Atualiza a lista de estudantes.
        }

        Estudante estudante = new Estudante();

        private void FormListaDeEstudantes_Load(object sender, EventArgs e)
        {
            MySqlCommand comando = new MySqlCommand("SELECT * FROM ´estudantes`");
            dataGridViewListaDeEstudantes.ReadOnly = true;
            DataGridViewImageColumn colunaDeFotos = new DataGridViewImageColumn();
            dataGridViewListaDeEstudantes.RowTemplate.Height = 80;
            dataGridViewListaDeEstudantes.DataSource = estudante.pegarEstudantes(comando);
            colunaDeFotos = (DataGridViewImageColumn)dataGridViewListaDeEstudantes.Columns[7];
            colunaDeFotos.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridViewListaDeEstudantes.AllowUserToAddRows = false;
        }

        private void dataGridViewListaDeEstudantes_DoubleClick(object sender, EventArgs e)
        {
            //Abre as informações do aluno selecionado em uma nova janela.
            FormAtualizarApagarAlunos formAtualizarApagarAlunos = new FormAtualizarApagarAlunos();
            formAtualizarApagarAlunos.textBoxId.Text = dataGridViewListaDeEstudantes.CurrentRow.Cells[0].Value.ToString();
            formAtualizarApagarAlunos.textBoxNome.Text =
                dataGridViewListaDeEstudantes.CurrentRow.Cells[1].Value.ToString();
            formAtualizarApagarAlunos.textBoxSobrenome.Text =
                dataGridViewListaDeEstudantes.CurrentRow.Cells[2].Value.ToString();

            formAtualizarApagarAlunos.dateTimePickerNascimento.Value =
                (DateTime) dataGridViewListaDeEstudantes.CurrentRow.Cells[3].Value;

            if (dataGridViewListaDeEstudantes.CurrentRow.Cells[4].Value.ToString() == "Feminino")
            {
                formAtualizarApagarAlunos.radioButtonFeminino.Checked = true;
            }
            else
            {
                formAtualizarApagarAlunos.radioButtonMasculino.Checked = true;
            }
            formAtualizarApagarAlunos.textBoxTelefone.Text =
                dataGridViewListaDeEstudantes.CurrentRow.Cells[5].Value.ToString();
            formAtualizarApagarAlunos.textBoxEndereco.Text =
                dataGridViewListaDeEstudantes.CurrentRow.Cells[6].Value.ToString();

            // A foto do Aluno
            byte[] imagem;
            imagem = (byte[])dataGridViewListaDeEstudantes.CurrentRow.Cells[7].Value; 
            MemoryStream foto = new MemoryStream(imagem);

            formAtualizarApagarAlunos.pictureBoxFoto.Image =
                Image.FromStream(foto);

            formAtualizarApagarAlunos.Show();

            formAtualizarApagarAlunos.Show();
        }
    }
}
