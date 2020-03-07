using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bilheteria
{
    public partial class Form1 : Form
    {
        //Método para receber o pagamento e retornar troco
        private double Pagar(double pago, double preco)
        {
            return pago - preco;
        }

        //Método para calculo do desconto para estudante
        private int Desconto()
        {
            return 10 * (int)numUpQtaEstudantes.Value;
        }

        //Método para calcular o preço total
        private double PrecoTot(int Ingsessao, int quantidade)
        {
            return Ingsessao * quantidade;
        }
        //Método para limpar todos os campos após finalização de compra
        private void Limpar()
        {
            txtFilme.Text = string.Empty;
            txtFaixaeta.Text = string.Empty;
            txtGenero.Text = string.Empty;
            txtPreco1.Text = string.Empty;
            txtPreco2.Text = string.Empty;
            txtPreco3.Text = string.Empty;
            txtPreco4.Text = string.Empty;
            txtPreco5.Text = string.Empty;
            txtPreco6.Text = string.Empty;
            txtPrecoFinal.Text = string.Empty;
            txtDesco.Text = string.Empty;
            txtTroco.Text = string.Empty;
            txtPedIngre.Text = string.Empty;
            numUpQtaEstudantes.Value = default;
            numUpIngressos.Value = default;
            radioButton2.Checked = false;
            radioButton1.Checked = false;
          
        }
        //Método para inserir os dados das sessões do filme escolhido
        private void Inserir(string nome, int fxaetaria, string genero, double preco, double preco3d)
        {
            txtFaixaeta.Text = fxaetaria.ToString();
            txtFilme.Text = nome;
            txtGenero.Text = genero;
            txtPreco1.Text = preco.ToString();
            txtPreco2.Text = preco3d.ToString();
            txtPreco3.Text = preco3d.ToString();
            txtPreco4.Text = preco3d.ToString();
            txtPreco5.Text = preco.ToString();
            txtPreco6.Text = preco3d.ToString();
        }
        
        //Método para descobrir idade para que posteriormente possa ser feita validação de acordo com faixa etária do filme
        private int Idade(DateTime dtaNascimento)
        {
            int idade = DateTime.Now.Year - dtaNascimento.Year;
            if (DateTime.Now.DayOfYear < dataNascimento.Value.DayOfYear)
            {
                idade = idade - 1;
            }
            return idade;
        }
        //Método para liberar validador e quantidade ingressos após escolha da sessão
        private void HabilitarValidador()
        {
            radioButton1.Enabled = true;
            radioButton2.Enabled = true;
            numUpIngressos.Enabled = true;
            btnValidar.Enabled = true;
            dataNascimento.Enabled = true;
        }
        //Método para liberar as sessões do filme selecionado
        private void HabilitarSessoes()
        {
            btnSes1.Enabled = true;
            btnSes2.Enabled = true;
            btnSes3.Enabled = true;
            btnSes4.Enabled = true;
            btnSes5.Enabled = true;
            btnSes6.Enabled = true;
        }
        //Método para desabilitar os campos selecionaveis após finalização de compra
        private void DesabilitarTudo()
        {
            btnSes1.Enabled = false;
            btnSes2.Enabled = false;
            btnSes3.Enabled = false;
            btnSes4.Enabled = false;
            btnSes5.Enabled = false;
            btnSes6.Enabled = false;
            radioButton1.Enabled = false;
            radioButton2.Enabled = false;
            numUpIngressos.Enabled = false;
            numUpQtaEstudantes.Enabled = false;
            btnValidar.Enabled = false;
            dataNascimento.Enabled = false;
        }
        //Método para desabilitar os campos de validação e ingresso caso haja mudança do filme selecionado
        private void DesabilitarValidadores()
        {
            radioButton1.Enabled = false;
            radioButton2.Enabled = false;
            numUpIngressos.Enabled = false;
            numUpQtaEstudantes.Enabled = false;
            btnValidar.Enabled = false;
            dataNascimento.Enabled = false;
        }
        
        //Criação dos objetos
        Filme terror = new Filme
        {
            Nome = "Assim Na Terra Como No Inferno",
            faixaEtaria = 16,
            Preco=20,
            Preco3D=30,
            Genero="Terror",
        };
        Filme suspense = new Filme
        {
            Nome = "Oito Mulheres e um Segredo",
            faixaEtaria=14,
            Preco=18,
            Preco3D=28,
            Genero="Suspense",
        };
        Filme animacao = new Filme
        {
            Nome = "Como Treinar o seu Dragão 3",
            faixaEtaria = 0,
            Preco=15,
            Preco3D=25,
            Genero="Animação",
        };
        Filme ficcao = new Filme
        {
            Nome = "Interestelar",
            faixaEtaria = 14,
            Preco = 20,
            Preco3D = 30,
            Genero = "Ficção Cientifica",
        };

        // Variavel para receber valor da sessão escolhida
        private int sessao;
            
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }
        
        //Botão com validação de idade de acordo com faixa etária
        private void BtnValidar_Click(object sender, EventArgs e)
        {
            
            int faixa = int.Parse(txtFaixaeta.Text);
            int resultado = Idade(dataNascimento.Value);
            if(resultado < faixa)
            {
                MessageBox.Show($"Pessoas com {resultado} anos não podem ver a este filme.");
            }
            else
            {
                MessageBox.Show("Validação Completa. Será exigido a comprovação de estudante na entrada da sala de sessão");
                btnPagar.Enabled = true;
            }

            txtPedIngre.Text = numUpIngressos.Value.ToString();
            txtDesco.Text = Desconto().ToString();
            txtPrecoFinal.Text = (PrecoTot(sessao, (int)numUpIngressos.Value) - Desconto()).ToString();
        }

        //Botões de recebimento sessão
        private void BtnMulheresSegredos_Click(object sender, EventArgs e)
        {
            Limpar();
            Inserir(suspense.Nome, suspense.faixaEtaria, suspense.Genero, suspense.Preco, suspense.Preco3D);
            DesabilitarValidadores();
            HabilitarSessoes();
        }

        private void BtnAssimNaTerra_Click(object sender, EventArgs e)
        {
            Limpar();
            Inserir(terror.Nome, terror.faixaEtaria, terror.Genero, terror.Preco, terror.Preco3D);
            DesabilitarValidadores();
            HabilitarSessoes();
        }

        private void BtnTreinarDragao_Click(object sender, EventArgs e)
        {
            Limpar();
            Inserir(animacao.Nome, animacao.faixaEtaria, animacao.Genero, animacao.Preco, animacao.Preco3D);
            DesabilitarValidadores();
            HabilitarSessoes();
        }

        private void BtnInterestelar_Click(object sender, EventArgs e)
        {
            Limpar();
            Inserir(ficcao.Nome, ficcao.faixaEtaria, ficcao.Genero, ficcao.Preco, ficcao.Preco3D);
            DesabilitarValidadores();
            HabilitarSessoes();
        }
        // //Botões recebimento preço sessão
        private void BtnSes1_Click(object sender, EventArgs e)
        {
           sessao = Convert.ToInt32(txtPreco1.Text);
            HabilitarValidador();
        }

        private void BtnSes2_Click(object sender, EventArgs e)
        {
            sessao = Convert.ToInt32(txtPreco2.Text);
            HabilitarValidador();
        }

        private void BtnSes3_Click(object sender, EventArgs e)
        {
            sessao = Convert.ToInt32(txtPreco3.Text);
            HabilitarValidador();
        }

        private void BtnSes4_Click(object sender, EventArgs e)
        {
            sessao = Convert.ToInt32(txtPreco4.Text);
            HabilitarValidador();
        }

        private void BtnSes5_Click(object sender, EventArgs e)
        {
            sessao = Convert.ToInt32(txtPreco5.Text);
            HabilitarValidador();
        }

        private void BtnSes6_Click(object sender, EventArgs e)
        {
            sessao = Convert.ToInt32(txtPreco6.Text);
            HabilitarValidador();
        }

       

        private void BtnPagar_Click(object sender, EventArgs e)
        {
           double precofinal = Convert.ToDouble(txtPrecoFinal.Text);
           double pago = Convert.ToDouble(txtPago.Text);
            if(pago < precofinal)
            {
                MessageBox.Show("Valor Insuficiente!");
                txtPago.Focus();
            }
            else
            {
                txtTroco.Text = Pagar(pago, precofinal).ToString();
                MessageBox.Show("Compra efetuada com sucesso! Lhe desejo uma ótima sessão.");
            }
           
        }

        private void BtnFinal_Click(object sender, EventArgs e)
        {
            Limpar();
            DesabilitarTudo();
        }
        // Verificação de existência de estudante
        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                numUpQtaEstudantes.Enabled = true;
            }
            else
            {
                numUpQtaEstudantes.Enabled = false;
            }
        }
    }
}
