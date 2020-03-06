using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TInd_MaquinaDeCafe
{
    public partial class frmMaquinaCafe : Form
    {
        public frmMaquinaCafe()
        {
            InitializeComponent();

            // - Desabilitar o redimensionamento da janela.
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            carregarRecursos();
        }

        // # Variáveis globais e publicas
        public double creditos = 0.0;

        public bool carteira_aberta = false;
        public bool carteira_troco_disponivel = false;

        public bool maquina_ocupada = false;
        public bool maquina_idle = true;


        // # Variáveis globais e privadas
        private int botao_pressionado = -1;

        // - Declaração da array de PictureBox
        private PictureBox[] botao = new PictureBox[8];
        private double[] botao_preco = new double[8];

        private Timer timerAlternarScreen = new Timer();
        private Timer timerPrepararCafe = new Timer();

        private string screen_texto;
        private string screen_textoalternado;

        // - Declaração de uma nova fonte para uso de fonte externa presente na pasta "Resources" do projeto.
        // Source: https://stackoverflow.com/questions/556147/how-to-quickly-and-easily-embed-fonts-in-winforms-app-in-c-sharp
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, [System.Runtime.InteropServices.In] ref uint pcFonts);
        private PrivateFontCollection fonts = new PrivateFontCollection();
        Font minhaFonte;


        // @ Função para definir, declarar e carregar diferentes recursos como PictureBoxes, labels e timers.
        private void carregarRecursos()
        {
            pctBackground.Image = Properties.Resources.maquina_cafeFINAL;

            pctBackgroundScreen.BackColor = Color.Gray;

            pctCofre.Image = Properties.Resources.cofre;

            pctCopo.Image = Properties.Resources.copo;
            pctCopo.Visible = false;

            // - Controle/preenchimento dos botões de sabores através de uma array de PictureBox ("botao").
            botao[0] = pctBotao1;
            botao[0].Tag = "Expresso";
            botao_preco[0] = 2.50;

            botao[1] = pctBotao2;
            botao[1].Tag = "c/ Leite";
            botao_preco[1] = 3.00;

            botao[2] = pctBotao3;
            botao[2].Tag = "Capuccino";
            botao_preco[2] = 4.00;

            botao[3] = pctBotao4;
            botao[3].Tag = "Macchiato";
            botao_preco[3] = 4.50;

            botao[4] = pctBotao5;
            botao[4].Tag = "Chocolate";
            botao_preco[4] = 3.00;

            botao[5] = pctBotao6;
            botao[5].Tag = "Irlandes";
            botao_preco[5] = 4.00;

            botao[6] = pctBotao7;
            botao[6].Tag = "Pingado";
            botao_preco[6] = 3.00;

            botao[7] = pctBotao8;
            botao[7].Tag = "Mocha";
            botao_preco[7] = 4.50;

            botao[0].Image = Properties.Resources.botao1;
            botao[1].Image = Properties.Resources.botao2;
            botao[2].Image = Properties.Resources.botao3;
            botao[3].Image = Properties.Resources.botao4;
            botao[4].Image = Properties.Resources.botao5;
            botao[5].Image = Properties.Resources.botao6;
            botao[6].Image = Properties.Resources.botao7;
            botao[7].Image = Properties.Resources.botao8;


            // - Inserçao de uma fonte externa presente na pasta "Resources" do projeto.
            // Source: https://stackoverflow.com/questions/556147/how-to-quickly-and-easily-embed-fonts-in-winforms-app-in-c-sharp
            byte[] fontData = Properties.Resources.LED_LCD_123;
            IntPtr fontPtr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(fontData.Length);
            System.Runtime.InteropServices.Marshal.Copy(fontData, 0, fontPtr, fontData.Length);
            uint dummy = 0;
            fonts.AddMemoryFont(fontPtr, Properties.Resources.LED_LCD_123.Length);
            AddFontMemResourceEx(fontPtr, (uint)Properties.Resources.LED_LCD_123.Length, IntPtr.Zero, ref dummy);
            System.Runtime.InteropServices.Marshal.FreeCoTaskMem(fontPtr);
            minhaFonte = new Font(fonts.Families[0], 8.25F, FontStyle.Bold);


            lblSaldoScreen.Font = minhaFonte;
            lblSaldoScreen.BackColor = Color.Gray;
            lblSaldoScreen.ForeColor = Color.LawnGreen;
            lblSaldoScreen.Visible = false;

            lblTextoScreen.Font = minhaFonte;
            lblTextoScreen.BackColor = Color.Gray;
            lblTextoScreen.ForeColor = Color.Blue;
            lblTextoScreen.Visible = false;

            // - Timer para alternar o texto da screen da máquina de 3 em 3 segundos.
            timerAlternarScreen.Interval = (3000);
            timerAlternarScreen.Tick += new EventHandler(timedAlternarScreen);

            // - Timer para preparar o café assim que o mesmo for escolhido pelo usuário nos botões (10 segundos).
            timerPrepararCafe.Interval = (10000);
            timerPrepararCafe.Tick += new EventHandler(timedPrepararCafe);


            maquinaIdle();
        }

        // @ Método para definir o estado do screen para "Idle", ou seja, a máquina está funcionando, porém, sem utilização.
        public void maquinaIdle()
        {
            timerAlternarScreen.Stop();

            DateTime dataHoje = DateTime.UtcNow.Date;

            lblSaldoScreen.Visible = false;

            lblTextoScreen.Visible = true;
            lblTextoScreen.ForeColor = Color.Blue;

            screen_texto = lblTextoScreen.Text = "DYLON.S HOT COFFE\n\nINSIRA MOEDAS";
            screen_textoalternado = dataHoje.ToString("dd/MM/yyyy") + " - " + DateTime.Now.ToString("HH:mm tt") + "\n\nIFSP - CAPIVARI";

            maquina_idle = true;

            timerAlternarScreen.Start();
        }

        // @ Função criada para atualizar o texto do screen da máquina de acordo com os parametros especificados.
        public void atualizarScreen(Color cor, string texto, string texto_alternado = "")
        {
            timerAlternarScreen.Stop();

            lblSaldoScreen.Visible = true;

            lblTextoScreen.Visible = true;
            lblTextoScreen.ForeColor = cor;

            lblTextoScreen.Text = texto;
            lblSaldoScreen.Text = "SALDO: " + creditos.ToString("C");

            screen_texto = texto;
            screen_textoalternado = texto_alternado;

            timerAlternarScreen.Start();
        }

        // @ Evento chamado sempre que o timer "timerAlternarScreen" terminar seu ciclo de tempo.
        private void timedAlternarScreen(object sender, EventArgs e)
        {
            if (lblTextoScreen.Text == screen_texto)
            {
                if (creditos == 0.0 && maquina_idle == false && maquina_ocupada == false) maquinaIdle();
                else lblTextoScreen.Text = screen_textoalternado;
            }
            else lblTextoScreen.Text = screen_texto;
        }

        // @ Evento chamado sempre que o timer "timerPrepararCafe" terminar seu ciclo de tempo.
        private void timedPrepararCafe(object sender, EventArgs e)
        {
            pctCopo.Visible = true;

            atualizarScreen(Color.Blue, botao[botao_pressionado].Tag + "\nPREPARADO", "RETIRE SEU CAFE");

            timerPrepararCafe.Stop();
        }

        // @ Evento criado especialmente e exclusivamente para poupar multiplas chamadas de clicks das diferentes PictureBoxes, 
        //atribuindo todas elas à um único evento.
        private void botoes_Click(object sender, EventArgs e)
        {
            // - Loop de checagem de botão pressionado.
            for (int x = 0; x < 8; x++)
            {
                if (sender as PictureBox == botao[x] && maquina_ocupada == false && carteira_aberta == false)
                {
                    maquina_idle = false;

                    if (botao_pressionado == x)
                    {
                        if (creditos >= botao_preco[x])
                        {
                            maquina_ocupada = true;

                            creditos -= botao_preco[x];
                            atualizarScreen(Color.Blue, botao[x].Tag + "\nSENDO PREPARADO!", "AGUARDE UM MOMENTO");

                            timerPrepararCafe.Start();
                        }
                        else
                        {
                            atualizarScreen(Color.OrangeRed, "CREDITOS\nINSUFICIENTES", "INSIRA MAIS MOEDAS");
                            botao_pressionado = -1;
                        }
                    }
                    else
                    {
                        atualizarScreen(Color.Blue, botao[x].Tag + "\n" + botao_preco[x].ToString("C"), "Pressione novamente\npara preparar");
                        botao_pressionado = x;
                    }
                }
            }
        }

        // @ Evento em que chama o form da carteira ("frmCarteira") ao clicar na PictureBox do cofre de inserção de moedas.
        private void pctCofre_Click(object sender, EventArgs e)
        {
            if (maquina_ocupada == false)
            {
                maquina_idle = false;

                frmCarteira frm2 = new frmCarteira(this);

                if (carteira_aberta == false)
                {
                    frm2.Show();
                    carteira_aberta = true;

                    if (carteira_troco_disponivel == true)
                    {
                        frm2.btnRetirarTroco.Enabled = true;
                        frm2.btnRetirarTroco.Visible = true;
                    }
                }
                else
                {
                    Application.OpenForms[frm2.Name].Activate();
                }
            }
        }

        // @ Evento para esconder a PictureBox do copo após clicar no mesmo assim que o café estiver "pronto".
        private void pctCopo_Click(object sender, EventArgs e)
        {
            maquina_ocupada = false;
            pctCopo.Visible = false;

            botao_pressionado = -1;

            if (creditos > 0.0)
            {
                carteira_troco_disponivel = true;
                atualizarScreen(Color.Blue, "TROCO DISPONIVEL", "RETIRE OU REUTILIZE");
            }
            else
            {
                carteira_troco_disponivel = false;
                maquinaIdle();
            }
        }
    }
}