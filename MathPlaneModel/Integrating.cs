using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MathPlaneModel;

namespace MathPlaneModel
{
    public class Integrating
    {
        /// <summary>
        /// Интегрирование по Эйлеру
        /// </summary>
        /// <param name="n">Размерность модели</param>
        /// <param name="dt">Шаг интегрирования</param>
        /// <param name="X">Диф значения полученые путем моделирования</param>
        /// <param name="Y">Значения пареметров(после интегрирования)</param>
        public void eiler(int n, double dt, double[] X, double[] Y)
        {
            for (int i = 0; i < n; i++)
            {
                Y[i] = Y[i] + X[i] * dt;
            }

        }

        /// <summary>
        /// Первый этап интегрирование Рунге-Кутты
        /// </summary>
        /// <param name="n">Размерность модели</param>
        /// <param name="dt">Шаг интегрирования</param>
        /// <param name="X">Диф значения полученые путем моделирования</param>
        /// <param name="Y">Значения пареметров(после интегрирования)</param>
        /// <param name="X0">Буферный массив(должен быть равен размерности модели)</param>
        /// <returns>Буферный массив для второго этапа</returns>
        public Double[] rungeKytti_step1(int n, double dt, Double[] X, Double[] Y, Double[] X0)
        {
            for (int i = 0; i < n; i++)
            {
                Y[i] = Y[i] + X[i] * dt;
                X0[i] = X[i];
            }
            return (X0);

        }

        /// <summary>
        /// Второй этам интегрирования Рунге-Кутты
        /// </summary>
        /// <param name="n">Размерность модели</param>
        /// <param name="dt">Шаг интегрирования</param>
        /// <param name="X">Диф значения полученые путем моделирования</param>
        /// <param name="Y">Значения пареметров(после интегрирования)</param>
        /// <param name="X0">Буферный массив полученый после первого этапа</param>
        public void rungeKytti_step2(int n, double dt, Double[] X, Double[] Y, Double[] X0)
        {
            for (int i = 0; i < n; i++)
            {
                Y[i] = Y[i] + (X[i] - X0[i]) * dt;
            }
        }

        /// <summary>
        /// Первый этап интегрирования Рунге-Кутты с коррекцией
        /// </summary>
        /// <param name="n">Размерность модели</param>
        /// <param name="dt">Шаг интегрирования</param>
        /// <param name="X0">Буферный массив(должен быть равен размерности модели)</param>
        /// <param name="Y">Значения пареметров(после интегрирования)</param>
        /// <returns>Буферный массив для второго этапа</returns>
        public Double[] rungeKytti_withCor_step1(int n, double dt, Double[] X0, Double[] Y)
        {
            for (int i = 0; i < n; i++)
            {
                Y[i] = Y[i] + dt * X0[i];
            }
            return (X0);
        }

        /// <summary>
        /// Второй этап интегрирования Рунге-Кутты с коррекцией
        /// </summary>
        /// <param name="n">Размерность модели</param>
        /// <param name="dt">Шаг интегрирования</param>
        /// <param name="X">Диф значения полученые путем моделирования</param>
        /// <param name="Y">Значения пареметров(после интегрирования)</param>
        /// <param name="X0">Буферный массив полученый после первого этапа</param>
        public void rungeKytti_withCor_step2(int n, double dt, Double[] X, Double[] Y, Double[] X0)
        {
            for (int i = 0; i < n; i++)
            {
                Y[i] = Y[i] + (dt / 2) * (X[i] - X0[i]);
            }
        }
    }
}
