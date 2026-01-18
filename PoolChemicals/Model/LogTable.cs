using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;

namespace PoolChemicals.Model
{
    [Table("resultsLog")]
    public class LogTable
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        public int PoolId { get; set; }
        public int Volume { get; set; } // in gallons   
        public int Tempurature { get; set; }    
        public double SaturationIndex { get; set; }
        public int Salt {  get; set; }
        public double FC { get; set; }
        public double PH {  get; set; }
        public int Alkaline { get; set; }
        public int Calcium { get; set; }
        public int CYA { get; set; }
        public int Borate { get; set; }
        public DateTime Date { get; set; }
    }
}
