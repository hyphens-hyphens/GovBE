﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace GovBE.Models;

public partial class Adsnew
{
    public int AdsNewId { get; set; }

    public int? AdsLocationId { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public string Comment { get; set; }

    public string CompanyInfo { get; set; }

    public string Email { get; set; }

    public string CompanyAddress { get; set; }

    public string PhoneNumber { get; set; }

    public string City { get; set; }

    public string District { get; set; }

    public string Ward { get; set; }

    public float? Width { get; set; }

    public float? Height { get; set; }

    public string SizeUnit { get; set; }

    public string AdsAddress { get; set; }

    public decimal? Latitude { get; set; }

    public decimal? Longtitude { get; set; }

    public string ProcessingStatus { get; set; }

    public int? CreateUserId { get; set; }

    public DateTime? CreateOnUtc { get; set; }

    public DateTime? LastUpdateOnUtc { get; set; }

    public int? UpdateUserId { get; set; }

    public bool IsActive { get; set; }
}