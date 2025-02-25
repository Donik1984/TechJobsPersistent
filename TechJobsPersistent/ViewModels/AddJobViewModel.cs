﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TechJobsPersistent.Models;

namespace TechJobsPersistent.ViewModels
{
    public class AddJobViewModel
    {
        [Required(ErrorMessage = "A Name is required")]
        public string JobName { get; set; }
        public int EmployerId { get; set; }
        public List<SelectListItem> ListOfEmployers { get; set; }
        public List<Skill> Skills { get; set; }
        public AddJobViewModel() { }

        public AddJobViewModel(List<Employer> employers, List<Skill> skills)
        {
            this.Skills = skills;
            this.EmployerList(employers);
        }

        public void EmployerList (List<Employer> employers)
        {
            this.ListOfEmployers = new List<SelectListItem>();
            foreach (Employer employer in employers)
            {
                this.ListOfEmployers.Add(
                    new SelectListItem
                    {
                        Value = employer.Id.ToString(),
                        Text = employer.Name
                    });
            }

        }
    }
}
