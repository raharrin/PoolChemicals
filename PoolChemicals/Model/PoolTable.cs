using Syncfusion.Maui.DataForm;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoolChemicals.Model
{
    [Table("poolLog")]
    public class PoolTable
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        public int PoolId { get; set; }

        [Display(ShortName = "Last name")]
        [Required(ErrorMessage = "Name should not be empty")]
        public required string LastName { get; set; }
        [DataFormDisplayOptions(ColumnSpan = 2)]
        [Required(ErrorMessage = "Address should not be empty")]
        public required string Address { get; set; }
        [DataFormDisplayOptions(ColumnSpan = 2)]
        [Required(ErrorMessage = "City should not be empty")]
        public required string City { get; set; }
        [Required(ErrorMessage = "State should not be empty")]
        public required string State { get; set; }
        [Display(ShortName = "Zip code")]
        [Required(ErrorMessage = "Zip Code should not be empty")]
        public required string Zip { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string? Email { get; set; }

        public required int PoolType { get; set; }
        [Required(ErrorMessage = "Volume should not be empty")]
        public required int Volume { get; set; } // in gallons
        public int Chlorine { get; set; }
    }
}
