﻿using System;
using System.Collections.Generic;

namespace OnlineLearningCore.Domain.Entities;

public partial class UserRole
{
    public int UserRoleId { get; set; }

    public int RoleId { get; set; }

    public int UserId { get; set; }

    public int SmartAppId { get; set; }

    public virtual Role Role { get; set; } = null!;

    public virtual SmartApp SmartApp { get; set; } = null!;

    public virtual UserProfile User { get; set; } = null!;
}
