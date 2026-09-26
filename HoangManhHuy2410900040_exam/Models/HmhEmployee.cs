using System;
using System.Collections.Generic;

namespace HoangManhHuy2410900040_exam.Models;

public partial class HmhEmployee
{
    public long Id { get; set; }

    public string? HmhName { get; set; }

    public bool? HmhGender { get; set; }

    public DateOnly? HmhBirthDay { get; set; }

    public string? HmhEmail { get; set; }

    public int? HmhPhone { get; set; }

    public string? HmhActive { get; set; }
}
