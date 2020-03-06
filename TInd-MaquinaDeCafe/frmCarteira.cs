using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TInd_MaquinaDeCafe
{
    public partial class frmCarteira : Form
    {
        frmMaquinaCafe instanciaDoForm1;

        public frmCarteira(frmMaquinaCafe frm1)
        {
            InitializeComponent();

            // - Declaração do MainForm ("frmMaquinaCafe") para chamada de variáveis/funções públicas.
            instanciaDoForm1 = frm1;

            // - Declaração de evento de chamada ao fechar o form da carteira.
            this.FormClosing += frmCarteira_FormClosing;

            // - Desabilitar o redimensionamento da janela.
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            carregarRecursos();
        }

        // @ Função para definir, declarar e carregar diferentes recursos como PictureBoxes, labels e timers.
        private void carregarRecursos()
        {
            pctMoeda5.Image = Properties.Resources.moeda5png;
            pctMoeda10.Image = Properties.Resources.moeda10png;
            pctMoeda25.Image = Properties.Resources.moeda25png;
            pctMoeda50.Image = Properties.Resources.moeda50png;
            pctMoeda1real.Image = Properties.Resources.moeda1realpng;

            btnRetirarTroco.Enabled = false;
            btnRetirarTroco.Visible = false;
        }

        // @ Evento de Click no PictureBox da moeda de 5 centavos.
        private void pctMoeda5_Click(object sender, EventArgs e)
        {
            if (instanciaDoForm1.creditos < 10.0)
            {
                instanciaDoForm1.creditos += 0.05;

                instanciaDoForm1.atualizarScreen(Color.Blue, "ADICIONADO:\nR$ 0,05", "ESCOLHA O SABOR!");
            }
            else instanciaDoForm1.atualizarScreen(Color.OrangeRed, "LIMITE DE CREDITOS\nATINGIDO!", "ESCOLHA O SABOR!");
            
            instanciaDoForm1.carteira_aberta = false;

            instanciaDoForm1.carteira_troco_disponivel = false;

            this.Hide();
        }

        // @ Evento de Click no PictureBox da moeda de 10 centavos.
        private void pctMoeda10_Click(object sender, EventArgs e)
        {
            if (instanciaDoForm1.creditos < 10.0)
            {
                instanciaDoForm1.creditos += 0.10;

                instanciaDoForm1.atualizarScreen(Color.Blue, "ADICIONADO:\nR$ 0,10", "ESCOLHA O SABOR!");
            }
            else instanciaDoForm1.atualizarScreen(Color.OrangeRed, "LIMITE DE CREDITOS\nATINGIDO!", "ESCOLHA O SABOR!");

            instanciaDoForm1.carteira_aberta = false;

            instanciaDoForm1.carteira_troco_disponivel = false;

            this.Hide();
        }

        // @ Evento de Click no PictureBox da moeda de 25 centavos.
        private void pctMoeda25_Click(object sender, EventArgs e)
        {
            if (instanciaDoForm1.creditos < 10.0)
            {
                instanciaDoForm1.creditos += 0.25;

                instanciaDoForm1.atualizarScreen(Color.Blue, "ADICIONADO:\nR$ 0,25", "ESCOLHA O SABOR!");
            }
            else instanciaDoForm1.atualizarScreen(Color.OrangeRed, "LIMITE DE CREDITOS\nATINGIDO!", "ESCOLHA O SABOR!");

            instanciaDoForm1.carteira_aberta = false;

            instanciaDoForm1.carteira_troco_disponivel = false;

            this.Hide();
        }

        // @ Evento de Click no PictureBox da moeda de 50 centavos.
        private void pctMoeda50_Click(object sender, EventArgs e)
        {
            if (instanciaDoForm1.creditos < 10.0)
            {
                instanciaDoForm1.creditos += 0.50;

                instanciaDoForm1.atualizarScreen(Color.Blue, "ADICIONADO:\nR$ 0,50", "ESCOLHA O SABOR!");
            }
            else instanciaDoForm1.atualizarScreen(Color.OrangeRed, "LIMITE DE CREDITOS\nATINGIDO!", "ESCOLHA O SABOR!");

            instanciaDoForm1.carteira_aberta = false;

            instanciaDoForm1.carteira_troco_disponivel = false;

            this.Hide();
        }

        // @ Evento de Click no PictureBox da moeda de 1 real.
        private void pctMoeda1real_Click(object sender, EventArgs e)
        {
            if (instanciaDoForm1.creditos < 10.0)
            {
                instanciaDoForm1.creditos += 1.00;

                instanciaDoForm1.atualizarScreen(Color.Blue, "ADICIONADO:\nR$ 1,00", "ESCOLHA O SABOR!");
            }
            else instanciaDoForm1.atualizarScreen(Color.OrangeRed, "LIMITE DE CREDITOS\nATINGIDO!", "ESCOLHA O SABOR!");

            instanciaDoForm1.carteira_aberta = false;

            instanciaDoForm1.carteira_troco_disponivel = false;

            this.Hide();
        }

        // @ Evento de Click no botão de retirar troco quando o mesmo estiver disponível.
        private void btnRetirarTroco_Click(object sender, EventArgs e)
        {
            double armazenador_creditos = instanciaDoForm1.creditos;
            instanciaDoForm1.creditos = 0.0;

            instanciaDoForm1.atualizarScreen(Color.Blue, "TROCO RESGATADO:\n" + armazenador_creditos.ToString("C"), "OBRIGADO");

            instanciaDoForm1.carteira_troco_disponivel = false;

            btnRetirarTroco.Enabled = false;
            btnRetirarTroco.Visible = false;

            instanciaDoForm1.carteira_aberta = false;

            this.Hide();
        }

        // @ Ao fechar o form da carteira (mesmo que seja pelo "X") retornar "false" à variável de checagem de carteira aberta.
        private void frmCarteira_FormClosing(object sender, FormClosingEventArgs e)
        {
            instanciaDoForm1.carteira_aberta = false;
        }
    }
}
