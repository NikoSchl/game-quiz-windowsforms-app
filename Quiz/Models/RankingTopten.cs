using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Models
{
    /// <summary>
    ///  
    /// </summary>
    public class RankingTopten : IComparable<RankingTopten>
    {
        public string Name { get; set; } = string.Empty;
        public decimal Prozent { get; set; }

        public int CompareTo(RankingTopten highscore)
        {
            if (highscore == null)
            {
                throw new ArgumentNullException("highscore");
            }
            if (Prozent < highscore.Prozent)
            {
                return -1;
            }
            else if (Prozent > highscore.Prozent)
            {
                return 1;
            }
            else
            { return 0; }
        }
    }
}
