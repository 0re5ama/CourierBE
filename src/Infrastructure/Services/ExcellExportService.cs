using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductTracking.Core.Entities.TrackingAggregate;
using ProductTracking.Core.Interfaces.CommonInterfaces;
using ClosedXML.Excel;
using ProductTracking.Core.DTO;

namespace ProductTracking.Infrastructure.Services;
public class ExcellExportService : IExcellExportService
{


    public async Task<byte[]> GetExcellAsync(ContainerExcellDTO container)
    {
        try
        {
            using (var wbook = new XLWorkbook())
            {
                string[] Headers;
                var ws = wbook.Worksheets.Add("Sheet1");
                ws.Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);

                Headers = new string[]{
                    "Container",
                    "Consignment No",
                    "Consignee",
                    "Decription",
                    "Weight",
                    "Freight",
                    "Value",
                    "Insurance",
                    "Total Amount",
                    "Cartoon Remarks",
                    "Payment Status",
                    "Item Name",
                    "CTN",
                };
                var col = 'A';
                var row = 1;
                foreach (var header in Headers)
                {
                    string cell = col + row.ToString();
                    ws.Cell(cell).Value = header;
                    col++;
                }
                ws.Range("A1:M1").Style.Font.FontSize = 15;

                ws.Column("A").AdjustToContents();
                ws.Column("B").AdjustToContents();
                ws.Column("C").AdjustToContents();
                ws.Column("D").AdjustToContents();
                ws.Column("E").AdjustToContents();
                ws.Column("F").AdjustToContents();
                ws.Column("G").AdjustToContents();
                ws.Column("H").AdjustToContents();
                ws.Column("I").AdjustToContents();
                ws.Column("J").AdjustToContents();
                ws.Column("L").AdjustToContents();
                ws.Column("M").AdjustToContents();


                ws.Cell("A2").Value = container.VechileNo;

                foreach (var consignment in container.ContainerConsignments)
                {
                    row++;
                    ws.Cell("B" + row).Value = consignment.Consignment.ConsignmentNo;
                    ws.Cell("C" + row).Value = consignment.Consignment.Consignee;
                    ws.Cell("D" + row).Value = consignment.Consignment.Description;
                    ws.Cell("E" + row).Value = consignment.Consignment.Weight;
                    ws.Cell("F" + row).Value = consignment.Consignment.Freight;
                    ws.Cell("G" + row).Value = consignment.Consignment.Value;
                    ws.Cell("H" + row).Value = consignment.Consignment.Insurance;
                    ws.Cell("I" + row).Value = consignment.Consignment.TotalAmount;
                    ws.Cell("J" + row).Value = consignment.CartoonRemarks;
                    ws.Cell("K" + row).Value = consignment.Consignment.PaymentStatusName;

                    foreach (var item in consignment.Consignment.ConsignmentItems)
                    {
                        ws.Cell("L" + row).Value = item.Item.Name;
                        ws.Cell("M" + row).Value = item.Quantity;
                        row++;
                    }
                    row--;
                    ws.Range($"B{row - consignment.Consignment.ConsignmentItems.Count + 1}:B{row}").Merge();
                    ws.Range($"C{row - consignment.Consignment.ConsignmentItems.Count + 1}:C{row}").Merge();
                    ws.Range($"D{row - consignment.Consignment.ConsignmentItems.Count + 1}:D{row}").Merge();
                    ws.Range($"E{row - consignment.Consignment.ConsignmentItems.Count + 1}:E{row}").Merge();
                    ws.Range($"F{row - consignment.Consignment.ConsignmentItems.Count + 1}:F{row}").Merge();
                    ws.Range($"G{row - consignment.Consignment.ConsignmentItems.Count + 1}:G{row}").Merge();
                    ws.Range($"H{row - consignment.Consignment.ConsignmentItems.Count + 1}:H{row}").Merge();
                    ws.Range($"I{row - consignment.Consignment.ConsignmentItems.Count + 1}:I{row}").Merge();
                    ws.Range($"J{row - consignment.Consignment.ConsignmentItems.Count + 1}:J{row}").Merge();
                    ws.Range($"K{row - consignment.Consignment.ConsignmentItems.Count + 1}:K{row}").Merge();

                }
                ws.Range($"A2:A{row}").Merge();
                using (var stream = new System.IO.MemoryStream())
                {
                    wbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return content;
                }
            }


        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
