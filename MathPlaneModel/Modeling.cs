using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathPlaneModel
{

    public class Modeling
    {
        private int n = 0;

        public Modeling(int modelDimention)
        {
            n = modelDimention;
        }

        Interpolation i = new Interpolation();

        public void bal(IntegralMeanings S, Coefficient C, Controls del, Statics s)
        {
            S.V_BAL = s.Vo;
            S.Yg_BAL = s.Ho;
            del.Tr_BAL = s.Tro;
            C.y = (2 * s.G) / (s.S * s.PO_h * S.V_BAL * S.V_BAL);
            S.ALPHA_BAL = i.ALPHA(C.y);
            S.THETA_BAL = S.ALPHA_BAL;
            del.e_rv_BAL = s.mzo + i.mz(S.ALPHA_BAL) * S.ALPHA_BAL;
        
        }

        public void calcLinearCoef(IntegralMeanings S, Controls del, LinearizedCoefficient c, Statics s)
        {
            S.q = (s.PO_h * S.V * S.V) / 2;

            c.c1 = -(s.mz_w1z / s.Izz) * s.S * s.bA * s.bA * ((s.PO_h * S.V) / 2);
            c.c2 = -(s.mz_ALPHA / s.Izz) * s.S * s.bA * S.q;
            c.c3 = -(s.mz_del_e_rv / s.Izz) * s.S * s.bA * S.q;
            c.c4 = ((s.Cy_ALPHA + s.Cx) / s.m) * s.S * ((s.PO_h * S.V) / 2);
            c.c5 = -(s.mz_ALPHA1 / s.Izz) * s.S * s.bA * s.bA * ((s.PO_h * S.V) / 2);
            c.c6 = 0.01745 * S.V;
            c.c9 = (s.Cy_del_e_rv / s.m) * s.S * ((s.PO_h * S.V) / 2);

            c.a1 = -(s.my_w1y / s.Iyy) * s.S * s.L * s.L * ((s.PO_h * S.V) / 4);
            c.a2 = -(s.my_BETA / s.Iyy) * s.S * s.L * S.q;
            c.a3 = -(s.my_del_n / s.Iyy) * s.S * s.L * S.q;
            c.a4 = -(s.Cz_BETA / s.m) * s.S * S.q;
            c.a5 = -(s.mx_del_n / s.Ixx) * s.S * S.q;
            c.a6 = -(s.mx_w1y / s.Ixx) * s.S * s.L * s.L * ((s.PO_h * S.V) / 4);
            c.a7 = -(s.Cz_del_n / s.m) * s.S * S.q;

            c.b1 = -(s.mx_w1x / s.Ixx) * s.S * s.L * s.L * ((s.PO_h * S.V) / 4);
            c.b2 = -(s.mx_BETA / s.Ixx) * s.S * s.L * S.q;
            c.b3 = -(s.mx_del_e / s.Ixx) * s.S * s.L * S.q;
            c.b4 = s.g / S.V * cos(S.ALPHA);
            c.b5 = -(s.my_del_e / s.Iyy) * s.S * s.L * S.q;
            c.b6 = -(s.my_w1x / s.Iyy) * s.S * s.L * s.L * ((s.PO_h * S.V) / 4);
            c.b7 = sin(S.ALPHA);

        }

        public void dynLinear(DifferentialMeanings d, IntegralMeanings S, LinearizedCoefficient c, Controls del, Statics s)
        {
            d.THETA_DEL = S.Wz_DEL;
            d.Wz_DEL = -c.c1 * d.THETA_DEL - c.c2 * S.ALPHA_DEL - c.c5 * d.ALPHA_DEL - c.c3 * del.e_rv_DEL;
            d.THETA_PATH_DEL = c.c4 * S.ALPHA_DEL + c.c9 * del.e_rv_DEL;
            d.ALPHA_DEL = d.THETA_DEL - d.THETA_PATH_DEL;
            d.Yg_DEL = c.c6 * S.THETA_PATH_DEL;

            d.GAMA_DEL = S.Wx_DEL;
            d.Wy_DEL = -c.a1 * S.Wy_DEL - c.b6 * S.Wx_DEL - c.a2 * S.BETA_DEL - c.a3 * del.n_DEL - c.b5 * del.e_DEL;
            d.PSI_DEL = S.Wy_DEL;
            d.Wx_DEL = -c.a6 * S.Wy_DEL - c.b1 * S.Wx_DEL - c.b2 * S.BETA_DEL - c.a5 * del.n_DEL - c.b3 * del.e_DEL;
            d.BETA_DEL = S.Wy_DEL + c.b7 * S.Wx_DEL - c.b4 * S.PSI_DEL - c.a4 * S.BETA_DEL - c.a7 * del.n_DEL;

        }

        public void dynFullDiff(DifferentialMeanings d, IntegralMeanings S, LinearizedCoefficient c, Controls del, Statics s)
        {
            S.q = (s.PO_h * S.V * S.V) / 2;

            d.THETA = S.Wz;
            d.THETA_PATH = c.c4 * S.ALPHA + c.c9 * del.e_rv;
            d.Wz = -c.c1 * S.Wz - c.c2 * S.ALPHA - c.c3 * del.e_rv - c.c5 * d.ALPHA;
            d.ALPHA = d.THETA - d.THETA_PATH;

            d.GAMA = S.Wx;
            d.Wy = -c.a1 * S.Wy - c.b6 * S.Wx - c.a2 * S.BETA - c.a3 * del.n - c.b5 * del.e;
            d.PSI = S.Wy;
            d.Wx = -c.a6 * S.Wy - c.b1 * S.Wx - c.b2 * S.BETA - c.a5 * del.n - c.b3 * del.e;
            d.BETA = S.Wy + c.b7 * S.Wx - c.b4 * S.PSI - c.a4 * S.BETA - c.a7 * del.n;

        }


        public void takeOff(DifferentialMeanings d, IntegralMeanings S, Forses F, Moments M, Controls del, Statics s)
        {
            d.Vx = (1 / s.m) * F.x;
            d.BETA = (1 / (s.m * S.Vx)) * F.z + S.Wy;
            d.Wy = 1 / s.Iyy * M.y;
            d.X = S.Vx * cos(S.BETA);
            d.Z = -S.Vx * sin(S.BETA);

            S.Y = s.Cyo * S.q * s.S;
            S.Q = s.Cxo * S.q * s.S;

            F.x = 20 * del.Tr - S.Q - (s.G - S.Y) * (s.froll + s.fslip * (s.InhibitionL + s.InhibitionR));
            F.z = F.zBETA * S.BETA + F.zDELn * del.n + F.zt;

            F.zBETA = s.Cz_BETA * s.S * S.q;
            F.zDELn = s.Cz_del_n * s.S * S.q;
            F.zt = (s.G - S.Y) * s.Czk_BETA * (S.BETA + s.fW * del.fW);

            M.y = M.yz + M.yWy + M.yp + M.yt;

            M.yz = s.my_BETA * S.q * s.S * s.L * S.BETA + s.my_DELn * del.n;
            M.yWy = s.my_Wy * S.q * s.S * s.L * d.Wy;
            M.yp = 0; // = (P1 - P2) * s.Zengine
            M.yt = (s.fW * s.XfrontWheel * del.fW + s.fslip * (s.G - S.Y) * (s.InhibitionL + s.InhibitionR) * (s.Zchassis / 2));

            S.q = (s.PO_h * S.Vx * S.Vx / 2);

            d.Xg = S.Vx * cos(S.BETA);

        }

        private double cos(double d)
        {
            double r;
            r = Math.Cos(d / (180 / Math.PI));
            return r;
        }

        private double sin(double d)
        {
            double r;
            r = Math.Sin(d / (180 / Math.PI));
            return r;
        }

        private double tan(double d)
        {
            double r;
            r = Math.Tan(d / (180 / Math.PI));
            return r;
        }

        /// <summary>
        /// Отдает атрибутам класса интегральных значений результаты интергирования
        /// </summary>
        /// <param name="S">Инт значения</param>
        /// <param name="n">Размерность модели</param>
        public void returnIntegratedValues(IntegralMeanings S, Double[] Y)
        {
            S.Wx = Y[0];
            S.Wy = Y[1];
            S.Wz = Y[2];

            S.PSI = Y[3];
            S.GAMA = Y[4];
            S.THETA = Y[5];
            S.THETA_PATH = Y[6];

            S.ALPHA = Y[7];
            S.BETA = Y[8];

            S.Yg = Y[9];

        }


        /// <summary>
        /// Получаем диф значения после отработки модели
        /// </summary>
        /// <param name="d">Диф значения</param>
        /// <param name="n">Размерность модели</param>
        public Double[] getDiffValues(DifferentialMeanings d)
        {
            Double[] X =  new Double[n];

             X[0] = d.Wx;
             X[1] = d.Wy;
             X[2] = d.Wz;

             X[3] = d.PSI;

             X[4] = d.GAMA;
             X[5] = d.THETA;
             X[6] = d.THETA_PATH;

             X[7] = d.ALPHA;
             X[8] = d.BETA;

             X[9] = d.Yg;


            return (X);

        }

        /// <summary>
        /// Получаем интегральные значения после отработки модели
        /// </summary>
        /// <param name="S">Инт значения</param>
        /// <param name="n">Размерность модели</param>
        public Double[] getIntegratedValues(IntegralMeanings S)
        {
            Double[] Y = new Double[n];

            Y[0] = S.Wx;
            Y[1] = S.Wy;
            Y[2] = S.Wz;

            Y[3] = S.PSI;

            Y[4] = S.GAMA;
            Y[5] = S.THETA;
            Y[6] = S.THETA_PATH;

            Y[7] = S.ALPHA;
            Y[8] = S.BETA;

            Y[9] = S.Yg;

            return (Y);

        }

        /// <summary>
        /// Отдает атрибутам класса интегральных значений результаты интергирования
        /// </summary>
        /// <param name="S">Инт значения</param>
        /// <param name="n">Размерность модели</param>
        public void returnIntegratedValuesIncrements(IntegralMeanings S, Double[] Y)
        {
            S.Wx_DEL = Y[0];
            S.Wy_DEL = Y[1];
            S.Wz_DEL = Y[2];

            S.PSI_DEL = Y[3];
            S.GAMA_DEL = Y[4];
            S.THETA_DEL = Y[5];
            S.THETA_PATH_DEL = Y[6];

            S.ALPHA_DEL = Y[7];
            S.BETA_DEL = Y[8];

            S.Yg_DEL = Y[9];

        }


        /// <summary>
        /// Получаем диф значения после отработки модели
        /// </summary>
        /// <param name="d">Диф значения</param>
        /// <param name="n">Размерность модели</param>
        public Double[] getDiffValuesIncrements(DifferentialMeanings d)
        {
            Double[] X = new Double[n];

            X[0] = d.Wx_DEL;
            X[1] = d.Wy_DEL;
            X[2] = d.Wz_DEL;

            X[3] = d.PSI_DEL;

            X[4] = d.GAMA_DEL;
            X[5] = d.THETA_DEL;
            X[6] = d.THETA_PATH_DEL;

            X[7] = d.ALPHA_DEL;
            X[8] = d.BETA_DEL;

            X[9] = d.Yg_DEL;


            return (X);

        }

        /// <summary>
        /// Получаем интегральные значения после отработки модели
        /// </summary>
        /// <param name="S">Инт значения</param>
        /// <param name="n">Размерность модели</param>
        public Double[] getIntegratedValuesIncrements(IntegralMeanings S)
        {
            Double[] Y = new Double[n];

            Y[0] = S.Wx_DEL;
            Y[1] = S.Wy_DEL;
            Y[2] = S.Wz_DEL;

            Y[3] = S.PSI_DEL;

            Y[4] = S.GAMA_DEL;
            Y[5] = S.THETA_DEL;
            Y[6] = S.THETA_PATH_DEL;

            Y[7] = S.ALPHA_DEL;
            Y[8] = S.BETA_DEL;

            Y[9] = S.Yg_DEL;

            return (Y);

        }

        public void setRealParamValuesFromIncrements(IntegralMeanings S, DifferentialMeanings d, Controls del)
        {
            S.V = S.V_BAL + S.V_DEL;

            S.Wx = S.Wx_BAL + S.Wx_DEL;
            S.Wy = S.Wy_BAL + S.Wy_DEL;
            S.Wz = S.Wz_BAL + S.Wz_DEL;

            S.Xg = S.Xg_BAL + S.Xg_DEL;
            S.Yg = S.Yg_BAL + S.Yg_DEL;
            S.Zg = S.Zg_BAL + S.Zg_DEL;

            S.GAMA = S.GAMA_BAL + S.GAMA_DEL;
            S.PSI = S.PSI_BAL + S.PSI_DEL;

            S.THETA = S.THETA_BAL + S.THETA_DEL;
            S.THETA_PATH = S.THETA_PATH_BAL + S.THETA_PATH_DEL;

            S.ALPHA = S.ALPHA_BAL + S.ALPHA_DEL;
            S.BETA = S.BETA_BAL + S.BETA_DEL;

            d.Wx = d.Wx_DEL;
            d.Wy = d.Wy_DEL;
            d.Wz = d.Wz_DEL;

            d.Xg = d.Xg_DEL;
            d.Yg = d.Yg_DEL;
            d.Zg = d.Zg_DEL;

            d.GAMA = d.GAMA_DEL;
            d.PSI = d.PSI_DEL;

            d.THETA = d.THETA_DEL;
            d.THETA_PATH = d.THETA_PATH_DEL;

            d.ALPHA = d.ALPHA_DEL;
            d.BETA = d.BETA_DEL;

            del.e = del.e_DEL + del.e_BAL;
            del.n = del.n_DEL + del.n_BAL;
            del.e_rv = del.e_rv_DEL + del.e_rv_BAL;
            del.Tr = del.Tr_DEL + del.Tr_BAL;
        }

    }
}

        //public void dyn(DifferentialMeanings d, IntegralMeanings S, Forses F, Moments M, Coefficient Ca, OperatingAngularVelocity o, Controls del, Statics s)
        //{
            
        //    d.Vx = (-S.Wy) * S.Vz + S.Wz * S.Vy + (F.x1 + F.x2 + F.x3) / s.m;
        //    d.Vy = (-S.Wz) * S.Vx + S.Wx * S.Vz + (F.y1 + F.y2 + F.y3) / s.m; 
        //    d.Vz = (-S.Wx) * S.Vy + S.Wy * S.Vx + (F.z1 + F.z2 + F.z3) / s.m;  

        //    d.Wx = ((-S.Wy) * S.Wz * (s.Izz - s.Iyy) + M.x1 + M.x3) / s.Ixx;
        //    d.Wy = ((-S.Wz) * S.Wx * (s.Ixx - s.Izz) + M.y1 + M.y3) / s.Iyy;
        //    d.Wz = ((-S.Wx) * S.Wy * (s.Iyy - s.Ixx) + M.z1 + M.z3) / s.Izz; 

        //    d.Xg = S.Vx * cos(S.PSI) * cos(S.THETA) +
        //           S.Vy * ((-cos(S.PSI)) * sin(S.THETA) * cos(S.GAMA) + sin(S.PSI) * sin(S.GAMA)) +
        //           S.Vz * (cos(S.PSI) * sin(S.THETA) * sin(S.GAMA) + sin(S.PSI) * cos(S.GAMA));

        //    d.Yg = S.Vx * sin(S.THETA) +
        //           S.Vy * cos(S.THETA) * cos(S.GAMA) -
        //           S.Vz * cos(S.THETA) * sin(S.GAMA); 

        //    d.Zg = (-S.Vx) * cos(S.THETA) * sin(S.GAMA) +
        //             S.Vy * (cos(S.PSI) * sin(S.GAMA) + sin(S.THETA) * sin(S.PSI) * cos(S.GAMA)) +
        //             S.Vz * (cos(S.PSI) * cos(S.GAMA) - sin(S.THETA) * sin(S.PSI) * sin(S.GAMA));

        //    d.GAMA = S.Wx - (S.Wy * cos(S.GAMA) - S.Wz * sin(S.GAMA)) * tan(S.THETA);
        //    d.PSI = (S.Wy * cos(S.GAMA) - S.Wz * sin(S.GAMA)) / cos(S.THETA);
        //    d.THETA = S.Wy * sin(S.GAMA) - S.Wz * cos(S.GAMA);

        //    S.V = Math.Sqrt(S.Vx * S.Vx + S.Vy * S.Vy + S.Vz * S.Vz);
        //    S.ALPHA = -Math.Asin(S.Vy / Math.Sqrt(S.Vx * S.Vx + S.Vz * S.Vz));
        //    S.BETA = Math.Asin(S.Vz / S.V);

        //    S.q = (s.PO_h * S.V * S.V / 2 );

        //    F.x1 = ((-Ca.x) * cos(S.ALPHA) * cos(S.BETA) +
        //              Ca.y * sin(S.ALPHA) -
        //              Ca.z * cos(S.ALPHA) * sin(S.BETA)) * S.q * s.S;

        //    F.y1 = (Ca.x * sin(S.ALPHA) * cos(S.BETA) +
        //            Ca.y * cos(S.ALPHA) +
        //            Ca.z * cos(S.BETA) * sin(S.ALPHA)) * S.q * s.S;

        //    F.z1 = ((-Ca.x )* sin(S.BETA) + Ca.z * cos(S.BETA)) * S.q * s.S;

        //    Ca.x = s.Cxo + s.A * Ca.y * Ca.y + s.DELTA_Cxa;
        //    Ca.y = s.Cyo + s.Cy_ALPHA * S.ALPHA;
        //    Ca.z = s.Cz_BETA * S.BETA;

        //    F.x2 = -s.m * s.g * sin(S.THETA);
        //    F.y2 = -s.m * cos(S.THETA) * cos(S.GAMA);
        //    F.z2 = s.m * s.g * cos(S.THETA) * sin(S.GAMA);

        //    F.x3 = del.Tr;
        //    F.y3 = del.Tr * sin(s.ALPHAt);
        //    F.z3 = 0;

        //    M.x1 = (s.mx_BETA * S.BETA + s.mx_w1x * o.Wx + s.mx_w1y * o.Wy) * S.q * s.S * s.L;
        //    M.y1 = (s.my_BETA * S.BETA + s.my_w1x * o.Wx + s.my_w1y * o.Wy) * S.q * s.S * s.L;
        //    M.z1 = (s.mzo + s.mz_ALPHA * S.ALPHA + (s.mz_w1z_plus_mz_ALPHA1) * o.Wz) * S.q * s.S * s.L;

        //    o.Wx = S.Wx * s.L / (2 * S.V);
        //    o.Wy = S.Wy * s.L / (2 * S.V);
        //    o.Wz = S.Wz * s.A / S.V;

        //    M.x3 = (s.mx_del_e * del.e + s.mx_del_n * del.n) * S.q * s.S * s.L;
        //    M.y3 = (s.my_del_n * del.n + s.my_del_e * del.e) * S.q * s.S * s.L;
        //    M.z3 = (s.mz_del_e_rv * del.e_rv) * S.q * s.S * s.L;
        //}

        //public void dyn(DifferentialMeanings d, IntegralMeanings S, Forses F, Moments M, Coefficient c, Overload N, Controls del, Statics s)
        //{

        //    d.V = N.x - sin(S.THETAt);
        //    S.Vy = S.V * sin(S.THETAt);

        //    d.ALPHAt = -((s.g / s.G) * (N.y - cos(S.V) * cos(S.GAMA)) - S.Wx * S.BETAt + S.Wz - (S.ALPHAt / S.V) * d.V); //Alpha
        //    d.BETAt = (s.g / S.V) * (N.z + cos(S.THETA) * sin(S.GAMA)) + S.Wx * S.ALPHAt + S.Wy - (S.BETAt / S.V * d.V); //beta

        //    S.ALPHA = S.ALPHAt;
        //    S.BETA = S.BETAt;

        //    d.THETAt = S.Wz * cos(S.GAMAc) + S.Wy * sin(S.GAMAc) + S.Wx * (S.ALPHAt * sin(S.GAMAc) - S.BETAt * cos(S.GAMAc));
        //    d.GAMAc = S.Wx - S.Wy * (S.ALPHAt + cos(S.GAMAc) - tan(S.THETAt)) + S.Wz * (S.BETAt + sin(S.GAMAc * tan(S.THETAt)));
        //    d.PSI = (S.Wx - d.GAMA) * sin(S.THETA) + (S.Wy * cos(S.GAMA) - S.Wz * sin(S.GAMA)) * cos(S.THETA);

        //    S.THETA = S.THETAt  + S.ALPHAt * cos(S.GAMA) + S.BETAt * sin(S.GAMA);
        //    S.GAMA = S.Wx - d.PSI * sin(S.THETA);
        //    //S.PSIc = S.PSI + 1/cos(S.THETA) * (S.ALPHA * sin(S.GAMA) - S.BETA * cos(S.GAMA));

        //    d.Wx = -((s.Izz - s.Iyy)/(s.Ixx)*S.Wy*S.Wz) + 
        //        (s.S * s.L * s.L)/(4*s.Ixx) * M.x_roll * s.PO_h * S.V +
        //        (s.S * s.L) / (2 * s.Ixx) * M.x_slide * s.PO_h * S.V * S.V;
           
        //    d.Wy = -((s.Ixx - s.Izz) / (s.Iyy) * S.Wx * S.Wz) +
        //        (s.S * s.L * s.L) / (4 * s.Iyy) * M.y_roll * s.PO_h * S.V +
        //        (s.S * s.L) / (2 * s.Iyy) * M.y_slide * s.PO_h * S.V * S.V;

        //    d.Wz = -((s.Iyy - s.Ixx) / (s.Izz) * S.Wx * S.Wy) +
        //        (s.S * s.bA * s.bA) / (2 * s.Izz) * M.z_roll * s.PO_h * S.V +
        //        (s.S * s.bA) / (2 * s.Izz) * M.z_slide * s.PO_h * S.V * S.V +
        //        (2.9 * s.Ipp) / (30 * s.Izz) * 20 * del.Tr;

        //    M.x_roll = s.my_w1y * S.Wy + s.my_w1x * S.Wx;
        //    M.x_slide = s.my_BETA * (S.BETAt * 57.3) + (s.mx_del_e * (del.e * 57.3));

        //    M.y_roll = s.mx_w1x * S.Wx;
        //    M.y_slide = s.mx_BETA * (S.BETAt * 57.3) + (s.my_del_n * (del.n * 57.3));

        //    M.z_roll = s.mz_w1z * S.Wz + s.mz_ALPHA * d.ALPHA;
        //    M.z_slide = s.mzo + (s.mz_del_e_rv * (del.e_rv * 57.3));

        //    d.Xg = S.V * cos(S.THETA) * cos(S.PSI);
        //    d.Yg = S.V * sin(S.THETA);
        //    d.Zg = S.V * cos(S.THETA) * sin(S.PSI);

        //    N.x = N.xt + N.y * S.ALPHAt - N.z * S.BETAt;
        //    N.xt = (S.R + (c.z * S.BETAt - c.x) * s.S * S.q) / s.G;

        //    N.y = S.Yg / s.G;
        //    N.z = (c.z * s.S * S.q) / s.G;
            
        //    S.R = 0;
        //    S.q = (s.PO_h * S.V * S.V / 2 );

        //    c.x = s.Cxo;
        //    c.y = s.Cyo;
        //    c.z = s.Cz_BETA * (S.BETAt * 57.3) + s.Cz_DELn * (del.n * 57.3);
        //}
