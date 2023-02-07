﻿using ProductTracking.Core.Enums;

namespace ProductTracking.Api.DTO.ProductTracking;

public class ItemRequestDTO
{
    public Guid? ItemGroupId { get; set; }
    public string Name { get; set; }
    public string NameShort { get; set; }
    public EnStatus Status { get; set; }
}
