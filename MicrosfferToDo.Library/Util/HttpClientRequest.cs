﻿using MicrosfferToDo.Library.Commum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MicrosfferToDo.Library.Util
{
    /// <summary>
    /// Classe responsável por voltar a variavel de client HttpClient
    /// <author>
    /// Mauricio Junior
    /// </author>
    /// </summary>
    public static class HttpClientRequest
    {
        /// <summary>
        /// Método que busca o tipo do cliente com o endereço base do web api
        /// </summary>
        /// <returns>HttpClient</returns>
        public static HttpClient getClient()
        {
            //chama a classe HTTP Client
            HttpClient client = new HttpClient();

            //Atribui o endereço base
            client.BaseAddress = new Uri(EnderecosWebAPI._enderecoBase);
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            //Passa como parâmetro o token e senha no header
            client.DefaultRequestHeaders.Add("token", TokenWebAPI._publicToken);
            client.DefaultRequestHeaders.Add("pwd", TokenWebAPI._pwd);

            return client;
        }
    }
}
