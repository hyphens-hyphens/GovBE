﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace GovBE.Models;

public partial class Adsnew
{
    public int Id { get; set; }

    public int? AdsLocationId { get; set; }

    public string Comment { get; set; }

    public float? Width { get; set; }

    public float? Height { get; set; }

    public string SizeUnit { get; set; }

    public decimal? Latitute { get; set; }

    public decimal? Longtitute { get; set; }

    public string Name { get; set; }

    public string AdsAddress { get; set; }

    public int? KhuVuc { get; set; }

    public int? LoaiViTri { get; set; }

    public int? HinhThucQuangCao { get; set; }

    public string Description { get; set; }

    public DateTime? NgayBatDauHd { get; set; }

    public DateTime? NgayKetThucHd { get; set; }

    public string CompanyInfo { get; set; }

    public string Email { get; set; }

    public string CompanyAddress { get; set; }

    public string PhoneNumber { get; set; }

    public string City { get; set; }

    public string District { get; set; }

    public string Ward { get; set; }

    public int? ProcessingStatus { get; set; }

    public DateTime? CreateOnUtc { get; set; }

    public DateTime? LastUpdateOnUtc { get; set; }

    public int? CreateUserId { get; set; }

    public int? UpdateUserId { get; set; }

    public bool IsActive { get; set; }
}