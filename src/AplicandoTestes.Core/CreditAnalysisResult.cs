namespace AplicandoTestes.Core;

public sealed record CreditAnalysisResult(
    bool Approved,
    CreditRisk Risk,
    string Reason);
