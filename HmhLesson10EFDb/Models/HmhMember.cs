using System;
using System.Collections.Generic;

namespace HmhLesson10EFDb.Models;

public partial class HmhMember
{
    public long Id { get; set; }

    public string? HmhUserName { get; set; }

    public string? HmhPassword { get; set; }

    public string? HmhFullName { get; set; }

    public string? HmhEmail { get; set; }

    public string? HmhPhone { get; set; }

    public bool? HmhStatus { get; set; }
}
