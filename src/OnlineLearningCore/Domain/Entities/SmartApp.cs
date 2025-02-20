﻿using System;
using System.Collections.Generic;

namespace OnlineLearningCore.Domain.Entities;

public partial class SmartApp
{
    public int SmartAppId { get; set; }

    public string AppName { get; set; } = null!;

    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}
