using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Query;
using ProgrammingFinal2024.Pages;
using ProgrammingFinal2024.Models;


namespace ProgrammingFinal2024
{
    public class Project
    {
        public int ProjectID {get;set;}
        [StringLength(50)]
        public string Title {get;set;} = string.Empty;
        [StringLength(500)]
        public string Description {get;set;} = string.Empty;
        [StringLength(30)]
        public string Creator {get;set;} = string.Empty;
        public ICollection<User> Users { get; set; }




    }
   
    }


