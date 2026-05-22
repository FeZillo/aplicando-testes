namespace AplicandoTestes.Core;

public sealed class CreditAnalyzer
{
    private readonly ICreditScoreService _creditScoreService;

    public CreditAnalyzer(ICreditScoreService creditScoreService)
    {
        _creditScoreService = creditScoreService;
    }

    public async Task<CreditAnalysisResult> AnalyzeAsync(CreditAnalysisRequest request)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(request.Document);

        if (request.MonthlyIncome <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(request.MonthlyIncome));
        }

        if (request.RequestedAmount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(request.RequestedAmount));
        }

        int score = await _creditScoreService.GetScoreAsync(request.Document);

        if (score < 600)
        {
            return new CreditAnalysisResult(false, CreditRisk.High, "Credit score below minimum policy.");
        }

        decimal maximumAmount = request.MonthlyIncome * 3;

        if (request.RequestedAmount > maximumAmount)
        {
            return new CreditAnalysisResult(false, CreditRisk.Medium, "Requested amount is above the income policy.");
        }

        return new CreditAnalysisResult(true, CreditRisk.Low, "Credit approved.");
    }
}
