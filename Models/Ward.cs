﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace GovBE.Models;

public partial class Ward
{
    public int WardId { get; set; }

    public string FullName { get; set; }

    public int? DistrictId { get; set; }

    public DateTime? CreateOnUtc { get; set; }
}