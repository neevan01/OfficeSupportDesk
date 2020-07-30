using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DomainModel
{
    public class Issue
    {
        public int IssueId { get; set; }        
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public string State { get; set; }
        public string Impact { get; set; }
        public string Urgency { get; set; }
        public string Priority { get; set; }  
        [Required]
        public string Issues { get; set; }
        public string AssignedTo { get; set; }
    }
}