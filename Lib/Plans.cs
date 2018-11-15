﻿using iugu.net.Entity;
using iugu.net.Request;
using iugu.net.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iugu.net.Lib
{
    public class Plans : APIResource
    {
        public Plans() : base()
        {
            BaseURI = "/plans";
        }

        //limit (opcional)	Máximo de registros retornados
        //start (opcional)	Quantos registros pular do início da pesquisa (muito utilizado para paginação)
        //query (opcional)	Neste parâmetro pode ser passado um texto para pesquisa
        //updated_since (opcional)	Registros atualizados desde o valor passado no parâmetro
        //sortBy (opcional)	Um hash sendo a chave o nome do campo para ordenação e o valor sendo DESC ou ASC para descendente e ascendente, respectivamente
        [Obsolete("Sera descontinuado na versão 2.x do client, use a versão assincrona do método")]
        public PlanModel Get()
        {
            var retorno = GetAsync().Result;
            return retorno;
        }

        public async Task<PaggedResponseMessage<PlanModel>> GetAllAsync()
        {
            var retorno = await GetAllAsync(null).ConfigureAwait(false);
            return retorno;
        }

        public async Task<PaggedResponseMessage<PlanModel>> GetAllAsync(string customApiToken)
        {
            var retorno = await GetAsync<PaggedResponseMessage<PlanModel>>(null, customApiToken).ConfigureAwait(false);
            return retorno;
        }
        public async Task<PlanModel> GetAsync()
        {
            var retorno = await GetAsync<PlanModel>().ConfigureAwait(false);
            return retorno;
        }

        [Obsolete("Sera descontinuado na versão 2.x do client, use a versão assincrona do método")]
        public PlanModel Get(string id)
        {
            var retorno = GetAsync(id).Result;
            return retorno;
        }

        public async Task<PlanModel> GetAsync(string id, string customApiToken = null)
        {
            var retorno = await GetAsync<PlanModel>(id, customApiToken).ConfigureAwait(false);
            return retorno;
        }

        public async Task<PlanModel> GetByIdentifierAsync(string planIdentifier, string customApiToken = null)
        {
            var retorno = await GetAsync<PlanModel>(null, $"identifier/{planIdentifier}", customApiToken).ConfigureAwait(false);
            return retorno;
        }

        /// <summary>
        /// Cria um Plano.
        /// </summary>
        /// <param name="name">Nome do Plano</param>
        /// <param name="identifier">Identificador do Plano</param>
        /// <param name="interval">Ciclo do Plano (Número inteiro maior que 0)</param>
        /// <param name="interval_type">Tipo de Interval ("weeks" ou "months")</param>
        /// <param name="value_cents">Preço do Plano em Centavos</param>
        /// <param name="currency">Moeda do Preço (Somente "BRL" por enquanto)</param>
        /// <param name="prices"> (opcional)	Preços do Plano</param>
        /// <param name="features"> (opcional)	Funcionalidades do Plano</param>
        [Obsolete("Sera descontinuado na versão 2.x do client, use a versão assincrona do método que recebe PlanRequestMessage como parametro")]
        public PlanModel Create(string name, string identifier, int interval, string interval_type, int value_cents,
            string currency = "BRL", List<PlanPrice> prices = null, List<PlanFeature> features = null)
        {
            var retorno = CreateAsync(name, identifier, interval, interval_type, value_cents, currency, prices, features).Result;
            return retorno;
        }

        /// <summary>
        /// Cria um Plano.
        /// </summary>
        /// <param name="name">Nome do Plano</param>
        /// <param name="identifier">Identificador do Plano</param>
        /// <param name="interval">Ciclo do Plano (Número inteiro maior que 0)</param>
        /// <param name="interval_type">Tipo de Interval ("weeks" ou "months")</param>
        /// <param name="value_cents">Preço do Plano em Centavos</param>
        /// <param name="currency">Moeda do Preço (Somente "BRL" por enquanto)</param>
        /// <param name="prices"> (opcional) Preços do Plano</param>
        /// <param name="features"> (opcional) Funcionalidades do Plano</param>
        /// <param name="payable_with">(opcional) Método de pagamento que será disponibilizado para as Faturas pertencentes a Assinaturas deste Plano ('all', 'credit_card' ou 'bank_slip')</param>
        [Obsolete("Sera descontinuado na versão 2.x do client, use a versão assincrona do método que recebe PlanRequestMessage como parametro")]
        public async Task<PlanModel> CreateAsync(string name, string identifier, int interval, string interval_type, int value_cents,
            string currency = "BRL", List<PlanPrice> prices = null, List<PlanFeature> features = null, string payable_with = null)
        {
            var user = new
            {
                name = name,
                interval = interval,
                identifier = identifier,
                interval_type = interval_type,
                value_cents = value_cents,
                currency = currency,
                prices = prices,
                features = features,
                payable_with = payable_with
            };
            var retorno = await PostAsync<PlanModel>(user).ConfigureAwait(false);
            return retorno;
        }


        /// <summary>
        /// Cria um Plano possibilitando enviar um ApiToken customizado
        /// </summary>
        /// <param name="plan">todo: describe plan parameter on CreateAsync</param>
        /// <param name="customApiToken">todo: describe customApiToken parameter on CreateAsync</param>
        public async Task<PlanModel> CreateAsync(PlanRequestMessage plan, string customApiToken)
        {
            var retorno = await PostAsync<PlanModel>(plan, null, customApiToken).ConfigureAwait(false);
            return retorno;
        }

        [Obsolete("Sera descontinuado na versão 2.x do client, use a versão assincrona do método")]
        public PlanModel Delete(string id)
        {
            var retorno = DeleteAsync(id).Result;
            return retorno;
        }

        public async Task<PlanModel> DeleteAsync(string id)
        {
            var retorno = await DeleteAsync(id, null).ConfigureAwait(false);
            return retorno;
        }

        public async Task<PlanModel> DeleteAsync(string id, string customApiToken)
        {
            var retorno = await DeleteAsync<PlanModel>(id, customApiToken).ConfigureAwait(false);
            return retorno;
        }

        [Obsolete("Sera descontinuado na versão 2.x do client, use a versão assincrona do método")]
        public PlanModel Put(string id, PlanModel model)
        {
            var retorno = PutAsync<PlanModel>(id, model).Result;
            return retorno;
        }

        public async Task<PlanModel> PutAsync(string id, PlanModel model)
        {
            var retorno = await PutAsync<PlanModel>(id, model).ConfigureAwait(false);
            return retorno;
        }
    }
}
