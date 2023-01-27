using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CompareAttribute = System.ComponentModel.DataAnnotations.CompareAttribute;

namespace ItStepSDP211.Models
{
    public class Player
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Required(ErrorMessage = "This is required field")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Min = 3 Max = 50 symbols for Field")]
        [Display(Name = "Soccers name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "This is required field")] // qwertyterw@gmail.com
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}",ErrorMessage = "Incorrect input of address")] 
        [Display(Name = "Soccers email")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare("Password",ErrorMessage ="Passwords not equal")]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }

        [Required]
        [Range(15, 40, ErrorMessage = "Unacceptable age")]
        [Display(Name = "Soccers age")]
        public int Age { get; set; }
        [Required]
        [Display(Name = "Soccers position")]
        public string Position { get; set; }
        [Required]
        [Remote("Check","Players",ErrorMessage = "Check is not valid")]
        public string Check { get; set; } //qwerty        U: qwerq  
        public int? TeamId { get; set; }
        public Team Team { get; set; }

    }

    public class Team
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Team name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Coach name")]
        public string Coach { get; set; }

        public ICollection<Player> Players { get; set; }
        public Team()
        {
            Players = new List<Player>();
        }
    }

    public class PlayersListViewModel
    {
        public IEnumerable<Player> Players { get; set; }
        public SelectList Position { get; set; }
        public SelectList Team { get; set; }
    }

    public class MenuItem
    {
        public int Id { get; set; }
        public string Header { get; set; } // загаловком 
        public string Url { get; set; }
        public int? Order { get; set; }
        public int? ParentId { get; set; }
        public MenuItem Parent { get; set; }
        public ICollection<MenuItem> Children { get; set; }
        public MenuItem(){
            Children = new List<MenuItem>();
        }
    }

}