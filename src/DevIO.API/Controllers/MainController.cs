using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace DevIO.API.Controllers;

[ApiController]
public abstract class MainController : ControllerBase
{
    protected bool OperacaoValida()
    {
        return true;
    }

    protected ActionResult RespostaPadrao(object result = null)
    {
        return OperacaoValida()
            ? new ObjectResult(result)
            : (ActionResult)BadRequest(new
            {
                // Todo: Coleção erros
            });
    }

    protected ActionResult RespostaPadrao(ModelStateDictionary modelState)
    {
        if (!modelState.IsValid)
        {
            // Todo: Notifica Erros
        }
        return RespostaPadrao();
    }

}
