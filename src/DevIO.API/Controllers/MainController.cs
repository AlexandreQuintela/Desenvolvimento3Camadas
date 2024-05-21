using DevIO.Business.Interfaces;
using DevIO.Business.Notificacoes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Net;

namespace DevIO.API.Controllers;

[ApiController]
public abstract class MainController : ControllerBase
{
    private readonly INotificador _notificador;

    protected MainController(INotificador notificador)
    {
        _notificador = notificador;
    }

    protected bool OperacaoValida()
    {
        return !_notificador.TemNotificacoes();
    }

    protected ActionResult RespostaPadrao(HttpStatusCode StatusCode = HttpStatusCode.OK, object result = null)
    {
        return OperacaoValida()
            ? new ObjectResult(result)
            {
                StatusCode = Convert.ToInt32(StatusCode)
            }
            : (ActionResult)BadRequest(new
            {
                erros = _notificador.ObterNotificacoes().Select(e => e.Mensagem)
            });
    }

    protected ActionResult RespostaPadrao(ModelStateDictionary modelState)
    {
        if (!modelState.IsValid) NotificarErroModelInvalida(modelState);

        return RespostaPadrao();
    }

    protected void NotificarErroModelInvalida(ModelStateDictionary modelState)
    {
        var erros = modelState.Values.SelectMany(e => e.Errors);
        foreach (var erro in erros)
        {
            var mensagemErro = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
            NotificarErro(mensagemErro);
        }
    }

    protected void NotificarErro(string mensagem)
    {
        _notificador.Handle(new Notificacao(mensagem));
    }
}