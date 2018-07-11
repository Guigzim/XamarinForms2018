using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App01_ConsultarCEP.Servico;
using App01_ConsultarCEP.Servico.Modelos;

namespace App01_ConsultarCEP
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
            
            BOTAO.Clicked += BOTAO_Clicked;

        }

        private void BOTAO_Clicked(object sender, EventArgs e)
        {
            string cep = CEP.Text.Trim();

            if (isValidCEP(cep))
            {
                try
                {

                    Endereco end = ViaCEPServico.buscarEnderecoViaCEP(cep);
                    if (end != null)
                    {
                        Rua.Text = string.Format("Rua: {0}", end.logradouro); 
                        Bairro.Text = string.Format("Bairro: {0}", end.bairro);
                        Cidade.Text = string.Format("Cidade: {0}", end.localidade);
                        UF.Text = string.Format("UF: {0}", end.uf);

                        //RESULTADO.Text = string.Format("Endereço: {0}, Bairro: {1}, Cidade: {2} - {3}", end.logradouro, end.bairro, end.localidade, end.uf);
                    }
                    else
                    {
                        DisplayAlert("ERRO", "Endereço não encontrado para o CEP informado.", "OK");
                    }

                }

                catch (Exception exception)
                {

                    DisplayAlert("ERRO CRÍTICO", exception.Message, "OK");
                }


            }

        }
        private bool isValidCEP(string cep)
        {
            bool valido = true;
            if (cep.Length != 8)
            {
                DisplayAlert("erro!", "cep inválido! o cep deve conter 8 caracteres.", "ok");
                valido = false;
                //CEP.Text = string.Empty;
            }
            int novoCEP = 0;
            if (!int.TryParse(cep, out novoCEP))
            {
                DisplayAlert("ERRO!", "CEP Inválido! O CEP deve conter apenas números.", "OK");
                valido = false;
                //CEP.Text = string.Empty;

            }
            return valido;
        }

    }
}
