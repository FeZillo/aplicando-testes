namespace AplicandoTestes.Core;

public sealed record CreditAnalysisRequest(
    string Document,
    decimal MonthlyIncome,
    decimal RequestedAmount);
