﻿using System.Collections.Generic;

namespace iugu.net.Entity
{
    // TODO: Precisa de refatoração, nomes fora do padrão .Net, sem documentação também
    public class CustomersModel
    {
        public int totalItems { get; set; }
        public List<CustomerModel> items { get; set; }
    }

    // TODO: Precisa de refatoração, nomes fora do padrão .Net, sem documentação também
    public class CustomerModel
    {
        public string id { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public string notes { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public List<object> custom_variables { get; set; }               
        public string zip_code { get; set; }        
        public int number { get; set; }        
        public string complement { get; set; }        
        public string cpf_cnpj { get; set; }
    }
}
