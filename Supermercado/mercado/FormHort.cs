using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace mercado
{
    public partial class FormHort : Form
    {
        private readonly string connectionString = "Server=localhost;Database=mercadoleoisa;Uid=root;Pwd=;";

        public FormHort()
        {
            InitializeComponent();
        }

        private void btnGerarEtiqueta_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtCodigo.Text.Trim(), out int codigoInt))
                {
                    MessageBox.Show("Código inválido. Informe um número inteiro.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string partProd = codigoInt.ToString("D4");

                // parse peso em kg como decimal
                if (!decimal.TryParse(txtPesoTeste.Text.Trim().Replace(',', '.'), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out decimal pesoKg))
                {
                    MessageBox.Show("Peso inválido. Use formato 5.190 para 5,190 kg.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int gramas = (int)Math.Round(pesoKg * 1000m);
                string partPeso = gramas.ToString("D5");

                string etiqueta = partProd + partPeso;
                lblCodigoGerado.Text = etiqueta;
                try { Clipboard.SetText(etiqueta); } catch { }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao gerar etiqueta: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                string codigo = txtCodigo.Text.Trim();
                string nome = txtNome.Text.Trim();
                if (string.IsNullOrEmpty(codigo) || string.IsNullOrEmpty(nome))
                {
                    MessageBox.Show("Informe código e nome do produto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!decimal.TryParse(txtPrecoKg.Text.Trim().Replace(',', '.'), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out decimal precoKg))
                {
                    MessageBox.Show("Preço inválido.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!decimal.TryParse(txtEstoqueKg.Text.Trim().Replace(',', '.'), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out decimal estoqueKg))
                {
                    MessageBox.Show("Estoque inválido.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (var conn = new MySqlConnection(connectionString))
                using (var cmd = conn.CreateCommand())
                {
                    conn.Open();

                    // verifica se existe
                    cmd.CommandText = "SELECT id FROM produtos WHERE codigo = @codigo LIMIT 1";
                    cmd.Parameters.AddWithValue("@codigo", codigo);
                    var exists = cmd.ExecuteScalar();
                    if (exists != null)
                    {
                        // atualiza
                        cmd.Parameters.Clear();
                        cmd.CommandText = "UPDATE produtos SET nome=@nome, valor=@valor, quantidade=@qtd WHERE codigo=@codigo";
                        cmd.Parameters.AddWithValue("@nome", nome);
                        cmd.Parameters.AddWithValue("@valor", precoKg);
                        cmd.Parameters.AddWithValue("@qtd", estoqueKg);
                        cmd.Parameters.AddWithValue("@codigo", codigo);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Produto atualizado com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        cmd.Parameters.Clear();
                        cmd.CommandText = "INSERT INTO produtos (codigo, nome, valor, quantidade) VALUES (@codigo, @nome, @valor, @qtd)";
                        cmd.Parameters.AddWithValue("@codigo", codigo);
                        cmd.Parameters.AddWithValue("@nome", nome);
                        cmd.Parameters.AddWithValue("@valor", precoKg);
                        cmd.Parameters.AddWithValue("@qtd", estoqueKg);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Produto cadastrado com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1062)
                    MessageBox.Show("Código duplicado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                    MessageBox.Show("Erro MySQL: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar produto: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f is Form1)
                {
                    f.Show();
                    this.Close();
                    return;
                }
            }
            new Form1().Show();
            this.Close();
        }
    }
}
