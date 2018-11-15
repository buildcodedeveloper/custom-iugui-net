﻿using iugu.net.Entity;
using iugu.net.Filters;
using iugu.net.Request;
using iugu.net.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iugu.net.Lib
{
    /// <summary>
    /// Os clientes efetuam pagamentos através das faturas. 
    /// As faturas contém itens que representam o que o cliente está pagando, o serviço ou produto.
    /// </summary>
    public class Invoice : APIResource
    {
        public Invoice() : base()
        {
            BaseURI = "/invoices";
        }

        //limit (opcional)	Máximo de registros retornados
        //start (opcional)	Quantos registros pular do início da pesquisa (muito utilizado para paginação)
        //created_at_from (opcional)	Registros criados a partir desta data passada no parâmetro
        //created_at_to (opcional)	Registros criados até esta data passada no parâmetro
        //query (opcional)	Neste parâmetro pode ser passado um texto para pesquisa
        //updated_since (opcional)	Registros atualizados desde o valor passado no parâmetro
        //sortBy (opcional)	Um hash sendo a chave o nome do campo para ordenação e o valor sendo DESC ou ASC para descendente e ascendente, respectivamente
        //customer_id (opcional)	ID do Cliente
        [Obsolete("Sera descontinuado na versão 2.x do client, use a versão assincrona do método")]
        public InvoiceListModel Get()
        {
            //TODO: Implementar GET com parametros
            var retorno = GetAsync().Result;
            return retorno;
        }

        public async Task<InvoiceListModel> GetAsync()
        {
            //TODO: Implementar GET com parametros
            var retorno = await GetAllAsync(null).ConfigureAwait(false);
            return retorno;
        }

        /// <summary>
        /// Lista todas as ultimas(1000) faturas possibilitando enviar um ApiToken de subconta, geralmente utilizado em marketplaces
        /// </summary>
        /// <param name="customApiToken">ApiToken customizado</param>
        /// <returns></returns>
        public async Task<InvoiceListModel> GetAllAsync(string customApiToken)
        {
            var filter = new QueryStringFilter { MaxResults = 1000 };
            var queryStringFilter = filter?.ToQueryStringUrl();
            var retorno = await GetAsync<InvoiceListModel>(null, queryStringFilter, customApiToken).ConfigureAwait(false);
            return retorno;
        }

        /// <summary>
        /// Lista todas as faturas possibilitando enviar um ApiToken de subconta, geralmente utilizado em marketplaces e filtros customizaveis.
        /// </summary>
        /// <param name="customApiToken">ApiToken customizado</param>
        /// <param name="filter">Opções de filtros, para paginação e ordenação</param>
        /// <returns></returns>
        public async Task<PaggedResponseMessage<InvoiceModel>> GetAllAsync(string customApiToken, QueryStringFilter filter)
        {
            var queryStringFilter = filter?.ToQueryStringUrl();
            var retorno = await GetAsync<PaggedResponseMessage<InvoiceModel>>(null, queryStringFilter, customApiToken).ConfigureAwait(false);
            return retorno;
        }


        [Obsolete("Sera descontinuado na versão 2.x do client, use a versão assincrona do método")]
        public InvoiceModel Get(string id)
        {
            var retorno = GetAsync(id).Result;
            return retorno;
        }

        public async Task<InvoiceModel> GetAsync(string id)
        {
            var retorno = await GetAsync(id, null).ConfigureAwait(false);
            return retorno;
        }

        public async Task<InvoiceModel> GetAsync(string id, string customApiToken)
        {
            var retorno = await GetAsync<InvoiceModel>(id, null, customApiToken).ConfigureAwait(false);
            return retorno;
        }

        /// <summary>
        /// Cria uma Fatura para um Cliente (Podendo ser um objeto cliente ou apenas um e-mail).
        /// </summary>
        /// <param name="email">E-Mail do cliente</param>
        /// <param name="due_date">Data de Expiração (DD/MM/AAAA)</param>
        /// <param name="items"> Itens da Fatura</param>
        /// <param name="return_url">(opcional)	Cliente é redirecionado para essa URL após efetuar o pagamento da Fatura pela página de Fatura da Iugu</param>
        /// <param name="expired_url">(opcional) Cliente é redirecionado para essa URL se a Fatura que estiver acessando estiver expirada</param>
        /// <param name="notification_url">(opcional) URL chamada para todas as notificações de Fatura, assim como os webhooks (Gatilhos) são chamados</param>
        /// <param name="tax_cents">(opcional) Valor dos Impostos em centavos</param>
        /// <param name="discount_cents">(opcional)	Valor dos Descontos em centavos</param>
        /// <param name="customer_id">(opcional) ID do Cliente</param>
        /// <param name="ignore_due_email">(opcional) Booleano que ignora o envio do e-mail de cobrança</param>
        /// <param name="subscription_id">(opcional) Amarra essa Fatura numa Assinatura</param>
        /// <param name="credits">(opcional) Caso tenha o subscription_id, pode-se enviar o número de créditos a adicionar nessa Assinatura quando a Fatura for paga</param>
        /// <param name="logs">(opcional) Logs da Fatura</param>
        /// <param name="custom_variables">(opcional) Variáveis Personalizadas</param>
        /// <returns></returns>
        [Obsolete("Sera descontinuado na versão 2.x do client, use a versão assincrona do método que recebe InvoiceRequestMessage como parâmetro")]
        public InvoiceModel Create(string email, DateTime due_date, Item[] items, string return_url = "",
            string expired_url = "", string notification_url = "", int tax_cents = 0, int discount_cents = 0, string customer_id = "", bool ignore_due_email = false,
            string subscription_id = "", int credits = 0, Logs logs = null, List<CustomVariables> custom_variables = null, PayerModel payer = null, bool early_payment_discount = false, List<EarlyPaymentDiscounts> early_payment_discounts = null)
        {
            var retorno = CreateAsync(email, due_date, items, return_url, expired_url, notification_url, tax_cents,
                                      discount_cents, customer_id, ignore_due_email, subscription_id, credits, logs,
                                      custom_variables, payer, early_payment_discount, early_payment_discounts).Result;
            return retorno;
        }

        /// <summary>
        /// Cria uma Fatura para um Cliente (Podendo ser um objeto cliente ou apenas um e-mail).
        /// </summary>
        /// <param name="email">E-Mail do cliente</param>
        /// <param name="due_date">Data de Expiração (DD/MM/AAAA)</param>
        /// <param name="items"> Itens da Fatura</param>
        /// <param name="return_url">(opcional)	Cliente é redirecionado para essa URL após efetuar o pagamento da Fatura pela página de Fatura da Iugu</param>
        /// <param name="expired_url">(opcional) Cliente é redirecionado para essa URL se a Fatura que estiver acessando estiver expirada</param>
        /// <param name="notification_url">(opcional) URL chamada para todas as notificações de Fatura, assim como os webhooks (Gatilhos) são chamados</param>
        /// <param name="tax_cents">(opcional) Valor dos Impostos em centavos</param>
        /// <param name="discount_cents">(opcional)	Valor dos Descontos em centavos</param>
        /// <param name="customer_id">(opcional) ID do Cliente</param>
        /// <param name="ignore_due_email">(opcional) Booleano que ignora o envio do e-mail de cobrança</param>
        /// <param name="subscription_id">(opcional) Amarra essa Fatura numa Assinatura</param>
        /// <param name="credits">(opcional) Caso tenha o subscription_id, pode-se enviar o número de créditos a adicionar nessa Assinatura quando a Fatura for paga</param>
        /// <param name="logs">(opcional) Logs da Fatura</param>
        /// <param name="custom_variables">(opcional) Variáveis Personalizadas</param>
        /// <param name="payer">Dados do pagador, obrigatórios para boletos registrados</param>
        /// <returns></returns>
        [Obsolete("Sera descontinuado na versão 2.x do client, use a versão assincrona do método que recebe InvoiceRequestMessage como parâmetro")]
        public async Task<InvoiceModel> CreateAsync(string email, DateTime due_date, Item[] items, string return_url,
    string expired_url, string notification_url, int tax_cents = 0, int discount_cents = 0, string customer_id = null, bool ignore_due_email = false,
    string subscription_id = null, int? credits = null, Logs logs = null, List<CustomVariables> custom_variables = null, PayerModel payer = null, bool early_payment_discount = false, List<EarlyPaymentDiscounts> early_payment_discounts = null)
        {
            var invoice = new
            {
                email = email,
                due_date = due_date.ToString("dd/MM/yyyy"),
                items = items,
                return_url = return_url,
                expired_url = expired_url,
                tax_cents = tax_cents,
                discount_cents = discount_cents,
                customer_id = customer_id,
                ignore_due_email = ignore_due_email,
                subscription_id = subscription_id,
                credits = credits,
                logs = logs,
                custom_variables = custom_variables,
                notification_url = notification_url,
                early_payment_discount = early_payment_discount,
                early_payment_discounts = early_payment_discounts,
                payer = payer
            };
            var retorno = await PostAsync<InvoiceModel>(invoice).ConfigureAwait(false);
            return retorno;
        }

        /// <summary>
        /// Cria uma Fatura para um Cliente
        /// </summary>
        /// <param name="invoice"></param>
        /// <param name="customApiToken">Token customizado opcional, mais utilizado em marketplaces</param>
        /// <returns>Objeto invoice resultante da requisição</returns>
        public async Task<InvoiceModel> CreateAsync(InvoiceRequestMessage invoice, string customApiToken)
        {
            var retorno = await PostAsync<InvoiceModel>(invoice, null, customApiToken).ConfigureAwait(false);
            return retorno;
        }

        [Obsolete("Sera descontinuado na versão 2.x do client, use a versão assincrona do método")]
        public InvoiceModel Delete(string id)
        {
            var retorno = DeleteAsync(id).Result;
            return retorno;
        }

        public async Task<InvoiceModel> DeleteAsync(string id)
        {
            var retorno = await DeleteAsync<InvoiceModel>(id).ConfigureAwait(false);
            return retorno;
        }

        [Obsolete("Sera descontinuado na versão 2.x do client, use a versão assincrona do método")]
        public InvoiceModel Put(string id, InvoiceModel model)
        {
            var retorno = PutAsync(id, model).Result;
            return retorno;
        }

        public async Task<InvoiceModel> PutAsync(string id, InvoiceModel model)
        {
            var retorno = await PutAsync<InvoiceModel>(id, model).ConfigureAwait(false);
            return retorno;
        }

        [Obsolete("Sera descontinuado na versão 2.x do client, use a versão assincrona do método")]
        public InvoiceModel Refund(string id)
        {
            var retorno = RefundAsync(id).Result;
            return retorno;
        }

        public async Task<InvoiceModel> RefundAsync(string id)
        {
            var retorno = await PostAsync<InvoiceModel>(null, $"{id}/refund").ConfigureAwait(false);
            return retorno;
        }

        [Obsolete("Sera descontinuado na versão 2.x do client, use a versão assincrona do método")]
        public InvoiceModel Cancel(string id)
        {
            var retorno = CancelAsync(id).Result;
            return retorno;
        }

        public async Task<InvoiceModel> CancelAsync(string id)
        {
            var retorno = await CancelAsync(id, null).ConfigureAwait(false);
            return retorno;
        }

        public async Task<InvoiceModel> CancelAsync(string id, string customApiToken)
        {
            var retorno = await PutAsync<InvoiceModel>(default(object), $"{id}/cancel", customApiToken).ConfigureAwait(false);
            return retorno;
        }

        /// <summary>
        /// Gera segunda via de uma Fatura. Somente faturas pendentes podem ter segunda via gerada. A fatura atual é cancelada e uma nova é gerada com status ‘pending’.
        /// </summary>
        /// <param name="id">Identificador da fatura</param>
        /// <param name="data">Informações da nova fatura</param>
        /// <returns>Objeto invoice resultante da requisição</returns>
        public async Task<InvoiceModel> DuplicateAsync(string id, InvoiceDuplicateRequestMessage data)
        {
            var retorno = await PostAsync<InvoiceModel>(data, $"{id}/duplicate").ConfigureAwait(false);
            return retorno;
        }

        /// <summary>
        /// Gera segunda via de uma Fatura. Somente faturas pendentes podem ter segunda via gerada. A fatura atual é cancelada e uma nova é gerada com status ‘pending’.
        /// </summary>
        /// <param name="id">Identificador da fatura</param>
        /// <param name="data">Informações da nova fatura</param>
        /// <param name="customApiToken">Token customizado geralmente passado quando está se trabalhando como marketplace</param>
        /// <returns>Objeto invoice resultante da requisição</returns>
        public async Task<InvoiceModel> DuplicateAsync(string id, InvoiceDuplicateRequestMessage data, string customApiToken)
        {
            var retorno = await PostAsync<InvoiceModel>(data, $"{id}/duplicate", customApiToken).ConfigureAwait(false);
            return retorno;
        }

        /// <summary>
        /// Captura uma fatura com estado 'Em Análise'
        /// </summary>
        /// <param name="id">Identificador da fatura</param>
        /// <returns>Objeto invoice resultante da requisição</returns>
        public async Task<InvoiceModel> CaptureAsync(string id)
        {
            var retorno = await PostAsync<InvoiceModel>(default(object), $"{id}/capture").ConfigureAwait(false);
            return retorno;
        }

        /// <summary>
        /// Reenviar fatura para o email do cliente
        /// </summary>
        /// <param name="id">Identificador da fatura</param>
        /// <returns>Objeto invoice resultante da requisição</returns>
        public async Task<InvoiceModel> ResendInvoiceMail(string id)
        {
            var retorno = await ResendInvoiceMail(id, null).ConfigureAwait(false);
            return retorno;
        }

        /// <summary>
        /// Reenviar fatura para o email do cliente
        /// </summary>
        /// <param name="id">Identificador da fatura</param>
        /// <param name="customApiToken">Token customizado geralmente passado quando está se trabalhando como marketplace</param>
        /// <returns>Objeto invoice resultante da requisição</returns>
        public async Task<InvoiceModel> ResendInvoiceMail(string id, string customApiToken)
        {
            var retorno = await PostAsync<InvoiceModel>(default(object), $"{id}/send_email", customApiToken).ConfigureAwait(false);
            return retorno;
        }
    }
}
