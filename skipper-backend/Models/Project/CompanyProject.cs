﻿using skipper_backend.Identity;
using skipper_backend.Models.Employee;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace skipper_backend.Models.Project
{
    public class CompanyProject
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public bool Active { get; set; }

        public List<ProjectComment> Comments { get; set; }
        public List<EmployeeProject> Employees { get; set; }

    }
}
