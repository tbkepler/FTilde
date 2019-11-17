using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Troschuetz.Random;

namespace FTilde
{
    class FTildeDriver
    {
        public double sigma = 1;
        public double zeta;
        public int K;
        public int N;
        public int NReps;
        Troschuetz.Random.Generators.MT19937Generator gen = new Troschuetz.Random.Generators.MT19937Generator();
        Troschuetz.Random.Distributions.Continuous.NormalDistribution rnorm;
        public FTildeDriver()
        {
            rnorm = new Troschuetz.Random.Distributions.Continuous.NormalDistribution(gen);
        }

        public double[] GenerateSamples(int nRep)
        {
            double[] samples = new double[nRep];
            for (int i = 0; i < nRep; i++)
            {
                samples[i] = GenerateSample();
            }
            return samples;
        }

        public double GenerateSample()
        {
            // generate a single deviate of Qm/Qr
            double[] delta = new double[K + 1];
            for (int i = 0; i < K + 1; i++)
            {
                delta[i] = zeta * rnorm.NextDouble();
            }

            double[] v = new double[K + 1];
            for (int i = 0; i < K + 1; i++)
            {
                v[i] = sigma * rnorm.NextDouble();
            }

            double[] w = new double[N-K-1];
            for (int i = 0; i < N - K - 1; i++)
            {
                w[i] = sigma * rnorm.NextDouble();
            }

            double num = 0;
            for (int i = 0; i < K + 1; i++)
            {
                num += Math.Pow(v[i] + delta[i],2);
            }

            double denom = 0;
            for (int i =0; i < K + 1; i++)
            {
                denom += Math.Pow(delta[i], 2);
            }

            for (int i =0; i < N- K- 1; i++)
            {
                denom += Math.Pow(w[i], 2);
            }

            return num / denom;
        }
    }
}
