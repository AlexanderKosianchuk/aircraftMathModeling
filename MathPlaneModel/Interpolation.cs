using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathPlaneModel
{
    class Interpolation
    {
        public Double ALPHA(Double Cy)
        {
            int size = 8;
            Double ALPHA;
            Double[] X = { -0.3, 0.05, 0.35, 0.6, 0.8, 1, 1.2, 1.35, 1.25 };//Cy
            Double[] Y = { 0, 3, 6, 9, 12, 15, 18, 21, 24 };//ALPHA

            int lowerIndex = 0;

            if (Cy <= X[0])
            {
                ALPHA = Y[0];
            }
            else if (Cy >= X[size])
            {
                ALPHA = Y[size];
            }
            else
            {
                while (Cy > X[lowerIndex])
                {
                    lowerIndex++;
                }

                if ((Cy - X[lowerIndex - 1]) < (X[lowerIndex] - Cy))
                {
                    lowerIndex = lowerIndex - 1;
                }

                ALPHA = Y[lowerIndex - 1] + 
                    ((Cy - X[lowerIndex - 1]) / (X[lowerIndex + 1] - X[lowerIndex - 1])) * 
                    (Y[lowerIndex + 1] - Y[lowerIndex - 1]);

            }


            return ALPHA;
        }

        public Double mz(Double ALPHA)
        {
            int size = 7;
            Double mz;
            Double[] X = { -2, 0, 4, 8, 12, 16, 20, 24 };//mz
            Double[] Y = { 0.3, 0.2, 0.1, 0, -0.1, -0.17, -0.22, -0.17 };//ALPHA

            int lowerIndex = 0;

            if (ALPHA <= X[0])
            {
                mz = Y[0];
            }
            else if (ALPHA >= X[size])
            {
                mz = Y[size];
            }
            else
            {
                while (ALPHA > X[lowerIndex])
                {
                    lowerIndex++;
                }

                if ((ALPHA - X[lowerIndex - 1]) < (X[lowerIndex] - ALPHA))
                {
                    lowerIndex = lowerIndex - 1;
                }

                mz = Y[lowerIndex - 1] + ((ALPHA - X[lowerIndex - 1]) / 
                    (X[lowerIndex + 1] - X[lowerIndex - 1])) * 
                    (Y[lowerIndex + 1] - Y[lowerIndex - 1]);
            }


            return mz;
        }

        /*public Double getAbscissaByOrdinate(interpolateCoefficients i, Double y)
        {
            Double x = 0;
            int lowerIndex = 0;

            if (y <= i.Y[0])
            {
                x = i.X[0];
            }
            else if (y >= i.Y[i.size])
            {
                x = i.X[i.size];
            }
            else
            {
                while (y < i.Y[lowerIndex])
                {
                    lowerIndex++;
                }

                x = i.X[lowerIndex] + ((y - i.Y[lowerIndex]) / (i.Y[lowerIndex + 1] - i.Y[lowerIndex])) * i.X[lowerIndex + 1] - i.X[lowerIndex];

            }


            return x;
        }*/
    }
}
