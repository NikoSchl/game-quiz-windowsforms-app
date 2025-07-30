using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Models
{
    /// <summary>
    /// Stellt ein 
    /// </summary>
    public class ReadFile
    {
        public string Question { get; set; } = string.Empty;
        public string AnswerOne { get; set; } = string.Empty;
        public string AnswerTwo { get; set; } = string.Empty;
        public string AnswerThree { get; set; } = string.Empty;
        public int CorrectAnswer { get; set; }
    }
}
