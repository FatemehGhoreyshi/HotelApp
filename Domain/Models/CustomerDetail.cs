namespace Domain.Models;

public class CustomerDetail
{
    public CustomerDetail()
    {

    }

    public CustomerDetail(Guid id, int socialNumber, int insuranceNumber, Customer customer)
    {
        Id = id;
        SocialNumber = socialNumber;
        InsuranceNumber = insuranceNumber;
        Customer = customer;

    }
    
  
    public Guid Id { get; set; }

    public int SocialNumber { get; set; }

    public int InsuranceNumber { get; set; }


    public virtual Customer? Customer { get; set; }
}
