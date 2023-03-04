namespace Domain.Models;

public class Payment
{

    public Payment()
    {
            
    }

    public Payment(Guid id, string paymentTitle, Guid customerId, Customer? customer, int nightCount, decimal pricePerNight, decimal totalNightPrice, decimal tax, decimal total, DateTime paymentDate)
    {
        Id = id;
        PaymentTitle = paymentTitle;
        CustomerId = customerId;
        Customer = customer;
        NightCount = nightCount;
        PricePerNight = pricePerNight;
        TotalNightPrice = totalNightPrice;
        Tax = tax;
        Total = total;
        PaymentDate = paymentDate;
    }

    public Guid Id { get; set; }

    public string PaymentTitle { get; set; } = string.Empty;

    public Guid CustomerId { get; set; }
    public virtual Customer? Customer { get; set; }

    public int NightCount { get; set; } 

    public decimal PricePerNight { get; set; }

    public decimal TotalNightPrice { get; set; }

    public decimal Tax { get; set; }

    public decimal Total { get; set; }

    public DateTime PaymentDate { get; set; }
}
