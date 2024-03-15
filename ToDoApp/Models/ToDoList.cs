using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ToDoApp.Models
{
    public class ToDoList
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Task is required")]
        [StringLength(100)]
        public string Task { get; set; }
        public bool IsCompleted { get; set; }

    }
}