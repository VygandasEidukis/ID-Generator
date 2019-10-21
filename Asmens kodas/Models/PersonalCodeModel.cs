using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asmens_kodas.Models
{
    public class PersonalCodeModel
    {
        public int Code { get; set; }
        public PersonalCodeModel(DateTime date, GenderEnum gender) 
        {
            CreateCode(date, gender);
        }

        private void CreateCode(DateTime date, GenderEnum gender)
        {
            GetGenderDidget(date.Year, gender);
            GetBithDateDidgets(date);
        }

        private int GetGenderDidget(int year, GenderEnum gender)
        {
            int genderNum;
            if(gender == GenderEnum.Male)
            {
                genderNum = 1;
            }else
            {
                genderNum = 2;
            }

            //century - (minCentury-19)*2
            int uniqueGenderAdder = (GetCentury(year) - 19) * 2;

            return genderNum + uniqueGenderAdder;
        }

        private int GetBithDateDidgets(DateTime date)
        {
            string dateCode = "";
            dateCode += (date.Year.ToString()).Substring(2,2);

            //get month ( if less than 10 adds 0)
            if(date.Month < 10)
            {
                dateCode += '0' + date.Month.ToString();
            }else
            {
                dateCode += date.Month;
            }

            //get day (if less than 10 adds 0)
            if(date.Day < 10)
            {
                dateCode += '0' + date.Day.ToString();
            }else
            {
                dateCode += date.Day;
            }

            return int.Parse(dateCode);
        }

        private int GetCentury(int year)
        {
            return (int)Math.Round((double)(year / 100), 0) + 1;
        }
    }
}
