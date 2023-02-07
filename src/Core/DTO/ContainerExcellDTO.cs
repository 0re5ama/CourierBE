using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductTracking.Core.Enums.ProductTracking;

namespace ProductTracking.Core.DTO;
public class ContainerExcellDTO
{
    public string VechileNo { get; set; }
    public List<ContainerConsignmentExcellDTO> ContainerConsignments { get; set; }

}

public class ContainerConsignmentExcellDTO
{
    public string? CartoonRemarks { get; set; }
    public ConsignmentExcellDTO Consignment { get; set; }

}

public class ConsignmentExcellDTO
{
    public string ConsignmentNo { get; set; }
    public string Consignee { get; set; }
    public string Description { get; set; }
    public decimal Weight { get; set; }
    public decimal Freight { get; set; }
    public decimal Value { get; set; }
    public decimal Insurance { get; set; }
    public decimal TotalAmount { get; set; }
    public EnPaymentStatus PaymentStatus { get; set; }
    public string PaymentStatusName => PaymentStatus.ToString();
    public List<ConsignmentItemsExcellDTO> ConsignmentItems { get; set; }

}

public class ConsignmentItemsExcellDTO
{
    public ItemExcellDTO Item { get; set; }
    public decimal Quantity { get; set; }
}


public class ItemExcellDTO
{
    public string Name { get; set; }
}


