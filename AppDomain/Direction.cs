using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDomain
{
    public interface IDirection
    {
        char GetDirection(string current);
        int GetStepCount(char direction);
        char GetAxis(char direction);

    }
    public class Direction:IDirection
    {
         Dictionary<string, char> directions;
        public Direction()
        {
            directions = new Dictionary<string, char>();
            directions.Add("NR", 'E');
            directions.Add("NL", 'W');
            directions.Add("ER", 'S');
            directions.Add("EL", 'N');
            directions.Add("SR", 'W');
            directions.Add("SL", 'E');
            directions.Add("WR", 'N');
            directions.Add("WL", 'S');
            directions.Add("WM", 'W');
            directions.Add("NM", 'N');
            directions.Add("SM", 'S');
            directions.Add("EM", 'E');
        }

        public char GetDirection(string current)
        {
            if (string.IsNullOrEmpty(current))
                throw new ArgumentNullException("Rota bilgisi giriniz");

            var sonuc = directions.FirstOrDefault(x => x.Key == current);
            if (sonuc.Key == null)
                throw new IndexOutOfRangeException("Bilinemeyen rota bilgisi");
            return sonuc.Value;
           
        }

        public  int GetStepCount(char direction)
        {
            if (direction == 'N' || direction == 'E')
                return 1;
            else if (direction == 'W' || direction == 'S')
                return -1;
            else
                throw new Exception();
        }

        public  char GetAxis(char direction)
        {
            if (direction == 'N' || direction == 'S')
                return 'Y';
            else if (direction == 'W' || direction == 'E')
                return 'X';
            else
                return '?';
        }
    }
}
