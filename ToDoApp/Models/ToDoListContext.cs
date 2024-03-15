using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace ToDoApp.Models
{
    public class ToDoListContext:DbContext
    {
        public DbSet<ToDoList> ToDoLists { get; set; }
    }
}