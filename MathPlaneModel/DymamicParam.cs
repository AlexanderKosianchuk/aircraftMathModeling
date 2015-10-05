using System;
using System.Collections.Generic;

namespace MathPlaneModel
{
    public class Controls
    {
        public double e = 0;                   
        public double n = 0;                         
        public double e_rv = 0;
        public double Tr = 0;

        public double e_DEL = 0;
        public double n_DEL = 0;
        public double e_rv_DEL = 0;
        public double Tr_DEL = 0;

        public double e_BAL = 0;
        public double n_BAL = 0;
        public double e_rv_BAL = 0;
        public double Tr_BAL = 0;

        public double fW = 0; //угол поворота переднего колеса

        public void Clear()
        {
            e = 0;
            n = 0;
            e_rv = 0;
            Tr = 0;

            e_DEL = 0;
            n_DEL = 0;
            e_rv_DEL = 0;
            Tr_DEL = 0;

            e_BAL = 0;
            n_BAL = 0;
            e_rv_BAL = 0;
            Tr_BAL = 0;

            fW = 0;
        }
    }

    public class Moments
    {
        public double x = 0;
        public double y = 0;
        public double z = 0;

        public double x1 = 0;                          
        public double x2 = 0;                          
        public double x3 = 0;                           
        public double y1 = 0;                           
        public double y2 = 0;                             
        public double y3 = 0;                           
        public double z1 = 0;                           
        public double z2 = 0;                             
        public double z3 = 0;

        public double yz = 0;  //момент, создаваемый боковыми аэродин. силами
        public double yWy = 0; //момент демпфирования обусловленый угловой скоростью Wy
        public double yp = 0; //момент, как следствие несиметричной тяги двиготелей
        public double yt = 0; //момент несиметричного торможения   

        public double x_roll = 0;
        public double x_slide = 0;

        public double y_roll = 0;
        public double y_slide = 0;

        public double z_roll = 0;
        public double z_slide = 0;

        public void Clear()
        {
            x = 0;
            y = 0;
            z = 0;
        }

    }

    public class Forses
    {
        public double x = 0;
        public double y = 0;
        public double z = 0;

        public double x1 = 0;                   
        public double x2 = 0;                   
        public double x3 = 0;                     
        public double y1 = 0;                       
        public double y2 = 0;                      
        public double y3 = 0;                        
        public double z1 = 0;                     
        public double z2 = 0;                   
        public double z3 = 0;

        public double zBETA = 0;
        public double zDELn = 0;
        public double zt = 0;  //сила торможения   

        public void Clear()
        {
            x = 0;
            y = 0;
            z = 0;
        }

    }

    public class Coefficient
    {
        public double x = 0;                    
        public double y = 0;                       
        public double z = 0;

        public void Clear()
        {
            x = 0;
            y = 0;
            z = 0;
        } 
  
    }

    public class Overload //N
    {
        public double x = 0;
        public double y = 0;
        public double z = 0;

        public double xt = 0;

        public void Clear()
        {
            x = 0;
            y = 0;
            z = 0;
        }
    }

    public class OperatingAngularVelocity
    {
        public double Wx = 0;                   
        public double Wy = 0;                   
        public double Wz = 0;

        public void Clear()
        {
            Wx = 0;
            Wy = 0;
            Wz = 0;
        }
    }

    /// <summary>
    /// Структура для хранения результатов диф исчислений
    /// </summary>
    public class DifferentialMeanings
    {
        public double V = 0;

        public double Vx = 0;
        public double Vy = 0;
        public double Vz = 0;

        public double Wx = 0;
        public double Wy = 0;
        public double Wz = 0;

        public double X = 0;
        public double Y = 0;
        public double Z = 0;

        public double Xg = 0;
        public double Yg = 0;
        public double Zg = 0;

        public double GAMA = 0;
        public double GAMAc = 0;

        public double PSI = 0;
        public double PSIc = 0;

        public double THETA = 0;
        public double THETA_PATH = 0;
        public double THETAt = 0;

        public double ALPHA = 0;
        public double BETA = 0;

        public double ALPHAt = 0;
        public double BETAt = 0;

        //==============================

        public double V_DEL = 0;

        public double Xg_DEL = 0;
        public double Yg_DEL = 0;
        public double Zg_DEL = 0;

        public double Wx_DEL = 0;
        public double Wy_DEL = 0;
        public double Wz_DEL = 0;

        public double GAMA_DEL = 0;
        public double PSI_DEL = 0;

        public double THETA_DEL = 0;
        public double THETA_PATH_DEL = 0;

        public double ALPHA_DEL = 0;
        public double BETA_DEL = 0;

        //==============================

        public double V_BAL = 0;

        public double Xg_BAL = 0;
        public double Yg_BAL = 0;
        public double Zg_BAL = 0;

        public double Wx_BAL = 0;
        public double Wy_BAL = 0;
        public double Wz_BAL = 0;

        public double GAMA_BAL = 0;
        public double PSI_BAL = 0;

        public double THETA_BAL = 0;
        public double THETA_PATH_BAL = 0;

        public double ALPHA_BAL = 0;
        public double BETA_BAL = 0;

        //==============================

        public void Clear()
        {
            V = 0;

            Vx = 0;
            Vy = 0;
            Vz = 0;

            Wx = 0;
            Wy = 0;
            Wz = 0;

            X = 0;
            Y = 0;
            Z = 0;

            Xg = 0;
            Yg = 0;
            Zg = 0;

            GAMA = 0;
            GAMAc = 0;

            PSI = 0;
            PSIc = 0;

            THETA = 0;
            THETA_PATH = 0;
            THETAt = 0;

            ALPHA = 0;
            BETA = 0;

            ALPHAt = 0;
            BETAt = 0;

            //==============================

            V_DEL = 0;

            Xg_DEL = 0;
            Yg_DEL = 0;
            Zg_DEL = 0;

            Wx_DEL = 0;
            Wy_DEL = 0;
            Wz_DEL = 0;

            GAMA_DEL = 0;
            PSI_DEL = 0;

            THETA_DEL = 0;
            THETA_PATH_DEL = 0;

            ALPHA_DEL = 0;
            BETA_DEL = 0;

            //==============================

            V_BAL = 0;

            Xg_BAL = 0;
            Yg_BAL = 0;
            Zg_BAL = 0;

            Wx_BAL = 0;
            Wy_BAL = 0;
            Wz_BAL = 0;

            GAMA_BAL = 0;
            PSI_BAL = 0;

            THETA_BAL = 0;
            THETA_PATH_BAL = 0;

            ALPHA_BAL = 0;
            BETA_BAL = 0;
        }
    }

    /// <summary>
    /// Структура для хранения результатов интегрирования
    /// </summary>
    public class IntegralMeanings
    {
        public double V = 0;

        public double Vx = 0;
        public double Vy = 0;
        public double Vz = 0;

        public double Wx = 0;
        public double Wy = 0;
        public double Wz = 0;

        public double X = 0;
        public double Y = 0;
        public double Z = 0;

        public double Xg = 0;
        public double Yg = 0;
        public double Zg = 0;

        public double GAMA = 0;
        public double GAMAc = 0;

        public double PSI = 0;
        public double PSIc = 0;

        public double THETA = 0;
        public double THETA_PATH = 0;
        public double THETAt = 0;

        public double ALPHA = 0;
        public double BETA = 0;

        public double ALPHAt = 0;
        public double BETAt = 0;

        public double q = 0;
        public double Q = 0;
        public double R = 0;

        //==============================

        public double V_DEL = 0;

        public double Xg_DEL = 0;
        public double Yg_DEL = 0;
        public double Zg_DEL = 0;

        public double Wx_DEL = 0;
        public double Wy_DEL = 0;
        public double Wz_DEL = 0;

        public double GAMA_DEL = 0;
        public double PSI_DEL = 0;

        public double THETA_DEL = 0;
        public double THETA_PATH_DEL = 0;

        public double ALPHA_DEL = 0;
        public double BETA_DEL = 0;

        //==============================

        public double V_BAL = 0;

        public double Xg_BAL = 0;
        public double Yg_BAL = 0;
        public double Zg_BAL = 0;

        public double Wx_BAL = 0;
        public double Wy_BAL = 0;
        public double Wz_BAL = 0;

        public double GAMA_BAL = 0;
        public double PSI_BAL = 0;

        public double THETA_BAL = 0;
        public double THETA_PATH_BAL = 0;

        public double ALPHA_BAL = 0;
        public double BETA_BAL = 0;

        //==============================

        public void Clear()
        {
            V = 0;

            Vx = 0;
            Vy = 0;
            Vz = 0;

            Wx = 0;
            Wy = 0;
            Wz = 0;

            X = 0;
            Y = 0;
            Z = 0;

            Xg = 0;
            Yg = 0;
            Zg = 0;

            GAMA = 0;
            GAMAc = 0;

            PSI = 0;
            PSIc = 0;

            THETA = 0;
            THETA_PATH = 0;
            THETAt = 0;

            ALPHA = 0;
            BETA = 0;

            ALPHAt = 0;
            BETAt = 0;

            q = 0;
            Q = 0;
            R = 0;

            //==============================

            V_DEL = 0;

            Wx_DEL = 0;
            Wy_DEL = 0;
            Wz_DEL = 0;

            GAMA_DEL = 0;
            PSI_DEL = 0;

            THETA_DEL = 0;
            THETA_PATH_DEL = 0;

            ALPHA_DEL = 0;
            BETA_DEL = 0;

            //==============================

            V_BAL = 0;

            Xg_BAL = 0;
            Yg_BAL = 0;
            Zg_BAL = 0;

            Wx_BAL = 0;
            Wy_BAL = 0;
            Wz_BAL = 0;

            GAMA_BAL = 0;
            PSI_BAL = 0;

            THETA_BAL = 0;
            THETA_PATH_BAL = 0;

            ALPHA_BAL = 0;
            BETA_BAL = 0;

            //==============================
        }
    }

    /// <summary>
    /// Структура линеаризированих коэф
    /// </summary>
    public class LinearizedCoefficient
    {
        public double c1 = 0;
        public double c2 = 0;
        public double c3 = 0;
        public double c4 = 0;
        public double c5 = 0;
        public double c6 = 0;
        public double c7 = 0;
        public double c8 = 0;
        public double c9 = 0;
        public double c10 = 0;
        public double c11 = 0;

        public double a1 = 0;
        public double a2 = 0;
        public double a3 = 0;
        public double a4 = 0;
        public double a5 = 0;
        public double a6 = 0;
        public double a7 = 0;
        public double a8 = 0;
        public double a9 = 0;
        public double a10 = 0;

        public double b1 = 0;
        public double b2 = 0;
        public double b3 = 0;
        public double b4 = 0;
        public double b5 = 0;
        public double b6 = 0;
        public double b7 = 0;
        public double b8 = 0;
        public double b9 = 0;

        public double e1 = 0;
        public double e2 = 0;

        public void Clear()
        {
            c1 = 0;
            c2 = 0;
            c3 = 0;
            c4 = 0;
            c5 = 0;
            c6 = 0;
            c7 = 0;
            c8 = 0;
            c9 = 0;
            c10 = 0;
            c11 = 0;

            a1 = 0;
            a2 = 0;
            a3 = 0;
            a4 = 0;
            a5 = 0;
            a6 = 0;
            a7 = 0;
            a8 = 0;
            a9 = 0;
            a10 = 0;

            b1 = 0;
            b2 = 0;
            b3 = 0;
            b4 = 0;
            b5 = 0;
            b6 = 0;
            b7 = 0;
            b8 = 0;
            b9 = 0;

            e1 = 0;
            e2 = 0;
            
        }
    }


    /// <summary>
    /// Структура хранения графика получения данных для интерполяции
    /// </summary>
    public class interpolateCoefficients
    {
        public static Int32 s = 25;
        public Int32 size = s;
        public Double[] X = new Double[s];
        public Double[] Y = new Double[s];

        public void Clear()
        {
            for (int i = 0; i < s; i++)
            {
                X[i] = 0;
                Y[i] = 0;
            }

        }

        public void setArray(Double[] x, Double[] y)
        {
            for (int i = 0; i < s; i++)
            {
                X[i] = x[i];
                Y[i] = y[i];
            }
        }
    }
}


