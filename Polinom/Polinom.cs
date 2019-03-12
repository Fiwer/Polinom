using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolinomTask
{
    public class Polinom
    {
        private List<Odnochlen> list = new List<Odnochlen>();

        //Построение списка по полиному. Считывание с файла
        public Polinom(string filename)
        {
            var polynomial = File.ReadAllLines(filename);
            foreach (var row in polynomial)
            {
                var couple = row.Split(' ');
                list.Add(new Odnochlen(int.Parse(couple[0]), int.Parse(couple[1])));//из каждой пары делаем одночлен
            }
        }

        //Построение списка по полиному. Задается списком
        public Polinom(List<Tuple<double,int>> list)
        {
            foreach(var pare in list)
                this.list.Add(new Odnochlen(pare.Item1, pare.Item2));
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
            var result = new StringBuilder();
            Combine();
            foreach (var odnoclen in list)
            {
                if (odnoclen == list[0]) result.Append(odnoclen.coefficient + "x^" + odnoclen.degree);
                else
                {
                    result.Append(odnoclen.coefficient > 0 ? "+" : "");

                    if (odnoclen.degree != 0)
                        result.Append(odnoclen.coefficient + "x^" + odnoclen.degree);
                    else result.Append(odnoclen.coefficient);
                }
            }
            result.Append("= 0");
            return result.ToString();
        }

        //Вставка монома coef*x^deg в полином.
        public void Insert(int coef, int deg)
        {
            Sum(new Odnochlen(coef, deg));
        }

        //Приведение подобных членов в многочлене.
        public void Combine()
        {
            foreach (var odnochlen in list)
                if (odnochlen != list.Last() && odnochlen.degree == list.Last().degree)
                {
                    odnochlen.coefficient += list.Last().coefficient;
                    list.Remove(list.Last());
                    break;
                }
        }

        //Удалить элемент с данным показателем степени.
        public void Delete(int deg)
        {
            list = list.Where(z => z.degree != deg).ToList();
            
        }

        //Прибавить к нашему полиному полином p.
        //Привести подобные члены.
        public void Sum(Odnochlen p)
        {
            list.Add(p);//добавление в конец списка
            Combine();
        }

        //Взять производную у полинома.
        public void Derivate()
        {
            list = list.Where(z => z.degree != 0).ToList();
            list.ForEach(z => z.coefficient *= z.degree);
            list.ForEach(z => z.degree--);
        }

        //Вычислить значение полинома в точке x, используя наиболее экономный способ (схема Горнера)
        public int Value(int x)
        {
            Combine();
            var CoefList = list.Select(z => z.coefficient).ToList();
            var GornList = new List<double> {CoefList.First()};
            //таблица из списка коофицентов и коофицентов по схеме горнера
            CoefList.RemoveAt(0);
            foreach(var coef in CoefList)
                GornList.Add(x*GornList.Last()+coef);
            return (int)Math.Round(GornList.Last());
        }

        //Удалить из списка все элементы с нечетными коэффициентами.
        public void DeleteOdd()
        {
            list = list.Where(z => z.coefficient % 2 == 0).ToList();
        }
    }

    public class Odnochlen
    {
        public int degree;
        public double coefficient;
        public Odnochlen(double coef, int gree)
        {
            degree = gree;
            coefficient = coef;
        }
    }
}
