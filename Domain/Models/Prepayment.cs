namespace Domain.Models;

public class Prepayment : Payment
{
    public Prepayment()
    {

    }

    public Prepayment(string prepaymentTitle, DateTime prepaymentDate, decimal prepaymentPrice, string prepaymentDescription)
    {
        PrepaymentTitle = prepaymentTitle;
        PrepaymentDate = prepaymentDate;
        PrepaymentPrice = prepaymentPrice;
        PrepaymentDescription = prepaymentDescription;
    }

    public string PrepaymentTitle { get; set; } = string.Empty;

    public DateTime PrepaymentDate { get; set; }

    public decimal PrepaymentPrice { get; set; }

    public string PrepaymentDescription { get; set; } = string.Empty;
}
