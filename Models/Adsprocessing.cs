﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace GovBE.Models;

public partial class Adsprocessing
{
    public int AdsProcessingId { get; set; }

    public int? AdsNewId { get; set; }

    public string ProcessingStatus { get; set; }

    public string Comment { get; set; }

    public DateTime? CreateOnUtc { get; set; }

    public DateTime? LastUpdateOnUtc { get; set; }

    public int? CreateUserId { get; set; }

    public int? UpdateUserId { get; set; }

    public bool IsActive { get; set; }
}