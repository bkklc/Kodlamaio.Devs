﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SocialMediaAccounts.Dtos
{
    public class SocialMediaAccountGetByIdDto
    {
        public int Id { get; set; }
        public string Link { get; set; }
        public string Name { get; set; }
        public int? UserId { get; set; }

    }
}
