
using System;
using System.Collections.Generic;
using EF_Core_Backend.Domains;

namespace EF_Core_Backend.Interfaces
{
    public interface IProdutoRepository
    {
        List<Produto> Listar();
        Produto BuscarPorId(Guid id);
        List<Produto> BuscarPorNome(string nome);
        void Adicionar(Produto produto);
        void Editar(Produto produto);
        void Remover(Guid id);
    }
}