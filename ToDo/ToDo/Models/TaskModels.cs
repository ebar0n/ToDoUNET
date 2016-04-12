using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ToDo.Models
{
    public class TaskContext : DbContext
    {
        public DbSet<TaskModels> TaskModels { get; set; }
    }

    public class TaskModels
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        [Display(Name = "Titulo")]
        public string Title { get; set; }
        [Display(Name = "Descripcion")]
        public string Description { get; set; }
        [Display(Name = "¿Completada?")]
        public bool IsComplete { get; set; }
        [Display(Name = "Prioridad")]
        public int? Priority { get; set; }
        [Display(Name = "Fecha de expiración")]
        public DateTime? ExpirationDate { get; set; }
        [Display(Name = "Fecha de creación")]
        public DateTime? CreatedAt { get; set; }
        [Display(Name = "Fecha de actualización")]
        public DateTime? UpdatedAt { get; set; }
    }
}