﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserOperationsClaim.Dtos;

public class CreatedUserOperationClaimDto
{
    public int Id { get; set; }
    public string OperationClaimName { get; set; }
    public string UserName { get; set; }
}