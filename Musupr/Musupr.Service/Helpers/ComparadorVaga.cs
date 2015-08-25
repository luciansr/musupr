using Musupr.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musupr.Service.Helpers
{
    public class ComparadorVaga : Comparer<Tuple<Vaga, double, double>>
    {
        public override int Compare(Tuple<Vaga, double, double> vaga1, Tuple<Vaga, double, double> vaga2)
        {
            double diffSalario;

            if (vaga1.Item1.Salario > vaga2.Item1.Salario)
            {
                diffSalario = -(1-(double)(vaga2.Item1.Salario + 1) / (vaga1.Item1.Salario + 1));
            }
            else
            {
                diffSalario = 1-(double)(vaga1.Item1.Salario + 1) / (vaga2.Item1.Salario + 1);
            }

            double diffAptidao;

            if (vaga1.Item2 > vaga2.Item2)
            {
                diffAptidao = -1+(double)(vaga2.Item2 + 0.01) / (vaga1.Item2 + 0.01);
            }
            else
            {
                diffAptidao = 1-(double)(vaga1.Item2 + 0.01) / (vaga2.Item2 + 0.01);
            }


            //= (double)(vaga1.Item2 + 0.01) / (vaga2.Item2 + 0.01);
            double diffDistancia = 0.0;

            if (vaga1.Item3 != 0.0 && vaga2.Item3 != 0.0)
            {
                //diffDistancia = (double)(vaga1.Item3 + 0.01) / (vaga2.Item3 + 0.01);

                if (vaga1.Item3 > vaga2.Item3)
                {
                    diffDistancia = 1-(double)(vaga2.Item3 + 0.01) / (vaga1.Item3 + 0.01);
                }
                else
                {
                    diffDistancia = -1+(double)(vaga1.Item3 + 0.01) / (vaga2.Item3 + 0.01);
                }
            }

            //diffDistancia = 1 / diffDistancia;

            double expressao;
            if (diffAptidao < 0.3 && diffAptidao > -0.3)
            {
                expressao = 4.3 * (diffSalario) + 3.0 * (diffAptidao) + 1.2 * (diffDistancia);
            }
            else
            {
                expressao = 1.5 * (diffSalario) + 2.5 * (diffAptidao) + 0.9 * (diffDistancia);
            }

            //expressao = 4.0 * (diffSalario - 1) + 3.0 * (diffAptidao - 1);

            if (expressao == 0) return 0;
            return expressao > 0 ? 1 : -1;
        }

    }
}
