using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace mercado
{
    public partial class FormRepositor : Form
    {
        // Ligação à base de dados MySQL local
        private readonly string connectionString = "Server=localhost;Database=mercadoleoisa;Uid=root;Pwd=;";

        // Guarda o ID do produto atualmente consultado para garantir a atualização correta
        private int idProdutoSelecionado = 0;

        public FormRepositor()
        {
            InitializeComponent();
        }

        // ==========================================
        // BOTÃO CADASTRAR (button1)
        // ==========================================
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) ||
                string.IsNullOrWhiteSpace(textBox4.Text))
            {
                MessageBox.Show("Por favor, preencha todos os campos do cadastro!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(textBox3.Text.Trim(), out int quantidade))
            {
                MessageBox.Show("A quantidade deve ser um número inteiro válido.", "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!decimal.TryParse(textBox4.Text.Trim().Replace(".", ","), out decimal valor))
            {
                MessageBox.Show("Informe um valor numérico válido para o preço.", "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string query = "INSERT INTO produtos (codigo, nome, quantidade, valor) VALUES (@codigo, @nome, @quantidade, @valor)";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@codigo", textBox1.Text.Trim());
                        cmd.Parameters.AddWithValue("@nome", textBox2.Text.Trim());
                        cmd.Parameters.AddWithValue("@quantidade", quantidade);
                        cmd.Parameters.AddWithValue("@valor", valor);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Produto cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimparCampos();
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1062)
                {
                    MessageBox.Show("Este código de barras já se encontra cadastrado!", "Código Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Erro do MySQL (" + ex.Number + "): " + ex.Message, "Erro MySQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==========================================
        // BOTÃO EXCLUIR (button2)
        // ==========================================
        private void button2_Click(object sender, EventArgs e)
        {
            string codigoBarra = textBox5.Text.Trim();
            string codigoInterno = textBox6.Text.Trim();

            if (string.IsNullOrWhiteSpace(codigoBarra) && string.IsNullOrWhiteSpace(codigoInterno))
            {
                MessageBox.Show("Indique o Código de Barras ou o Código Interno para excluir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirmacao = MessageBox.Show("Tem a certeza de que deseja eliminar este produto?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmacao != DialogResult.Yes) return;

            string query;
            bool buscaPorCodigoBarra = !string.IsNullOrWhiteSpace(codigoBarra);

            if (buscaPorCodigoBarra)
            {
                query = "DELETE FROM produtos WHERE codigo = @codigo";
            }
            else
            {
                if (!int.TryParse(codigoInterno, out _))
                {
                    MessageBox.Show("O Código Interno deve ser um número inteiro!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                query = "DELETE FROM produtos WHERE id = @id";
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        if (buscaPorCodigoBarra)
                        {
                            cmd.Parameters.AddWithValue("@codigo", codigoBarra);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@id", Convert.ToInt32(codigoInterno));
                        }

                        int linhasAfetadas = cmd.ExecuteNonQuery();

                        if (linhasAfetadas > 0)
                        {
                            MessageBox.Show("Produto eliminado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimparCampos();
                        }
                        else
                        {
                            MessageBox.Show("Nenhum produto foi encontrado com esses dados.", "Não Encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==========================================
        // BOTÃO CONSULTAR ESTOQUE (button3)
        // ==========================================
        private void button3_Click(object sender, EventArgs e)
        {
            string codigoBarra = textBox5.Text.Trim();
            string codigoInterno = textBox6.Text.Trim();

            if (string.IsNullOrWhiteSpace(codigoBarra) && string.IsNullOrWhiteSpace(codigoInterno))
            {
                MessageBox.Show("Indique o Código de Barras ou o Código Interno para consultar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query;
            bool buscaPorCodigoBarra = !string.IsNullOrWhiteSpace(codigoBarra);

            if (buscaPorCodigoBarra)
            {
                query = "SELECT id, codigo, nome, quantidade, valor FROM produtos WHERE codigo = @codigo";
            }
            else
            {
                if (!int.TryParse(codigoInterno, out _))
                {
                    MessageBox.Show("O Código Interno deve ser um número inteiro!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                query = "SELECT id, codigo, nome, quantidade, valor FROM produtos WHERE id = @id";
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        if (buscaPorCodigoBarra)
                        {
                            cmd.Parameters.AddWithValue("@codigo", codigoBarra);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@id", Convert.ToInt32(codigoInterno));
                        }

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                idProdutoSelecionado = Convert.ToInt32(reader["id"]);

                                // Preenche automaticamente os campos da esquerda para permitir edição direta
                                textBox1.Text = reader["codigo"].ToString();
                                textBox2.Text = reader["nome"].ToString();
                                textBox3.Text = reader["quantidade"].ToString();
                                textBox4.Text = Convert.ToDecimal(reader["valor"]).ToString("N2");

                                MessageBox.Show("Produto carregado nos campos da esquerda!\nPode alterar os dados e clicar em ATUALIZAR.", "Produto Carregado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                idProdutoSelecionado = 0;
                                MessageBox.Show("Produto não encontrado no stock.", "Consulta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao consultar: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==========================================
        // BOTÃO ATUALIZAR (button4)
        // ==========================================
        private void button4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) ||
                string.IsNullOrWhiteSpace(textBox4.Text))
            {
                MessageBox.Show("Consulte ou preencha os dados do produto nos campos da esquerda antes de atualizar!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(textBox3.Text.Trim(), out int quantidade))
            {
                MessageBox.Show("A quantidade deve ser um número inteiro válido.", "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!decimal.TryParse(textBox4.Text.Trim().Replace(".", ","), out decimal valor))
            {
                MessageBox.Show("Informe um valor numérico válido.", "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Atualiza por ID caso já tenha sido consultado previamente; caso contrário, atualiza pelo código de barras
            string query;
            if (idProdutoSelecionado > 0)
            {
                query = "UPDATE produtos SET codigo = @codigo, nome = @nome, quantidade = @quantidade, valor = @valor WHERE id = @id";
            }
            else
            {
                query = "UPDATE produtos SET nome = @nome, quantidade = @quantidade, valor = @valor WHERE codigo = @codigo";
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@codigo", textBox1.Text.Trim());
                        cmd.Parameters.AddWithValue("@nome", textBox2.Text.Trim());
                        cmd.Parameters.AddWithValue("@quantidade", quantidade);
                        cmd.Parameters.AddWithValue("@valor", valor);

                        if (idProdutoSelecionado > 0)
                        {
                            cmd.Parameters.AddWithValue("@id", idProdutoSelecionado);
                        }

                        int linhasAfetadas = cmd.ExecuteNonQuery();

                        if (linhasAfetadas > 0)
                        {
                            MessageBox.Show("Produto atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimparCampos();
                        }
                        else
                        {
                            MessageBox.Show("Nenhum registo foi alterado. Verifique se o código de barras existe.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1062)
                {
                    MessageBox.Show("Já existe outro produto utilizando este código de barras!", "Código Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Erro MySQL: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimparCampos()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            idProdutoSelecionado = 0;
            textBox1.Focus();
        }

        // Redirecionamentos de segurança para eventos duplicados
        private void button2_Click_1(object sender, EventArgs e) => button2_Click(sender, e);
        private void button3_Click_1(object sender, EventArgs e) => button3_Click(sender, e);
        private void button4_Click_1(object sender, EventArgs e) => button4_Click(sender, e);

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