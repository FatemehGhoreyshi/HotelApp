using Domain.Models;

namespace Domain.Utilities;

public static class Utility
{
    public static int CalculateNights(DateTime checkInDate, DateTime checkOutDate)
    {
        //TimeSpan
        var nights = checkOutDate - checkInDate;

        return nights.Days;
    }

    public static decimal CalculateNightPrices(decimal pricePerNight, int totalNights)
    {
        var result = pricePerNight * totalNights;

        return result;
    }

    public static decimal CalculateTotalWithTax(decimal nightPrice, decimal tax)
    {
        var taxPercentage = tax / 100;
        var result = nightPrice + (nightPrice * taxPercentage);

        return result;
    }

    public static bool DateValidation(DateTime checkInDate, DateTime checkOutDate)
    {
        if (checkInDate > checkOutDate)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    // Aggregate:
    public static int NumberOfAllPaymentsOfSingleCustomer(IEnumerable<Payment> payments, Guid customerId)
    {
        var specificCustomer =
            payments.Where(c => c.CustomerId == customerId);

        int numberOfPayments =
            specificCustomer.Aggregate(0, (count, val) => count + 1);

        return numberOfPayments;
    }

    public static decimal AverageOfPaymentsOfSingleCustomer(IEnumerable<Payment> payments, Guid customerId)
    {
        var averageOfPayments = payments.Where(c => c.CustomerId == customerId)
                                                .Average(t => t.Total);

        return averageOfPayments;
    }

    public static decimal MaximumPaymentOfSingleCustomer(IEnumerable<Payment> payments, Guid customerId)
    {
        var averageOfPayments = payments.Where(c => c.CustomerId == customerId)
                                                .Max(t => t.Total);

        return averageOfPayments;
    }

    public static decimal MinimumPaymentOfSingleCustomer(IEnumerable<Payment> payments, Guid customerId)
    {
        var averageOfPayments = payments.Where(c => c.CustomerId == customerId)
                                                .Min(t => t.Total);

        return averageOfPayments;
    }
}
