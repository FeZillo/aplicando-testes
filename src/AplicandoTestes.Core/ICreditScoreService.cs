namespace AplicandoTestes.Core;

public interface ICreditScoreService
{
    Task<int> GetScoreAsync(string document);
}
