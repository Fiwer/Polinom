using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polinom
{
    public class Polinom
    {
        private List<Odnochlen> list;

        //Построение списка по полиному.
        public Polinom(string filename)
        {
            var file = File.ReadLines(filename);
            foreach(var para in file)
            {
                //-17x^2 = -17,2
                string[] temp = para.Split(' ', 'x','^');
                list.Add(new Odnochlen(para[1],para[0]));
            }
        }

        //Номер коффициента в полиноме
        public double this[int i]
        {
            get
            {
                if (i < 0 || i >= list.Count) throw new IndexOutOfRangeException();
                return list[i].coefficient;
            }

            set
            {
                if (i < 0 || i >= list.Count) throw new IndexOutOfRangeException();
                list[i].coefficient = value;
            }
        }

        //Возврат строкового представления полинома.
        public override string ToString()
        {
            var answer = new StringBuilder();
            foreach (var odnoclen in list)
            {
                if(odnoclen!=list[0])
                answer.Append(odnoclen.coefficient + "x^" + odnoclen.degree);
                else
                {
                    answer.Append(odnoclen.coefficient > 0 ? "+" : "-");
                    answer.Append(odnoclen.coefficient + "x^" + odnoclen.degree);
                }
                
            }
            answer.Append("= 0");
            return answer.ToString();
        }

        //Вставка монома coef*x^deg в полином.
        public void insert(int coef, int deg)
        {
            list.Add(new Odnochlen(deg, coef));
        }

        //Приведение подобных членов в многочлене.
        public void combine()
        {
            foreach (var odnochlen in list)
                if(list.Last().degree != 0)
                {
                    odnochlen.coefficient += odnochlen.degree == list.Last().degree ? list.Last().coefficient : 0;
                    break;
                }
                
        }

        //Удалить элемент с данным показателем степени.
        public void delete(int deg)
        {
            foreach (var odnochlen in list)
                if (odnochlen.degree == deg)
                {
                    list.Remove(odnochlen);
                    break;
                }

        }

        //Прибавить к нашему полиному полином p.
        //Привести подобные члены.
        public void sum(Odnochlen p)
        {
            list.Add(p);
            //17x^2+6x+1+9x^2=0
            combine();
        }

        //Взять производную у полинома.
        public void derivate()
        {
            foreach (var odnochlen in list)
            {
                odnochlen.coefficient *= odnochlen.degree;
                odnochlen.degree -= 1;
                
            }
        }

        //Вычислить значение полинома в точке x, используя наиболее экономный способ (схема Горнера)
        public int value(int x)
        {
            foreach (var odnochlen in list)
            {
                odnochlen.coefficient *= x;
                odnochlen.degree -= 1;              
            }
        }

        //Удалить из списка все элементы с нечетными коэффициентами.
        public void deleteOdd()
        {
            foreach (var odnochlen in list)
                if (odnochlen.coefficient % 2 != 0) list.Remove(odnochlen);
        }

    }

    public class Odnochlen
    {
        public int degree;
        public double coefficient;
        public Odnochlen(int degree, double coefficient)
        {
            this.degree = degree;
            this.coefficient = coefficient;
        }
      
    }
}
