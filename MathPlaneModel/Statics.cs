using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathPlaneModel
{
    public class Statics
    {
        public double dt = 0.1;

        public double g = 9.81;
        public double G = 80000;
        public double m = 8000;
        public double A = 0.5;
        public double S = 201.45;
        public double L = 37.5;
        public double bA = 5.285;
        public double PO_h = 0.119;
        public double ALPHAt = 0.0001;

        public double Cz_BETA = -0.0175;
        public double Cz_del_n = -0.0034;
        public double Czk_BETA = -0.5;

        public double Cyo = 1;
        public double Cxo = 0.1;
        public double Cy_ALPHA = 5.93;
        public double DELTA_Cxa = 0;
        public double Cx = 0.039;
        public double Cy_del_e_rv = 0.286;

        public double mzo = 0.0014;
        public double mz_ALPHA = -1.95;
        public double mz_ALPHA1 = -4;
        public double mx_BETA = -0.05;
        public double my_BETA = -0.15;
        public double mx_w1x = -0.4;
        public double mx_w1y = -0.1;
        public double my_w1y = -0.31;
        public double my_w1x = -0.014;
        public double mz_w1z_plus_mz_ALPHA1 = -3;
        public double mz_w1z = -13;

        public double mx_del_e = 0.1;
        public double my_del_e = 0.1;
        //public double mz_del_e_rv = 0.0165;
        public double mz_del_e_rv = -0.92;

        public double mx_del_n = -0.0001;
        public double my_del_n = -0.00135;

        public double Ixx = 170000;
        public double Iyy = 800000;
        public double Izz = 660000;
        public double Ipp = 1000;

        public double Vo = 200;
        public double VtakeOff = 70;
        public double Ho = 100;
        public double Tro = 200;

        public double ALPHAo = 2;
        public double THETAo = 2;
        public double BETo = 0;

        public double del_eo = 0;
        public double del_no = 0;
        public double del_e_rvo = 0;

        public double del_e_rvMAX = 10;
        public double del_e_rvMIN = -20;
        public double del_e_rvSTEP = 0.5;

        public double kH = 0.01;
        public double kWz = 1;

        public double my_Wy = 0.0014;
        public double my_DELn = 0.0014;

        public double fW = 0.01; //коэф передачи переднего колеса
        public double mGear = 0.01; //коэф передачи основной стойки

        public double froll = 0.03;
        public double fslip = 0.9;
        public double InhibitionL = 0; //если левое колесо не тормозит
        public double InhibitionR = 0; //если правое колесо не тормозит 

        public double XfrontWheel = 0.4;
        public double XmainWheel = 0.4;
        public double BETAk = -0.01;
        public double Zchassis = 4.6; //колея шасси

    }
}
