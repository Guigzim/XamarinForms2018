using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using App01_ConsultarCEP.Servico.Modelos;
using Newtonsoft.Json;

namespace App01_ConsultarCEP.Servico
{
    class ViaCEPServico
    {
        private static string EnderecoURL = "http://viacep.com.br/ws/{0}/json/";

        public static Endereco buscarEnderecoViaCEP(string cep)
        {
            string novoEnderecoURL = string.Format(EnderecoURL, cep);


            WebClient wc = new WebClient();
            string conteudo = wc.DownloadString(novoEnderecoURL);

            Endereco end = JsonConvert.DeserializeObject<Endereco>(conteudo);

            if (end.cep == null) return null;
            return end;
        }

    }
}
