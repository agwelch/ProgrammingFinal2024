using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Query;
using ProgrammingFinal2024.Pages;
using ProgrammingFinal2024.Models;


namespace ProgrammingFinal2024.Models
{
    public class User
    {
        public int UserID {get; set;}
        [StringLength(50)]
        public string Name {get; set;} = string.Empty;
        public List <Project> ParticipatingProjects {get; set;} = new List<Project>();
        public List <Message> SentMessages {get; set;} = new List<Message>();
        public List <Message> ReceivedMessages {get; set;} = new List<Message>();
    }
}
