using AplicandoTestes.Core;
using FluentAssertions;
using Moq;

namespace AplicandoTestes.MockTests;

public class CreditAnalyzerTests
{
    [Fact]
    public async Task AnalyzeAsync_ShouldApproveCredit_WhenScoreIsHighAndAmountFitsIncome()
    {
        const string document = "12345678900";
        var creditScoreService = new Mock<ICreditScoreService>();
        creditScoreService
            .Setup(service => service.GetScoreAsync(document))
            .ReturnsAsync(820);

        var analyzer = new CreditAnalyzer(creditScoreService.Object);

        CreditAnalysisResult result = await analyzer.AnalyzeAsync(
            new CreditAnalysisRequest(document, MonthlyIncome: 5_000m, RequestedAmount: 10_000m));

        result.Approved.Should().BeTrue();
        result.Risk.Should().Be(CreditRisk.Low);
        result.Reason.Should().Be("Credit approved.");
        creditScoreService.Verify(service => service.GetScoreAsync(document), Times.Once);
    }

    [Fact]
    public async Task AnalyzeAsync_ShouldRejectCredit_WhenScoreIsBelowPolicy()
    {
        const string document = "98765432100";
        var creditScoreService = new Mock<ICreditScoreService>();
        creditScoreService
            .Setup(service => service.GetScoreAsync(document))
            .ReturnsAsync(420);

        var analyzer = new CreditAnalyzer(creditScoreService.Object);

        CreditAnalysisResult result = await analyzer.AnalyzeAsync(
            new CreditAnalysisRequest(document, MonthlyIncome: 8_000m, RequestedAmount: 5_000m));

        result.Approved.Should().BeFalse();
        result.Risk.Should().Be(CreditRisk.High);
        result.Reason.Should().Be("Credit score below minimum policy.");
        creditScoreService.Verify(service => service.GetScoreAsync(document), Times.Once);
    }
}
