using System;

namespace Agenda.WebApi.Helpers
{
    public static class DateTimeExtesions
    {
        public static int GetCurrentAge(this DateTime DataNasc)
        {
            DateTime DataAtual = DateTime.Now;
            int Idade = DataAtual.Year - DataNasc.Year;

            if(DataAtual.Month < DataNasc.Month || 
               (DataAtual.Month == DataNasc.Month && DataAtual.Day < DataNasc.Day))
            {
                Idade--;
            }

            return Idade;
        }

        public static string GetBirthday(this DateTime DataNasc)
        {
            return $"{DataNasc.Day.ToString("00")}/{DataNasc.Month.ToString("00")}";
        }
    }
}