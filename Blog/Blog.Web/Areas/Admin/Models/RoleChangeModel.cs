﻿using Microsoft.AspNetCore.Mvc.Rendering;

namespace Blog.Web.Areas.Admin.Models
{
    public class RoleChangeModel
    {
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }
        public SelectList? Users { get; set; }
        public SelectList? Roles { get; set; }
    }
}
