﻿namespace DevIO.Business.Interfaces;

public interface ICategoriaService : IDisposable
{
    Task Adicionar(Categoria categoria);
    Task Atualizar(Categoria categoria);
    Task Remover(Guid id);
}
