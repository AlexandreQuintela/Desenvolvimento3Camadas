namespace DevIO.Business.Interfaces;

public interface INotificador
{
    bool TemNotificacoes();
    List<Notificacao> ObterNotificacoes();
    void Handle(Notificacao notificacao);
}