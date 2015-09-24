using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathPlaneModel
{

    public class Controls
    {
        public double e;                   
        public double n;                         
        public double e_rv;
        public double Tr;

        public double e_DEL;
        public double n_DEL;
        public double e_rv_DEL;
        public double Tr_DEL;

        public double e_BAL;
        public double n_BAL;
        public double e_rv_BAL;
        public double Tr_BAL;

        public double fW; //угол поворота переднего колеса

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
        public double x;
        public double y;
        public double z;

        public double x1;                          
        public double x2;                          
        public double x3;                           
        public double y1;                           
        public double y2;                             
        public double y3;                           
        public double z1;                           
        public double z2;                             
        public double z3;

        public double yz;  //момент, создаваемый боковыми аэродин. силами
        public double yWy; //момент демпфирования обусловленый угловой скоростью Wy
        public double yp; //момент, как следствие несиметричной тяги двиготелей
        public double yt; //момент несиметричного торможения   

        public double x_roll;
        public double x_slide;

        public double y_roll;
        public double y_slide;

        public double z_roll;
        public double z_slide;

        public void Clear()
        {
            x = 0;
            y = 0;
            z = 0;
        }

    }

    public class Forses
    {
        public double x;
        public double y;
        public double z;

        public double x1;                   
        public double x2;                   
        public double x3;                     
        public double y1;                       
        public double y2;                      
        public double y3;                        
        public double z1;                     
        public double z2;                   
        public double z3;

        public double zBETA;
        public double zDELn;
        public double zt;  //сила торможения   

        public void Clear()
        {
            x = 0;
            y = 0;
            z = 0;
        }

    }

    public class Coefficient
    {
        public double x;                    
        public double y;                       
        public double z;

        public void Clear()
        {
            x = 0;
            y = 0;
            z = 0;
        } 
  
    }

    public class Overload //N
    {
        public double x;
        public double y;
        public double z;

        public double xt;

        public void Clear()
        {
            x = 0;
            y = 0;
            z = 0;
        }
    }

    public class OperatingAngularVelocity
    {
        public double Wx;                   
        public double Wy;                   
        public double Wz;

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
        public double V;

        public double Vx;
        public double Vy;
        public double Vz;

        public double Wx;
        public double Wy;
        public double Wz;

        public double X;
        public double Y;
        public double Z;

        public double Xg;
        public double Yg;
        public double Zg;

        public double GAMA;
        public double GAMAc;

        public double PSI;
        public double PSIc;

        public double THETA;
        public double THETA_PATH;
        public double THETAt;

        public double ALPHA;
        public double BETA;

        public double ALPHAt;
        public double BETAt;

        //==============================

        public double V_DEL;

        public double Xg_DEL;
        public double Yg_DEL;
        public double Zg_DEL;

        public double Wx_DEL;
        public double Wy_DEL;
        public double Wz_DEL;

        public double GAMA_DEL;
        public double PSI_DEL;

        public double THETA_DEL;
        public double THETA_PATH_DEL;

        public double ALPHA_DEL;
        public double BETA_DEL;

        //==============================

        public double V_BAL;

        public double Xg_BAL;
        public double Yg_BAL;
        public double Zg_BAL;

        public double Wx_BAL;
        public double Wy_BAL;
        public double Wz_BAL;

        public double GAMA_BAL;
        public double PSI_BAL;

        public double THETA_BAL;
        public double THETA_PATH_BAL;

        public double ALPHA_BAL;
        public double BETA_BAL;

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
        public double V;

        public double Vx;
        public double Vy;
        public double Vz;

        public double Wx;
        public double Wy;
        public double Wz;

        public double X;
        public double Y;
        public double Z;

        public double Xg;
        public double Yg;
        public double Zg;

        public double GAMA;
        public double GAMAc;

        public double PSI;
        public double PSIc;

        public double THETA;
        public double THETA_PATH;
        public double THETAt;

        public double ALPHA;
        public double BETA;

        public double ALPHAt;
        public double BETAt;

        public double q;
        public double Q;
        public double R;

        //==============================

        public double V_DEL;

        public double Xg_DEL;
        public double Yg_DEL;
        public double Zg_DEL;

        public double Wx_DEL;
        public double Wy_DEL;
        public double Wz_DEL;

        public double GAMA_DEL;
        public double PSI_DEL;

        public double THETA_DEL;
        public double THETA_PATH_DEL;

        public double ALPHA_DEL;
        public double BETA_DEL;

        //==============================

        public double V_BAL;

        public double Xg_BAL;
        public double Yg_BAL;
        public double Zg_BAL;

        public double Wx_BAL;
        public double Wy_BAL;
        public double Wz_BAL;

        public double GAMA_BAL;
        public double PSI_BAL;

        public double THETA_BAL;
        public double THETA_PATH_BAL;

        public double ALPHA_BAL;
        public double BETA_BAL;

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
        public double c1;
        public double c2;
        public double c3;
        public double c4;
        public double c5;
        public double c6;
        public double c7;
        public double c8;
        public double c9;
        public double c10;
        public double c11;

        public double a1;
        public double a2;
        public double a3;
        public double a4;
        public double a5;
        public double a6;
        public double a7;
        public double a8;
        public double a9;
        public double a10;

        public double b1;
        public double b2;
        public double b3;
        public double b4;
        public double b5;
        public double b6;
        public double b7;
        public double b8;
        public double b9;

        public double e1;
        public double e2;

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


