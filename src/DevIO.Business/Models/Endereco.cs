﻿namespace DevIO.Business.Models;

public class Endereco : Entity
{
    public string? Logradouro { get; set; }
    public string? Numero { get; set; }
    public string? Complemento { get; set; }
    public string? Cep { get; set; }
    public string? Bairro { get; set; }
    public string? Cidade { get; set; }
    public string? Estado { get; set; }

    //Relaçao do EF
    public Fornecedor Fornecedor { get; set; }
    public Guid FornecedorID { get; set; }
}