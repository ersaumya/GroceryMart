using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GroceryMart.DomainModels.Entities
{
    public class User
    {
        public User()
        {
            Roles = new HashSet<Role>();
            Orders = new HashSet<Order>();
            CreatedDate = DateTime.Now; //default value
        }

        [Key]
        public int UserId { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(50)]
        [Required(ErrorMessage = "Please Enter Username")]
        public string Username { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(50)]
        [Required(ErrorMessage = "Please Enter Password")]
        public string Password { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(50)]
        [Required(ErrorMessage = "Please Enter Name")]
        public string Name { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(500)]
        public string Address { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(20)]
        public string ContactNo { get; set; }
        public DateTime CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
    }
}
